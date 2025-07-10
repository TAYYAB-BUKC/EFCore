using EFCore_DataAccess.Data;
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
	}
}