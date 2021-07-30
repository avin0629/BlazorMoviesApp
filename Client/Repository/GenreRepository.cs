using BlazorMoviesApp.Client.Helpers;
using BlazorMoviesApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Client.Repository
{
	public class GenreRepository : IGenreRepository
	{
		private readonly IHttpService httpService;
		private string url = "api/genres";

		public GenreRepository(IHttpService httpService)
		{
			this.httpService = httpService;
		}

		public async Task CreateGenre(Genre genre)
		{
			var response = await httpService.Post(url, genre);

			if (!response.Success)
			{
				throw new ApplicationException(await response.GetBody());
			}
		}
	}
}
