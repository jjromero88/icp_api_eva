using PCM.SIP.ICP.EVA.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services.Reports
{
    public static class ReportUtilData
    {
        public static string tituloReporteResultadoPorSector(List<ResultadoPorSectorComponente>? data)
        {
            if (data == null)
                return string.Empty;

            if (data.Count < 1)
                return string.Empty;

            var etapasUnicas = data
             .Select(c => c.etapa_nombre)
             .Distinct()
             .OrderBy(etapa => etapa)
             .Select(e => e?.Split(' ').Last())
             .ToList();

            string titulo;

            if (etapasUnicas.Count == 1)
            {
                titulo = $"Resultado por componentes (Etapa {etapasUnicas.First()})";
            }
            else
            {
                string etapasConcatenadas = string.Join(", ", etapasUnicas.Take(etapasUnicas.Count - 1)) +
                                            $" y {etapasUnicas.Last()}";
                titulo = $"Resultado por componentes (Etapas {etapasConcatenadas})";
            }

            return titulo;
        }

        public static (string interpretacion, string interpretacionTotales, string textoInformativo) interpretacionReporteResultadoPorSectorAsync(
            List<ResultadoPorSectorComponente>? data,
            List<ResultadoPorSectorTotal>? dataTotal)
        {
            // Verificar si los datos son nulos o vacíos
            if (data == null || data.Count < 1)
                return (string.Empty, string.Empty, string.Empty);

            if (dataTotal == null || dataTotal.Count < 1)
                return (string.Empty, string.Empty, string.Empty);

            // Determinar las etapas únicas y formatearlas
            var etapasUnicas = data
                .Select(c => c.etapa_nombre)
                .Distinct()
                .OrderBy(etapa => etapa)
                .Select(e => e?.Split(' ').Last())  // Obtener solo el número de la etapa
                .ToList();

            string etapasFormateadas = etapasUnicas.Count == 1
                ? $"Etapa {etapasUnicas.First()}"
                : $"Etapas {string.Join(", ", etapasUnicas.Take(etapasUnicas.Count - 1))} y {etapasUnicas.Last()}";

            // Calcular el promedio de resultados por etapa
            var promediosPorEtapa = data
                .GroupBy(c => c.etapa_nombre)
                .Select(g => new
                {
                    EtapaNombre = g.Key,
                    Promedio = g.Average(c => c.resultado)
                })
                .OrderBy(e => e.EtapaNombre)
                .ToList();

            // Calcular el ICP sectorial como el promedio de los promedios
            decimal? icpSectorial = promediosPorEtapa.Average(e => e.Promedio);

            // Formar la interpretación de los promedios
            string promediosInterpretacion = string.Join(", ", promediosPorEtapa.Select((e, i) =>
            {
                return i == promediosPorEtapa.Count - 1 && i > 0
                    ? $"y de {e.Promedio:F2} en la etapa {etapasUnicas[i]}"
                    : $"de {e.Promedio:F2} en la etapa {etapasUnicas[i]}";
            }));

            // Formar la interpretación completa
            string interpretacion = $"Las entidades del sector fueron evaluadas en las {etapasFormateadas} del Modelo de Integridad; " +
                                    $"obteniendo un avance promedio {promediosInterpretacion}, logrando un ICP sectorial de {icpSectorial:F2}.";



            // **Síntesis** - Calcular la síntesis basada en la data total de resultados por componente
            var maxComponentes = dataTotal
                .Where(d => d.resultado == dataTotal.Max(c => c.resultado))
                .Select(c => c.componente_descripcion)
                .ToList();

            var minComponentes = dataTotal
                .Where(d => d.resultado == dataTotal.Min(c => c.resultado))
                .Select(c => c.componente_descripcion)
                .ToList();

            string maxComponentesStr = string.Join(", ", maxComponentes);
            string minComponentesStr = string.Join(", ", minComponentes);

            // Formar la síntesis completa
            string interpretacionTotales = $"Los componentes que mostraron un mayor avance fueron: {maxComponentesStr}. " +
                              $"El componente que presentó un menor avance ha sido {minComponentesStr}.";

            // Formar el texto informativo
            string textoInformativo = "El ICP sectorial es el resultado del promedio del ICP de cada entidad que " +
                "integra el sector. En ese sentido, se recomienda al ministerio, que lidera el sector, impulsar una " +
                "estrategia para que en la evaluación anual todas las entidades adscritas superen los resultados obtenidos.";

            return (interpretacion, interpretacionTotales, textoInformativo);
        }
    }
}
