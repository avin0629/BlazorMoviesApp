using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Client.Helpers
{
	public class HttpResponseWrapper<T>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="response"></param>
		/// <param name="success"></param>
		/// <param name="httpResponseMessage"></param>
		public HttpResponseWrapper(T response, bool success, HttpResponseMessage httpResponseMessage)
		{
			Success = success;
			Response = response;
			HttpResponseMessage = httpResponseMessage;
		}

		public bool Success { get; set; }

		public T Response { get; set; }

		public HttpResponseMessage HttpResponseMessage { get; set; }

		public async Task<string> GetBody()
		{
			return await HttpResponseMessage.Content.ReadAsStringAsync();
		}
	}
}
