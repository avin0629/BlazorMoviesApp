using BlazorMoviesApp.Shared.DTOs;
using BlazorMoviesApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Client.Repository
{
	public interface IMovieRepository
	{
		Task<int> CreateMovie(Movie movie);
		Task<DetailsMovieDTO> GetDetailsMovieDTO(int id);
		Task<IndexPageDTO> GetIndexPageDTO();
	}
}
