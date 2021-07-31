﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Shared.Entities
{
	public class Movie
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public DateTime? ReleaseDate { get; set; }

		public string Poster { get; set; }

		public string Summary { get; set; }

		public bool InTheaters { get; set; }

		public string Trailer { get; set; }

		public string TitleBrief
		{
			get
			{
				if (string.IsNullOrWhiteSpace(Title))
				{
					return null;
				}

				if (Title.Length > 60)
				{
					return Title.Substring(0, 60) + "......";
				}
				else
				{
					return Title;
				}
			}
		}

		public List<MoviesGenres> MoviesGenres { get; set; } = new List<MoviesGenres>();

		public List<MoviesActors> MoviesActors { get; set; } = new List<MoviesActors>();
	}
}
