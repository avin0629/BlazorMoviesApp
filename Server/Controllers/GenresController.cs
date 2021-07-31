using BlazorMoviesApp.Server.BlazorMoviesDatabase;
using BlazorMoviesApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class GenresController : ControllerBase
	{
		private readonly BlazorMoviesDbContext dbContext;

		public GenresController(BlazorMoviesDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[HttpPost]
		public async Task<ActionResult<int>> Post(Genre genre)
		{
			dbContext.Add(genre);
			await dbContext.SaveChangesAsync();
			return genre.Id;
		}

		[HttpGet]
		public async Task<ActionResult<List<Genre>>> Get()
		{
			return dbContext.Genres.ToList();
		}

	}
}
