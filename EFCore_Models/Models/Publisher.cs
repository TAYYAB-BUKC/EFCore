﻿using System.ComponentModel.DataAnnotations;

namespace EFCore_Models.Models
{
	public class Publisher
	{
		[Key]
		public int Publisher_Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Location { get; set; }

		public List<Book> Books { get; set; }
	}
}