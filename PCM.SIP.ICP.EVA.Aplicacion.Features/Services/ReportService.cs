using Microsoft.Extensions.Options;
using Microsoft.Reporting.NETCore;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class ReportService : IReportService
    {
        private readonly string _reportsPath;

        public ReportService(IOptions<ReportSettings> options)
        {
            _reportsPath = options.Value.ReportsPath;
        }

        public async Task<byte[]> GenerateReportAsync(string reportName)
        {
            try
            {
                // Ruta al archivo RDLC
                var path = Path.Combine("C:/Users/JUANJO/source/repos/PCM/ICP/icp_api_eva/PCM.SIP.ICP.EVA.Api/wwwroot/Reports", reportName);

                // Verificar si el archivo existe
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"El archivo RDLC {reportName} no se encuentra.", path);
                }

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
    }
}
