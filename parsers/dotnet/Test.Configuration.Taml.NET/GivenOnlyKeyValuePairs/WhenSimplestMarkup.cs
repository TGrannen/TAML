using System.Collections.Generic;
using TAML.Microsoft.Extensions.Configuration;
using Xunit;

namespace Test.Configuration.Taml.NET.GivenOnlyKeyValuePairs
{
	public class WhenSimplestMarkup : BaseFixture
	{
		protected override string SampleFilename => "GivenOnlyKeyValuePairs/simple.taml";

		[Fact]
		public void ShouldFindTwoKeyValuePairs()
		{
			var dictionary = TamlConfigurationConverter.Convert(GetDocument());

			Assert.NotEmpty(dictionary);

			var expectedDictionary = new Dictionary<string, string>
			{
				{ "key1", "value1" },
				{ "key2", "value2" },
			};

			foreach (var expected in expectedDictionary)
			{
				Assert.Contains(expected, dictionary);
			}
		}
	}
}
