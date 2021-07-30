using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Shared.Entities
{
	public class MoviesGenres
	{
		public int MovieId { get; set; }

		public int GenresId { get; set; }

		public Movie Movie { get; set; }

		public Genre Genre { get; set; }
	}
}
