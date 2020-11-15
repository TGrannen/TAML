using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace TAML.Microsoft.Extensions.Configuration
{
	public static class TamlConfigurationExtensions
	{
		public static IConfigurationBuilder AddTamlFile(this IConfigurationBuilder builder, string path)
		{
			return AddTamlFile(builder, provider: null, path: path, optional: false, reloadOnChange: false);
		}

		public static IConfigurationBuilder AddTamlFile(this IConfigurationBuilder builder, string path, bool optional)
		{
			return AddTamlFile(builder, provider: null, path: path, optional: optional, reloadOnChange: false);
		}

		public static IConfigurationBuilder AddTamlFile(this IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
		{
			return AddTamlFile(builder, provider: null, path: path, optional: optional, reloadOnChange: reloadOnChange);
		}

		public static IConfigurationBuilder AddTamlFile(this IConfigurationBuilder builder, IFileProvider? provider, string path, bool optional, bool reloadOnChange)
		{
			if (provider == null && Path.IsPathRooted(path))
			{
				provider = new PhysicalFileProvider(Path.GetDirectoryName(path));
				path = Path.GetFileName(path);
			}

			var source = new TamlConfigurationSource
			{
				FileProvider = provider,
				Path = path,
				Optional = optional,
				ReloadOnChange = reloadOnChange
			};
			builder.Add(source);
			return builder;
		}
	}
}
