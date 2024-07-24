using Microsoft.Extensions.Configuration;
using Microsoft.Reporting.NETCore;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services
{
    public class ReportService : IReportService
    {
        private readonly IConfiguration _configuration;

        public ReportService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<byte[]> GenerateReportAsync(string reportName, string reportPath)
        {
            try
            {

                // Ruta al archivo RDLC
                var storagePath = GetReportPath(reportPath);
                var path = Path.Combine(storagePath, reportName);

                // Verificar si el archivo existe
                if (!File.Exists(path))
                    throw new FileNotFoundException($"El archivo RDLC {reportName} no se encuentra.", path);

                // Cargar el archivo RDLC como un stream
                using var reportDefinition = File.OpenRead(path);

                // Crear el reporte
                var report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);

                // Configurar los datos y parámetros del reporte
                //report.DataSources.Add(new ReportDataSource("DataSourceName", dataSource)); // Asegúrate de que el nombre de la fuente de datos coincida con el definido en el RDLC
                //report.SetParameters(new[] { new ReportParameter("Parameter1", "Parameter value") }); // Configura tus parámetros si es necesario

                // Renderizar el reporte a PDF
                byte[] pdf = report.Render("PDF");

                return pdf;
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
