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
				await _applicationDbContext.SubCategories.AddAsync(subCategory);
			}
			else
			{
				_applicationDbContext.Update(subCategory);
			}

			await _applicationDbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}