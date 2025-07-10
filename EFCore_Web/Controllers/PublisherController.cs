using EFCore_DataAccess.Data;
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
	}
}