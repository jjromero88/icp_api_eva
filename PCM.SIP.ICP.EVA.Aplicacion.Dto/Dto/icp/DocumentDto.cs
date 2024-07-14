using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Dto
{
    public class DocumentDto
    {
        public string? category { get; set; }
        public string? filename { get; set; }
        public string? extension { get; set; }
        public string? size { get; set; }
        public string? base64content { get; set; }
    }
    public class DocumentResponseDto
    {
        public string? category { get; set; }
        public string? filename { get; set; }
        public string? extension { get; set; }
        public string? size { get; set; }
    }
    public class UploadDocumentRequestDto
    {
        public string? filename { get; set; }
        public string? base64content { get; set; }
        public string? category { get; set; }
    }
    public class DocumentInsertRequestDto
    {
        public string? filename { get; set; }
        public string? base64content { get; set; }
    }
    public class DownloadDocumentRequestDto
    {
        public string? category { get; set; }
        public string? filename { get; set; }
        public string? extension { get; set; }
    }

    public class DownloadDocumentResponseDto
    {
        public string? filename { get; set; }
        public string? extension { get; set; }
        public string? base64content { get; set; }
    }
}
