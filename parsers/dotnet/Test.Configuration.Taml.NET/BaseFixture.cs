using System.IO;
using TAML;

namespace Test.Configuration.Taml.NET
{
	public abstract class BaseFixture
	{
		protected StreamReader Sample { get; }

		protected abstract string SampleFilename { get; }

		protected BaseFixture()
		{
			Sample = new StreamReader(File.OpenRead(SampleFilename));
		}

		protected TamlDocument GetDocument()
		{
			return Parser.Parse(Sample);
		}
	}
}
