using System.ComponentModel.DataAnnotations;

namespace EFCore_Models.Models
{
	public class Fluent_Publisher
	{
		[Key]
		public int Publisher_Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Location { get; set; }
	}
}