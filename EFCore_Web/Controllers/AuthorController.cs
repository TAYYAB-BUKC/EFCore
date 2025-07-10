using EFCore_DataAccess.Data;
using EFCore_Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Web.Controllers
{
	public class AuthorController : Controller
	{
		private readonly ApplicationDbContext _dbContext;
		public AuthorController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IActionResult> Index()
		{
			var list = await _dbContext.Authors.ToListAsync();
			return View(list);
		}

		public async Task<IActionResult> Upsert(int? id)
		{
			Author author = new();
			if (id > 0)
			{
				author = await _dbContext.Authors.FindAsync(id);
				if (author is null)
				{
					return NotFound();
				}
			}
			return View(author);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Upsert(Author author)
		{
			if (!ModelState.IsValid)
			{
				return View(author);
			}

			if (author.Author_Id > 0)
			{
				_dbContext.Authors.Update(author);
			}
			else
			{
				await _dbContext.Authors.AddAsync(author);
			}

			await _dbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			if (id > 0)
			{
				var author = await _dbContext.Authors.FindAsync(id);
				if (author is null)
				{
					return NotFound();
				}
				_dbContext.Authors.Remove(author);
				await _dbContext.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return BadRequest();
		}
	}
}