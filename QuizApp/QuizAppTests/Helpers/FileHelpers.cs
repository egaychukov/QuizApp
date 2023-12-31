﻿using System.Text;
using System.Text.Json;

namespace QuizAppTests.Helpers
{
    internal static class FileHelpers
    {
        private const string ResponseContentDirectory = "TestResponseContent";

        public static T GetEntityFromJson<T>(string jsonFileName)
        {
            var jsonFileContent = GetResponseContent(jsonFileName);
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
            return JsonSerializer.Deserialize<T>(jsonFileContent, options);
        }

        public static string GetResponseContent(string contentFileName)
        {
            var contentFilePath = Path.Combine($"{ResponseContentDirectory}", $"{contentFileName}.json");
            return File.ReadAllText(contentFilePath);
        }
    }
}
