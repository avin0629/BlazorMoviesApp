using BlazorMoviesApp.Server.BlazorMoviesDatabase;
using BlazorMoviesApp.Server.Helpers;
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
	public class PeopleController : ControllerBase
	{
		private readonly BlazorMoviesDbContext blazorMoviesDbContext;
		private readonly IFileStorageService fileStorageService;

		public PeopleController(BlazorMoviesDbContext blazorMoviesDbContext, IFileStorageService fileStorageService)
		{
			this.blazorMoviesDbContext = blazorMoviesDbContext;
			this.fileStorageService = fileStorageService;
		}

		[HttpPost]
		public async Task<ActionResult<int>> Post(Person person)
		{
			if (!string.IsNullOrWhiteSpace(person.Picture))
			{
				person.Picture = await fileStorageService.SaveFile(Convert.FromBase64String(person.Picture), ".jpeg", "People");
			}

			blazorMoviesDbContext.Add(person);
			await blazorMoviesDbContext.SaveChangesAsync();
			return person.Id;
		}

		[HttpGet]
		public async Task<ActionResult<List<Person>>> Get()
		{
			return await blazorMoviesDbContext.People.ToListAsync();
		}

		[HttpGet("search/{searchText}")]
		public async Task<ActionResult<List<Person>>> FilterByName(string searchText)
		{
			if (string.IsNullOrWhiteSpace(searchText))
			{
				return new List<Person>();
			}
			else
			{
				return await blazorMoviesDbContext.People.Where(x => x.Name.Contains(searchText)).Take(5).ToListAsync();
			}
		}
	}
}
