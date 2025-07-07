using System.ComponentModel.DataAnnotations;

namespace EFCore_Models.Models
{
	public class Book
	{
		[Key]
		public int IDBook { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }
		public double Price { get; set; }
	}
}