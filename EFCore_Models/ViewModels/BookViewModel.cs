using EFCore_Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCore_Models.ViewModels
{
	public class BookViewModel
	{
		public Book Book { get; set; }
		public IEnumerable<SelectListItem> PublisherList { get; set; }
	}
}