using BlazorMoviesApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Server.BlazorMoviesDatabase
{
	public class BlazorMoviesDbContext : DbContext
	{
		public BlazorMoviesDbContext(DbContextOptions<BlazorMoviesDbContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MoviesActors>().HasKey(x => new { x.MovieId, x.PersonId });
			modelBuilder.Entity<MoviesGenres>().HasKey(x => new { x.MovieId, x.GenreId });

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Genre> Genres { get; set; }		
		public DbSet<Movie> Movies { get; set; }		
		public DbSet<Person> People { get; set; }		
		public DbSet<MoviesActors> MoviesActors { get; set; }		
		public DbSet<MoviesGenres> MoviesGenres { get; set; }
	}
}
