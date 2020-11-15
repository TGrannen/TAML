using System.Collections.Generic;
using TAML.Microsoft.Extensions.Configuration;
using Xunit;

namespace Test.Configuration.Taml.NET.GivenKeyValuePairsWithArray
{
	public class WhenArrayFirst : BaseFixture
	{
		protected override string SampleFilename => "GivenKeyValuePairsWithArray/arrayfirst.taml";

		[Fact]
		public void ShouldFindTwoKeyValuePairs()
		{
			var dictionary = TamlConfigurationConverter.Convert(GetDocument());

			Assert.NotEmpty(dictionary);

			var expectedDictionary = new Dictionary<string, string>
			{
				{ "key1:0", "value1" },
				{ "key1:1", "value2" },
				{ "key", "value" },
			};

			foreach (var expected in expectedDictionary)
			{
				Assert.Contains(expected, dictionary);
			}
		}
	}
}
