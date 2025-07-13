using EFCore_Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCore_Models.ViewModels
{
	public class BookAuthorViewModel
	{
		public Book Book { get; set; }
		public BookAuthorMapping BookAuthorMapping { get; set; }
		public IEnumerable<BookAuthorMapping> BookAuthorList { get; set; }
		public IEnumerable<SelectListItem> AuthorList { get; set; }
	}
}