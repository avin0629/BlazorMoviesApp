using BlazorMoviesApp.Client.Helpers;
using BlazorMoviesApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Client.Repository
{
	public class PeopleRepository : IPeopleRepository
	{
		private readonly IHttpService httpService;
		private readonly string url = "api/people";

		public PeopleRepository(IHttpService httpService)
		{
			this.httpService = httpService;
		}
	
		public async Task CreatePerson(Person person)
		{
			var response = await this.httpService.Post(url, person);

			if (!response.Success)
			{
				throw new ApplicationException(await response.GetBody());
			}
		}

		public async Task<List<Person>> GetPersons()
		{
			var response = await httpService.Get<List<Person>>(url);

			if (!response.Success)
			{
				throw new ApplicationException(await response.GetBody());
			}

			return response.Response;
		}

		public async Task<List<Person>> GetPeopleByName(string name)
		{
			var response = await httpService.Get<List<Person>>($"{url}/search/{name}");

			if (!response.Success)
			{
				throw new ApplicationException(await response.GetBody());
			}

			return response.Response;
		}
	}
}
