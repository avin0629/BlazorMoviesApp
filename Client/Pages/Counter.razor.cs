using BlazorMoviesApp.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazorMoviesApp.Client.Shared.MainLayout;
using MathNet.Numerics.Statistics;

namespace BlazorMoviesApp.Client.Pages
{
	public partial class Counter
	{
		private int currentCount = 0;

		//public void IncrementCount()
		//{
		//	var array = new double[] { 1, 2, 3, 4, 5 };
		//	var max = array.Maximum();
		//	var min = array.Minimum();

		//	currentCount++;
		//}

		private static int currentCountStatic = 0;

		//[Inject]
		//SingletonService singleton { get; set; }

		//[Inject]
		//TransientService transient { get; set; }

		[Inject]
		IJSRuntime js { get; set; }

		//[CascadingParameter(Name = "Color")]
		//public string Color { get; set; }

		//[CascadingParameter(Name = "Size")]
		//public string Size { get; set; }

		//[CascadingParameter]
		//public AppState AppState { get; set; }


		IJSObjectReference module;

		[JSInvokable]
		public async Task IncrementCount()
		{
			var array = new double[] { 1, 2, 3, 4, 5 };
			var max = array.Maximum();
			var min = array.Minimum();

			module = await js.InvokeAsync<IJSObjectReference>("import", "./scripts/Counter.js");
			await module.InvokeVoidAsync("displayAlert", $"Max is {max} and Min is {min}");

			currentCount++;
			//singleton.Value += 1;
			//transient.Value += 1;
			currentCountStatic++;
			await js.InvokeVoidAsync("dotnetStaticInvocation");
		}

		//private async Task IncrementCountJavascript()
		//{
		//	await js.InvokeVoidAsync("dotnetInstanceInvocation", DotNetObjectReference.Create(this));
		//}

		//private List<Movie> movies;

		//protected override void OnInitialized()
		//{
		//	//await Task.Delay(3000);

		//	movies = new List<Movie>()
		//	{
		//		new Movie(){ Title = "Joker", ReleaseDate = new DateTime(2019, 7, 2) },
		//		new Movie(){ Title = "Avengers", ReleaseDate = new DateTime(2016, 11, 23) },
		//	};
		//}

		[JSInvokable]
		public static Task<int> GetCurrentCount()
		{
			return Task.FromResult(currentCountStatic);
		}
	}
}
