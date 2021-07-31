using BlazorMoviesApp.Client.Helpers;
using BlazorMoviesApp.Shared.DTOs;
using BlazorMoviesApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Client.Repository
{
	public class MovieRepository : IMovieRepository
	{
		private readonly IHttpService httpService;
		private readonly string url = "api/movies";

		public MovieRepository(IHttpService httpService)
		{
			this.httpService = httpService;
		}

		public async Task<int> CreateMovie(Movie movie)
		{
			var response = await this.httpService.Post<Movie, int>(url, movie);

			if (!response.Success)
			{
				throw new ApplicationException(await response.GetBody());
			}

			return response.Response;
		}

		public async Task<IndexPageDTO> GetIndexPageDTO()
		{
			var response = await httpService.Get<IndexPageDTO>(url);

			if (!response.Success)
			{
				throw new ApplicationException(await response.GetBody());
			}

			return response.Response;
		}

		public async Task<DetailsMovieDTO> GetDetailsMovieDTO(int id)
		{
			var response = await httpService.Get<DetailsMovieDTO>($"{url}/{id}");

			if (!response.Success)
			{
				throw new ApplicationException(await response.GetBody());
			}

			return response.Response;
		}

	}
}
