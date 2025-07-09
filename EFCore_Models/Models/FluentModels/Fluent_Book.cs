namespace EFCore_Models.Models
{
	public class Fluent_Book
	{
		public int IDBook { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }
		public decimal Price { get; set; }
		public string PriceRange { get; set; }

		public Fluent_BookDetail Details { get; set; }

		public int Publisher_Id { get; set; }
		public Fluent_Publisher Publisher { get; set; }
	}
}