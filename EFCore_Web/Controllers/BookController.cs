using EFCore_DataAccess.Data;
using EFCore_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
			foreach (var listItem in list)
			{
				listItem.Publisher = await _dbContext.Publishers.FindAsync(listItem.Publisher_Id);
			}
			return View(list);
		}

		public async Task<IActionResult> Upsert(int? id)
		{
			BookViewModel viewModel = new();
			viewModel.Book = new();
			if (id > 0)
			{
				viewModel.Book = await _dbContext.Books.FindAsync(id);
				if (viewModel.Book is null)
				{
					return NotFound();
				}
			}

			//var publishers = await _dbContext.Publishers.ToListAsync();
			//var publisherList = new List<SelectListItem>();
			//foreach (var publisher in publishers)
			//{
			//	publisherList.Add(new SelectListItem()
			//	{
			//		Text = publisher.Name,
			//		Value = Convert.ToString(publisher.Publisher_Id)
			//	});
			//}

			viewModel.PublisherList = await _dbContext.Publishers.Select(p => new SelectListItem()
			{
				Text = p.Name,
				Value = Convert.ToString(p.Publisher_Id)
			}).ToListAsync();
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Upsert(BookViewModel bookViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(bookViewModel);
			}

			if (bookViewModel.Book.IDBook > 0)
			{
				_dbContext.Books.Update(bookViewModel.Book);
			}
			else
			{
				await _dbContext.Books.AddAsync(bookViewModel.Book);
			}

			await _dbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			if (id > 0)
			{
				var book = await _dbContext.Books.FindAsync(id);
				if (book is null)
				{
					return NotFound();
				}
				_dbContext.Books.Remove(book);
				await _dbContext.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return BadRequest();
		}
	}
}