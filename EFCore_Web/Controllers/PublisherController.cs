using EFCore_DataAccess.Data;
using EFCore_Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Web.Controllers
{
	public class PublisherController : Controller
	{
		private readonly ApplicationDbContext _dbContext;
		public PublisherController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IActionResult> Index()
		{
			var list = await _dbContext.Publishers.ToListAsync();
			return View(list);
		}

		public async Task<IActionResult> Upsert(int? id)
		{
			Publisher publisher = new();
			if(id > 0)
			{
				publisher = await _dbContext.Publishers.FindAsync(id);
				if (publisher is null)
				{
					return NotFound();
				}
			}
			return View(publisher);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Upsert(Publisher publisher)
		{
			if (!ModelState.IsValid)
			{
				return View(publisher);
			}

			if (publisher.Publisher_Id > 0)
			{
				_dbContext.Publishers.Update(publisher);
			}
			else
			{
				await _dbContext.Publishers.AddAsync(publisher);
			}

			await _dbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			if (id > 0)
			{
				var publisher = await _dbContext.Publishers.FindAsync(id);
				if (publisher is null)
				{
					return NotFound();
				}
				_dbContext.Publishers.Remove(publisher);
				await _dbContext.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return BadRequest();
		}
	}
}