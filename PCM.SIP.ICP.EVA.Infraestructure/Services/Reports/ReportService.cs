using Microsoft.Extensions.Configuration;
using Microsoft.Reporting.NETCore;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Domain.Entities;
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

        // Tipo de reporte: AGRUPADO POR ETAPAS
        public async Task<byte[]> ReporteResultadoEtapaAsync(ReportResultadosEtapaRequest request)
        {
            try
            {
                string reportFormat = request.format ?? string.Empty;
                string reportsPath = "ReportsPath";
                string rdlcReportName = "RptResultadosEtapa.rdlc";

                var data = request.data ?? new List<ResultadosEtapa>();

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

                // Crear la lista de parámetros
                var reportParameters = new List<ReportParameter>
                {
                    new ReportParameter("InterpretacionResultados", request.interpretacion)
                };

                // Establecer los parámetros en el reporte
                report.SetParameters(reportParameters);

                var listaConvertida = new List<ResultadosEtapaGroup>();

                foreach (var resultado in data)
                {
                    if (resultado.avance.HasValue)
                    {
                        listaConvertida.Add(new ResultadosEtapaGroup
                        {
                            Etapa = resultado.etapa,
                            Tipo = "Avance",
                            Valor = resultado.avance.Value
                        });
                    }

                    if (resultado.brecha.HasValue)
                    {
                        listaConvertida.Add(new ResultadosEtapaGroup
                        {
                            Etapa = resultado.etapa,
                            Tipo = "Brecha",
                            Valor = resultado.brecha.Value
                        });
                    }
                }

                // Configurar los datos y parámetros del reporte
                report.DataSources.Add(new ReportDataSource("DsResultadosEtapa", listaConvertida));

                // Renderizar el reporte a PDF
                byte[] reportBytes = report.Render(reportFormat);

                return reportBytes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error al generar el reporte: {ex.Message}", ex);
            }
        }

        // Tipo de reporte: AGRUPADO POR GRUPO DE ENTIDAD
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

        // Tipo de reporte: AGRUPADO POR ETAPAS Y COMPONENTES
        public async Task<byte[]> ReporteEtapaComponenteAsync(ReportEtapasComponenteRequest request)
        {
            try
            {
                string reportFormat = request.format ?? string.Empty;
                string reportsPath = "ReportsPath";
                string rdlcReportName = "RptEtapaComponente.rdlc";

                var data = request.data ?? new List<EtapasComponente>();

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

                // Crear la lista de parámetros
                var reportParameters = new List<ReportParameter>
                {
                    new ReportParameter("InterpretacionResultados", request.interpretacion)
                };

                // Establecer los parámetros en el reporte
                report.SetParameters(reportParameters);

                // Configurar los datos y parámetros del reporte
                report.DataSources.Add(new ReportDataSource("DsEtapaComponente", data));

                // Renderizar el reporte a PDF
                byte[] reportBytes = report.Render(reportFormat);


                return reportBytes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error al generar el reporte: {ex.Message}", ex);
            }
        }

        // Tipo de reporte: RESULTADOS POR COMPONENTE
        public async Task<byte[]> ReporteResultadoPorSectorAsync(ResultadoPorSectorResponse request)
        {
            try
            {
                string reportFormat = "PDF";
                string reportsPath = "ReportsPath";
                string rdlcReportName = "RptResultadosPorSector.rdlc";

                var dataTotal = request.resultadoporsector_total;
                var dataComponente = request.resultadoporsector_componente;

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

                // Calcular el número de etapas
                int uniqueEtapaCount = dataComponente == null ? 0 : dataComponente.Select(d => d.etapa_nombre).Distinct().Count();

                // obtenemos el titulo del grafico de resultados totales
                string tituloResultadosComponente = ReportUtilData.tituloReporteResultadoPorSector(dataComponente);

                // obtenemos la interpretacion
                var(interpretacion, interpretacionTotales, textoInformativo) = ReportUtilData.interpretacionReporteResultadoPorSectorAsync(dataComponente, dataTotal);

                // Crear la lista de parámetros
                var reportParameters = new List<ReportParameter>
                {
                    new ReportParameter("NombreSector", request.sector_nombre ?? string.Empty),
                    new ReportParameter("InterpretacionResultados", interpretacion),
                    new ReportParameter("InterpretacionResultadosTotal", interpretacionTotales),
                    new ReportParameter("InterpretacionResultadosInformativo", textoInformativo),
                    new ReportParameter("NumeroEtapas", uniqueEtapaCount.ToString()),
                    new ReportParameter("TituloResultadosComponente", tituloResultadosComponente)
                };

                // Establecer los parámetros en el reporte
                report.SetParameters(reportParameters);

                // Configurar los datos y parámetros del reporte
                report.DataSources.Add(new ReportDataSource("DsResultadoPorSectorTotal", dataTotal));
                report.DataSources.Add(new ReportDataSource("DsResultadoPorSectorComponente", dataComponente));

                // Renderizar el reporte a PDF
                byte[] reportBytes = report.Render(reportFormat);


                return reportBytes;
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
