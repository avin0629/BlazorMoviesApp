using BlazorMoviesApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Client.Helpers
{
	public class RepositoryInMemory : IRepository
	{
		public List<Movie> GetMovies()
		{
			return new List<Movie>()
			{
				new Movie(){ Title = "Spider-Man: Far From Home", ReleaseDate = new DateTime(2019, 7, 2), Poster="https://upload.wikimedia.org/wikipedia/en/2/21/Web_of_Spider-Man_Vol_1_129-1.png" },
				new Movie(){ Title = "Moana", ReleaseDate = new DateTime(2016, 11, 23), Poster="https://upload.wikimedia.org/wikipedia/en/thumb/2/26/Moana_Teaser_Poster.jpg/220px-Moana_Teaser_Poster.jpg" },
				new Movie(){ Title = "Inception", ReleaseDate = new DateTime(2010, 7, 16), Poster="https://i2.wp.com/images.onwardstate.com/uploads/2010/10/inception.png?fit=775%2C461&ssl=1" },
				//new Movie(){ Title = "Tomorrow War", ReleaseDate = new DateTime(2021, 5, 16) },
				//new Movie(){ Title = "Harry Potter", ReleaseDate = new DateTime(2006, 5, 16) },
			};
		}
	}
}
