using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace NbaOracle.Tests.Unit
{
    public class UnitBase
    {
        protected async Task<string> ReadEmbeddedResource(string name)
        {
            var resourceStream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream(name);

            if (resourceStream == null)
                throw new FileNotFoundException($"Embedded resource not found for name = {name}");

            using var reader = new StreamReader(resourceStream);
            return await reader.ReadToEndAsync();
        }
    }
}