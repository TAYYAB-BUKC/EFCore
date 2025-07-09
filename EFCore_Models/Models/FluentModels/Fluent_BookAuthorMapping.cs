using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Models.Models
{
	public class Fluent_BookAuthorMapping
	{
		[ForeignKey(nameof(Book))]
		public int Book_Id { get; set; }
		[ForeignKey(nameof(Author))]
		public int Author_Id { get; set; }

		public Fluent_Book Book { get; set; }
		public Fluent_Author Author { get; set; }
	}
}