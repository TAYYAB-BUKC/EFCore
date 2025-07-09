using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Models.Models
{
	[Table("TBL_Books")]
	public class Book
	{
		[Key]
		public int IDBook { get; set; }
		[Required]
		[MaxLength(50)]
		public string Title { get; set; }
		[Column("Book_ISBN")]
		public string ISBN { get; set; }
		[Required]
		public decimal Price { get; set; }
		[NotMapped]
		public string PriceRange { get; set; }
		public BookDetail Details { get; set; }

		[ForeignKey(nameof(Publisher))]
		public int Publisher_Id { get; set; }
		public Publisher Publisher { get; set; }

		public List<BookAuthorMapping> BookAuthors { get; set; }
	}
}