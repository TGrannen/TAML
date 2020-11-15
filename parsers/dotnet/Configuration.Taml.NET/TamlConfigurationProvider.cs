using Microsoft.Extensions.Configuration;
using System.IO;

namespace TAML.Microsoft.Extensions.Configuration
{
	public class TamlConfigurationProvider : FileConfigurationProvider
	{
		public TamlConfigurationProvider(TamlConfigurationSource source) : base(source)
		{
		}

		public override void Load(Stream stream)
		{
			var document = Parser.Parse(new StreamReader(stream));
			Data = TamlConfigurationConverter.Convert(document);
		}
	}
}
