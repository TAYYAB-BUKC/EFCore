using EFCore_DataAccess.Data;
using EFCore_Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Web.Controllers
{
	public class SubCategoryController : Controller
	{
		private readonly ApplicationDbContext _applicationDbContext;
		public SubCategoryController(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<IActionResult> Index()
		{
			var list = await _applicationDbContext.SubCategories.ToListAsync();
			return View(list);
		}

		public async Task<IActionResult> Upsert(int? id)
		{
			SubCategory category = new();
			if(id == null || id <= 0)
			{
				return View(category);
			}

			category = await _applicationDbContext.SubCategories.FindAsync(id);
			if(category is null)
			{
				return NotFound();
			}

			return View(category);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Upsert(SubCategory subCategory)
		{
			if (!ModelState.IsValid)
			{
				return View(subCategory);
			}

			if (subCategory.SubCategory_Id > 0)
			{
				_applicationDbContext.Update(subCategory);
			}
			else
			{
				await _applicationDbContext.SubCategories.AddAsync(subCategory);
			}

			await _applicationDbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			if (id <= 0)
			{
				return BadRequest();
			}

			var subCategory = await _applicationDbContext.SubCategories.FindAsync(id);
			if(subCategory is null)
			{
				return NotFound();
			}

			_applicationDbContext.Remove(subCategory);
			await _applicationDbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> CreateMultiple2()
		{
			List<SubCategory> subCategories = new();
			for (int i = 0; i < 2; i++)
			{
				subCategories.Add(new SubCategory()
				{
					Name = Guid.NewGuid().ToString("N")
				});
			}
			await _applicationDbContext.SubCategories.AddRangeAsync(subCategories);
			await _applicationDbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> CreateMultiple5()
		{
			List<SubCategory> subCategories = new();
			for (int i = 0; i < 5; i++)
			{
				subCategories.Add(new SubCategory()
				{
					Name = Guid.NewGuid().ToString("N")
				});
			}
			await _applicationDbContext.SubCategories.AddRangeAsync(subCategories);
			await _applicationDbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> RemoveMultiple2()
		{
			var subCategories = await _applicationDbContext.SubCategories.OrderByDescending(sc => sc.SubCategory_Id).Take(2).ToListAsync();
			_applicationDbContext.SubCategories.RemoveRange(subCategories);
			await _applicationDbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> RemoveMultiple5()
		{
			var subCategories = await _applicationDbContext.SubCategories.OrderByDescending(sc => sc.SubCategory_Id).Take(5).ToListAsync();
			_applicationDbContext.SubCategories.RemoveRange(subCategories);
			await _applicationDbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}