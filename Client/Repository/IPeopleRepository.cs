using BlazorMoviesApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Client.Repository
{
	interface IPeopleRepository
	{
		Task CreatePerson(Person person);
		Task<List<Person>> GetPeopleByName(string name);
		Task<List<Person>> GetPersons();
	}
}
