using System.Collections.Generic;

namespace TAML.Microsoft.Extensions.Configuration
{
	public static class TamlConfigurationConverter
	{
		public static IDictionary<string, string> Convert(TamlDocument document)
		{
			var dictionary = new Dictionary<string, string>();

			foreach (var keyValuePair in document.KeyValuePairs)
			{
				var values = Convert(null, keyValuePair.Key, keyValuePair);
				foreach (var value in values)
				{
					dictionary.Add(value.Item1, value.Item2);
				}
			}

			return dictionary;
		}

		private static IEnumerable<(string, string)> Convert(string? root, string key, object value)
		{
			List<(string, string)> values = new List<(string, string)>();
			if (value is TamlArray array)
			{
				values.AddRange(ConvertArray(GenerateKey(root, key), array));
			}
			else if (value is TamlKeyValuePair pair)
			{
				values.AddRange(ConvertKeyValue(root, pair));
			}
			else if (value is TamlValue tamlValue)
			{
				values.Add(ConvertNonArray(root, key, tamlValue));
			}

			return values;
		}

		private static IEnumerable<(string, string)> ConvertArray(string? root, TamlArray array)
		{
			int count = 0;
			List<(string, string)> values = new List<(string, string)>();
			foreach (var arrayValue in array)
			{
				values.AddRange(Convert(root, count.ToString(), arrayValue));
				count++;
			}

			return values;
		}

		private static IEnumerable<(string, string)> ConvertKeyValue(string? root, TamlKeyValuePair pair)
		{
			if (pair.Value is TamlArray || pair.Value is TamlKeyValuePair)
			{
				return Convert(root, pair.Key, pair.Value);
			}
			return new[] { ConvertNonArray(root, pair.Key, pair.Value) };
		}

		private static (string, string) ConvertNonArray(string? root, string key, TamlValue value)
		{
			string valueStr = (value is TamlKeyValuePair pair ? pair.Value?.ToString() : value) ?? string.Empty;
			return (GenerateKey(root, key), valueStr);
		}

		private static string GenerateKey(string? root, string key) => string.IsNullOrEmpty(root) ? key : $"{root}:{key}";
	}
}
