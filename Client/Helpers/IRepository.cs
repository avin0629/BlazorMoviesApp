using BlazorMoviesApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Client.Helpers
{
	public interface IRepository
	{
		List<Movie> GetMovies();
	}
}
