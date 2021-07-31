using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Client.Helpers
{
	public class HttpService : IHttpService
	{
		private readonly HttpClient httpClient;

		private JsonSerializerOptions defaultJsonSerializer => new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

		public HttpService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
		{
			var dataJson = JsonSerializer.Serialize(data);
			var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
			var reponse = await httpClient.PostAsync(url, stringContent);
			return new HttpResponseWrapper<object>(null, reponse.IsSuccessStatusCode, reponse);
		}

		public async Task<HttpResponseWrapper<TResponse>> Post<TRequest, TResponse>(string url, TRequest data)
		{
			var dataJson = JsonSerializer.Serialize(data);
			var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
			var reponse = await httpClient.PostAsync(url, stringContent);

			if (reponse.IsSuccessStatusCode)
			{
				var responseDeserialized = await Deserialize<TResponse>(reponse, defaultJsonSerializer);
				return new HttpResponseWrapper<TResponse>(responseDeserialized, true, reponse);
			}
			else
			{
				return new HttpResponseWrapper<TResponse>(default, false, reponse);
			}
		}

		public async Task<HttpResponseWrapper<T>> Get<T>(string url)
		{
			var responseHttp = await httpClient.GetAsync(url);

			if (responseHttp.IsSuccessStatusCode)
			{
				var responseDeserialized = await Deserialize<T>(responseHttp, defaultJsonSerializer);
				return new HttpResponseWrapper<T>(responseDeserialized, true, responseHttp);
			}
			else
			{
				return new HttpResponseWrapper<T>(default, false, responseHttp);
			}
		}

		private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
		{
			var responseString = await httpResponse.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
		}
	}
}
