using BinaryTreeTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BinaryTreeTest.Service
{
	internal static class JsonService
	{
		static Exception FailedReadingJsonFileException = new Exception("error reading Json file");
		static string jsonDefensePath = "../../../JsonFiles/Defenses.Json";
		static string jsonThreatsPath = "../../../JsonFiles/Threats.Json";
		static async Task<T?> ReadFromJsonAsync<T>(string filePath, JsonSerializerOptions options = null)
		{
			try
			{
				options ??= new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				T? data = JsonSerializer.Deserialize<T>(
					File.OpenRead(filePath),
					options
				);
				return data;
			}
			catch (Exception ex)
			{
				return default;
			}
		}


		static public async Task<List<Defense>> GetAllDefences() =>
			await ReadFromJsonAsync<List<Defense>>(jsonDefensePath)
			?? throw FailedReadingJsonFileException;
		static public async Task<List<Threat>> GetAllThreats() =>
			await ReadFromJsonAsync<List<Threat>>(jsonThreatsPath)
			?? throw FailedReadingJsonFileException;






	}
}
