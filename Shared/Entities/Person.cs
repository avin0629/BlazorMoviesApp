using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Shared.Entities
{
	public class Person
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Biography { get; set; }

		public string Picture { get; set; } //= "https://m.media-amazon.com/images/M/MV5BNzZiNTEyNTItYjNhMS00YjI2LWIwMWQtZmYwYTRlNjMyZTJjXkEyXkFqcGdeQXVyMTExNzQzMDE0._V1_UX214_CR0,0,214,317_AL_.jpg";

		[Required]
		public DateTime? DateOfBirth { get; set; }
	}
}
