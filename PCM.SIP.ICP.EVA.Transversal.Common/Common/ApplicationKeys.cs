using Microsoft.Extensions.Configuration;

namespace PCM.SIP.ICP.EVA.Transversal.Common
{
    public static class ApplicationKeys
    {

        private static IConfigurationRoot _config;
        static ApplicationKeys()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            _config = builder.Build();
        }

        public static string CodigoSectorista => _config["IcpProfiles:CodSectorista"] ?? string.Empty;
        public static string CodigoSupervisor => _config["IcpProfiles:CodSupervisor"] ?? string.Empty;
        public static string CodigoEvaluador => _config["IcpProfiles:CodEvaluador"] ?? string.Empty;
    }
}
