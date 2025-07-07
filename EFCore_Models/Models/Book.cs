using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Models.Models
{
	[Table("TBL_Books")]
	public class Book
	{
		[Key]
		public int IDBook { get; set; }
		public string Title { get; set; }
		[Column("Book_ISBN")]
		public string ISBN { get; set; }
		public decimal Price { get; set; }
	}
}