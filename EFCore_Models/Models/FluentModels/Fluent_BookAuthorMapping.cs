﻿namespace EFCore_Models.Models
{
	public class Fluent_BookAuthorMapping
	{
		public int Book_Id { get; set; }
		public int Author_Id { get; set; }

		public Fluent_Author Author { get; set; }
		public Fluent_Book Book { get; set; }
	}
}