using Microsoft.Extensions.Configuration;
using Microsoft.Reporting.NETCore;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Infraestructure.Services.Reports;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services
{
    public class ReportService : IReportService
    {
        private readonly IConfiguration _configuration;

        public ReportService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<(string FileName, string Base64Content)> GenerateReportAsync(string reportFormat, string reportPath, List<ProfesionResponse> profesiones)
        {
            try
            {
                string rdlcReportName = "ReptPrueba.rdlc";

                // Ruta al archivo RDLC
                var storagePath = GetReportPath(reportPath);
                var path = Path.Combine(storagePath, rdlcReportName);

                // Verificar si el archivo existe
                if (!File.Exists(path))
                    throw new FileNotFoundException($"El archivo RDLC {rdlcReportName} no pudo ser ubicado en el directorio.", path);

                // Cargar el archivo RDLC como un stream
                using var reportDefinition = File.OpenRead(path);

                // Crear el reporte
                var report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);

                // Configurar los datos y parámetros del reporte
                report.DataSources.Add(new ReportDataSource("ProfesionDataSet", profesiones)); // Asegúrate de que el nombre de la fuente de datos coincida con el definido en el RDLC
                //report.SetParameters(new[] { new ReportParameter("Parameter1", "Parameter value") }); // Configura tus parámetros si es necesario

                // Renderizar el reporte a PDF
                byte[] reportBytes = report.Render(reportFormat);

                // Conert report to string base64 
                string base64Content = Convert.ToBase64String(reportBytes);

                // Generar un nombre de archivo único con GUID y extensión adecuada
                string generatedFileName = ReportUtils.GenerateFileNameDate("profesiones",reportFormat);

                return (generatedFileName, base64Content);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error al generar el reporte: {ex.Message}", ex);
            }

        }

        private string GetReportPath(string category)
        {
            return _configuration[$"ReportSettings:{category}"];
        }
    }
}
