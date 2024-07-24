using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services.Reports
{
    public static class ReportUtils
    {
        public static string GenerateFileName(string reportFormat)
        {
            string fileExtension = getFileExtension(reportFormat);
            string generatedFileName = $"{Guid.NewGuid()}{fileExtension}";

            return generatedFileName;
        }

        public static string GenerateFileNameDate(string prefijo, string reportFormat)
        {
            string fileExtension = getFileExtension(reportFormat);
            string timestamp = DateTime.Now.ToString("ddMMyyyyHHmmssfff");
            string generatedFileName = $"{prefijo.Trim().ToUpper()}-{timestamp}{fileExtension}";

            return generatedFileName;
        }

        private static string getFileExtension(string reportFormat)
        {
            return reportFormat.ToLower() switch
            {
                "pdf" => ".pdf",
                "word" => ".docx",
                "excel" => ".xlsx",
                _ => ".dat" // default extension if format is not recognized
            };
        }
    }
}
