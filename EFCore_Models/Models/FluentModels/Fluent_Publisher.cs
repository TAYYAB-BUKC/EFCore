namespace EFCore_Models.Models
{
	public class Fluent_Publisher
	{
		public int Publisher_Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }

		public virtual IEnumerable<Fluent_Book> Books { get; set; }
	}
}