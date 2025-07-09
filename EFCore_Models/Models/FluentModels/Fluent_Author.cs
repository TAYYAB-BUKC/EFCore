using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Models.Models
{
	public class Fluent_Author
	{
		[Key]
		public int Author_Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public string Location { get; set; }
		[NotMapped]
		public string FullName => $"{FirstName} {LastName}";

		public List<Fluent_BookAuthorMapping> AuthorBooks { get; set; }
	}
}