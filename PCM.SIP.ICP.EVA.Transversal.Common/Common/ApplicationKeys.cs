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
        public static int medioVerificacionDocumentAbsoluteExpiration => int.TryParse(_config["CacheConfiguration:DocumentoMedioVerificacion:absoluteExpiration"], out var value) ? value : 120;
        public static int medioVerificacionDocumentSlidingExpiration => int.TryParse(_config["CacheConfiguration:DocumentoMedioVerificacion:slidingExpiration"], out var value) ? value : 60;

    }
}
