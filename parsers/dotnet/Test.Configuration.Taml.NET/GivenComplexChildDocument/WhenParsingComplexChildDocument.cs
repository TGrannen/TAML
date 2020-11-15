using System.Collections.Generic;
using TAML.Microsoft.Extensions.Configuration;
using Xunit;

namespace Test.Configuration.Taml.NET.GivenComplexChildDocument
{
	public class WhenParsingComplexChildDocument : BaseFixture
	{
		protected override string SampleFilename => "GivenComplexChildDocument/sample1.taml";

		[Fact]
		public void ShouldHaveTopLevelArrayKeys()
		{
			var dictionary = TamlConfigurationConverter.Convert(GetDocument());

			Assert.NotEmpty(dictionary);

			var expectedDictionary = new Dictionary<string, string>
			{
				{ "root:key1", "value1" },
				{ "root:key2", "value2" },
			};

			foreach (var expected in expectedDictionary)
			{
				Assert.Contains(expected, dictionary);
			}
		}

		[Fact]
		public void ShouldHaveArrayUnderTopLevelArray()
		{
			var dictionary = TamlConfigurationConverter.Convert(GetDocument());

			Assert.NotEmpty(dictionary);

			var expectedDictionary = new Dictionary<string, string>
			{
				{ "root:key3:0", "item1" },
				{ "root:key3:1", "item2" },
				{ "root:key3:2", "item3" },
			};

			foreach (var expected in expectedDictionary)
			{
				Assert.Contains(expected, dictionary);
			}
		}

		[Fact]
		public void ShouldHaveKeysUnderNestedArray()
		{
			var dictionary = TamlConfigurationConverter.Convert(GetDocument());

			Assert.NotEmpty(dictionary);

			var expectedDictionary = new Dictionary<string, string>
			{
				{ "root:key3:item4:key41", "value41" },
				{ "root:key3:item4:key42", "value42" },
				{ "root:key3:item4:key43", "value43" },
				{ "root:key3:item4:key44", "value44" },
			};

			foreach (var expected in expectedDictionary)
			{
				Assert.Contains(expected, dictionary);
			}
		}
	}
}
