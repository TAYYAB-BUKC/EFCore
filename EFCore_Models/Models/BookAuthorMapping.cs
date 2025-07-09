using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Models.Models
{
	public class BookAuthorMapping
	{
		[ForeignKey(nameof(Book))]
		public int Book_Id { get; set; }
		[ForeignKey(nameof(Author))]
		public int Author_Id { get; set; }

		public Book Book { get; set; }
		public Author Author { get; set; }
	}
}