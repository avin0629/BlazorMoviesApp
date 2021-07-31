using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Server.Helpers
{
	public class InAppStorageService : IFileStorageService
	{
		private readonly IWebHostEnvironment environment;
		private readonly IHttpContextAccessor httpContextAccessor;

		public InAppStorageService(IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
		{
			this.environment = environment;
			this.httpContextAccessor = httpContextAccessor;
		}

		public Task DeleteFile(string fileRoute, string containerName)
		{
			string fileName = Path.GetFileName(fileRoute);
			string fileDirectory = Path.Combine(environment.WebRootPath, containerName, fileName);
			
			if (File.Exists(fileDirectory))
			{
				File.Delete(fileDirectory);
			}

			return Task.FromResult(0);
		}

		public async Task<string> EditFile(byte[] content, string extension, string containerName, string fileRoute)
		{
			if (!string.IsNullOrWhiteSpace(fileRoute))
			{
				await DeleteFile(fileRoute, containerName);
			}

			return await SaveFile(content, extension, containerName);
		}

		public async Task<string> SaveFile(byte[] content, string extension, string containerName)
		{
			string fileName = $"{Guid.NewGuid()}.{extension}";
			string folder = Path.Combine(environment.WebRootPath, containerName);

			if (!Directory.Exists(folder))
			{
				Directory.CreateDirectory(folder);
			}

			string savePath = Path.Combine(folder, fileName);
			await File.WriteAllBytesAsync(savePath, content);

			string containerUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
			var pathForDatabase = Path.Combine(containerUrl, containerName, fileName);

			return pathForDatabase;
		}
	}
}
