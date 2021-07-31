using BlazorMoviesApp.Server.BlazorMoviesDatabase;
using BlazorMoviesApp.Server.Helpers;
using BlazorMoviesApp.Shared.DTOs;
using BlazorMoviesApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MoviesController : ControllerBase
	{
		private readonly BlazorMoviesDbContext blazorMoviesDbContext;
		private readonly IFileStorageService fileStorageService;

		public MoviesController(BlazorMoviesDbContext blazorMoviesDbContext, IFileStorageService fileStorageService)
		{
			this.blazorMoviesDbContext = blazorMoviesDbContext;
			this.fileStorageService = fileStorageService;
		}

		[HttpPost]
		public async Task<ActionResult<int>> Post(Movie movie)
		{
			if (!string.IsNullOrWhiteSpace(movie.Poster))
			{
				movie.Poster = await fileStorageService.SaveFile(Convert.FromBase64String(movie.Poster), ".jpeg", "Movies");
			}

			if (movie.MoviesActors != null)
			{
				for (int i = 0; i < movie.MoviesActors.Count; i++)
				{
					movie.MoviesActors[i].Order = i + 1;
				}
			}

			blazorMoviesDbContext.Add(movie);
			await blazorMoviesDbContext.SaveChangesAsync();
			return movie.Id;
		}

		[HttpGet]
		public async Task<ActionResult<IndexPageDTO>> Get()
		{
			var limit = 6;

			var moviesInTheaters = await blazorMoviesDbContext.Movies
																.Where(x => x.InTheaters)
																.Take(limit)
																.OrderByDescending(x => x.ReleaseDate)
																.ToListAsync();

			var todaysDate = DateTime.Today;

			var upcomingRelease = await blazorMoviesDbContext.Movies
															.Where(x => x.ReleaseDate > todaysDate)
															.OrderBy(x => x.ReleaseDate)
															.Take(limit)
															.ToListAsync();

			var response = new IndexPageDTO()
			{
				InTheaters = moviesInTheaters,
				UpcomingReleases = upcomingRelease
			};

			return response;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<DetailsMovieDTO>> Get(int id)
		{
			var movie = await blazorMoviesDbContext.Movies
													.Where(x => x.Id == id)
													.Include(i => i.MoviesActors).ThenInclude(i => i.Person)
													.Include(i => i.MoviesGenres).ThenInclude(i => i.Genre)
													.FirstOrDefaultAsync();

			if (movie == null)
			{
				return NotFound();
			}
			else
			{
				movie.MoviesActors = movie.MoviesActors.OrderBy(x => x.Order).ToList();

				DetailsMovieDTO detailsMovieDTO = new DetailsMovieDTO()
				{
					Movie = movie,
					Actors = movie.MoviesActors.Select(x => x.Person).ToList(),
					Genres = movie.MoviesGenres.Select(x => x.Genre).ToList()
				};

				return detailsMovieDTO;
			}
		}
	}
}
