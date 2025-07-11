using EFCore_DataAccess.Data;
using EFCore_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Web.Controllers
{
	public class BookController : Controller
	{
		private readonly ApplicationDbContext _dbContext;
		public BookController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IActionResult> Index()
		{
			var list = await _dbContext.Books.ToListAsync();
			return View(list);
		}

		public async Task<IActionResult> Upsert(int? id)
		{
			BookViewModel viewModel = new();
			if (id > 0)
			{
				viewModel.Book = await _dbContext.Books.FindAsync(id);
				if (viewModel.Book is null)
				{
					return NotFound();
				}
			}
			return View(viewModel);
		}
	}
}