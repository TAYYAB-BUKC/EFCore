namespace EFCore_Models.Models
{
	public class Fluent_Author
	{
		public int Author_Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public string Location { get; set; }
		public string FullName => $"{FirstName} {LastName}";

		public List<Fluent_Book> Books { get; set; }
	}
}