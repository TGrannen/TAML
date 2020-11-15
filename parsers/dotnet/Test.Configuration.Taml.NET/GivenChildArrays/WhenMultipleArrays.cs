using System.Collections.Generic;
using TAML.Microsoft.Extensions.Configuration;
using Xunit;

namespace Test.Configuration.Taml.NET.GivenChildArrays
{
	public class WhenMultipleArrays : BaseFixture
	{
		protected override string SampleFilename => "GivenChildArrays/childarrays.taml";

		[Fact]
		public void ShouldFindThreeArrayElements()
		{
			var dictionary = TamlConfigurationConverter.Convert(GetDocument());

			Assert.NotEmpty(dictionary);

			var expectedDictionary = new Dictionary<string, string>
			{
				{ "value1:0", "value12" },
				{ "value1:1", "value13" },
				{ "value1:2", "value14" },
				{ "value2:0", "value22" },
				{ "value2:1", "value23" },
				{ "value2:2", "value24" },
				{ "value3:0", "value32" },
				{ "value3:1", "value33" },
				{ "value3:2", "value34" },
			};

			foreach (var expected in expectedDictionary)
			{
				Assert.Contains(expected, dictionary);
			}
		}
	}
}
