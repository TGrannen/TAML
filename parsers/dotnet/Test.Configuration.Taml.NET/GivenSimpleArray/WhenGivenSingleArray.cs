using System.Collections.Generic;
using TAML.Microsoft.Extensions.Configuration;
using Xunit;

namespace Test.Configuration.Taml.NET.GivenSimpleArray
{
	public class WhenGivenSingleArray : BaseFixture
	{
		protected override string SampleFilename => "GivenSimpleArray/simple.taml";

		[Fact]
		public void ShouldFindAnArray()
		{
			var dictionary = TamlConfigurationConverter.Convert(GetDocument());

			Assert.NotEmpty(dictionary);

			var expectedDictionary = new Dictionary<string, string>
			{
				{ "key:0", "value1" },
				{ "key:1", "value2" },
				{ "key:2", "value3" },
			};

			foreach (var expected in expectedDictionary)
			{
				Assert.Contains(expected, dictionary);
			}
		}
	}
}
