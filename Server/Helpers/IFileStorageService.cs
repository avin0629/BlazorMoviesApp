﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMoviesApp.Server.Helpers
{
	public interface IFileStorageService
	{
		Task<string> SaveFile(byte[] content, string extension, string containerName);

		Task<string> EditFile(byte[] content, string extension, string containerName, string fileRoute);

		Task DeleteFile(string fileRoute, string containerName);
	}
}
