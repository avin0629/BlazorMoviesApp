using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Client.Helpers
{
	public interface IHttpService
	{
		Task<HttpResponseWrapper<T>> Get<T>(string url);

		Task<HttpResponseWrapper<object>> Post<T>(string url, T data);

		Task<HttpResponseWrapper<TResponse>> Post<TRequest, TResponse>(string url, TRequest data);
	}
}
