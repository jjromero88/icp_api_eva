using Microsoft.Extensions.Configuration;
using Microsoft.Reporting.NETCore;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Infraestructure.Services.Reports;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services
{
    public class ReportService : IReportService
    {
        private readonly IConfiguration _configuration;

        public ReportService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<byte[]> ReporteGrupoEntidadesAsync(ReportGrupoEntidadesRequest request)
        {
            try
            {
                string reportFormat = request.format ?? string.Empty;
                string reportsPath = "ReportsPath";
                string rdlcReportName = "RptGrupoEntidades.rdlc";

                var data = request.data ?? new List<GrupoEntidades>();

                // Ruta al archivo RDLC
                var storagePath = GetReportPath(reportsPath);
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
                report.DataSources.Add(new ReportDataSource("DsGrupoEntidades", data));

                // Calcular el número de elementos únicos en el campo etapa_nombre
                int uniqueEtapaCount = data.Select(d => d.etapa_nombre).Distinct().Count();

                // Crear la lista de parámetros
                var reportParameters = new List<ReportParameter>
                {
                    new ReportParameter("UniqueEtapaCount", uniqueEtapaCount.ToString()),
                    new ReportParameter("TituloReporte", request.titulo),
                    new ReportParameter("InterpretacionResultados", request.interpretacion)
                };

                // Establecer los parámetros en el reporte
                report.SetParameters(reportParameters);

                // Renderizar el reporte a PDF
                byte[] reportBytes = report.Render(reportFormat);

     
                return reportBytes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error al generar el reporte: {ex.Message}", ex);
            }
        }

        public async Task<(string FileName, string Base64Content)> ReporteTotalEntidadesAsync(string reportFormat, List<TotalEntidadesrequest> data)
        {
            try
            {
                string reportsPath = "ReportsPath";
                string rdlcReportName = "RptTotalEntidades.rdlc";

                // Ruta al archivo RDLC
                var storagePath = GetReportPath(reportsPath);
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
                report.DataSources.Add(new ReportDataSource("DsTotalEntidades", data));

                // Renderizar el reporte a PDF
                byte[] reportBytes = report.Render(reportFormat);

                // Conert report to string base64 
                string base64Content = Convert.ToBase64String(reportBytes);

                // Generar un nombre de archivo único con GUID y extensión adecuada
                string generatedFileName = ReportUtils.GenerateFileNameDate("TotalEntidades", reportFormat);

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
