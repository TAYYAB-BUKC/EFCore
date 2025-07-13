using EFCore_DataAccess.Data;
using EFCore_Models.Models;
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
			var list = await _dbContext.Books.Include(b => b.Publisher).ToListAsync();
			//foreach (var listItem in list)
			//{
			//	//listItem.Publisher = await _dbContext.Publishers.FindAsync(listItem.Publisher_Id);
			//	await _dbContext.Entry(listItem).Reference(b => b.Publisher).LoadAsync();
			//}
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

		public async Task<IActionResult> Details(int id)
		{
			BookDetail bookDetail = new();

			if (id > 0)
			{
				bookDetail = await _dbContext.BookDetails.FirstOrDefaultAsync(bd => bd.Book_Id == id);
				if(bookDetail is null)
				{
					bookDetail = new();
				}
				bookDetail.Book = await _dbContext.Books.Include("Publisher").FirstOrDefaultAsync(b => b.IDBook == id);
				if (bookDetail.Book is null)
				{
					return NotFound();
				}
				return View(bookDetail);
			}
			return NotFound();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Details(BookDetail bookDetailModel)
		{
			if (!ModelState.IsValid)
			{
				return View(bookDetailModel);
			}

			if (bookDetailModel.BookDetail_Id > 0)
			{
				_dbContext.BookDetails.Update(bookDetailModel);
			}
			else
			{
				await _dbContext.BookDetails.AddAsync(bookDetailModel);
			}

			await _dbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public void PlayGround()
		{
			var bookTemp = _dbContext.Books.FirstOrDefault();
			bookTemp.Price = 100;

			var bookCollection = _dbContext.Books;
			decimal totalPrice = 0;

			foreach (var book in bookCollection)
			{
				totalPrice += book.Price;
			}

			var bookList = _dbContext.Books.ToList();
			foreach (var book in bookList)
			{
				totalPrice += book.Price;
			}

			var bookCollection2 = _dbContext.Books;
			var bookCount1 = bookCollection2.Count();

			var bookCount2 = _dbContext.Books.Count();
		}

		public void IEnumerableVsIQueryable()
		{
			IEnumerable<Book> enumerableBooks = _dbContext.Books;
			var filteredBooks = enumerableBooks.Where(b => b.Price > 50).ToList();

			IQueryable<Book> queryableBooks = _dbContext.Books;
			var filteredBooks1 = queryableBooks.Where(b => b.Price > 50).ToList();
		}
	}
}