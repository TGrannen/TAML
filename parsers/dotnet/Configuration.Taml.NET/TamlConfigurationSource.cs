using Microsoft.Extensions.Configuration;

namespace TAML.Microsoft.Extensions.Configuration
{
	public class TamlConfigurationSource : FileConfigurationSource
	{
		public override IConfigurationProvider Build(IConfigurationBuilder builder)
		{
			return new TamlConfigurationProvider(this);
		}
	}
}
