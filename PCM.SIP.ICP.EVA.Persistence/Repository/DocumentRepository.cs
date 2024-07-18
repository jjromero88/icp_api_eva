using Microsoft.Extensions.Configuration;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.EVA.Domain.Entities;
using System.Text.Json;

namespace PCM.SIP.ICP.EVA.Persistence.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IConfiguration _configuration;

        public DocumentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<(string FileName, string Base64Content)> DownloadDocumentAsync(string categoryPath, string fileName)
        {
            try
            {
                var storagePath = GetStoragePath(categoryPath);
                var documentPath = Path.Combine(storagePath, fileName);

                if (!File.Exists(documentPath))
                {
                    throw new FileNotFoundException("El documento solicitado no fue encontrado.");
                }

                byte[] fileBytes = await File.ReadAllBytesAsync(documentPath);
                string base64Content = Convert.ToBase64String(fileBytes);

                return (fileName, base64Content);
            }
            catch (Exception ex)
            {
                throw new Exception($"DownloadDocumentAsync: {ex.Message}");
            }
        }

        public async Task<string> SaveDocumentAsync(string fileName, string base64Content, string category)
        {
            try
            {
                var storagePath = GetStoragePath(category);
                var documentPath = Path.Combine(storagePath, fileName);

                byte[] fileBytes = Convert.FromBase64String(base64Content);
                await File.WriteAllBytesAsync(documentPath, fileBytes);

                var document = new Document
                {
                    category = category,
                    filename = fileName,
                    extension = Path.GetExtension(fileName),
                    size = $"{fileBytes.Length / (1024 * 1024.0):F2} MB"
                };

                return JsonSerializer.Serialize(document);
            }
            catch (Exception ex)
            {
                throw new Exception($"SaveDocumentAsync: {ex.Message}");
            }
        }

        private string GetStoragePath(string category)
        {
            return _configuration[$"DocumentStorage:{category}"];
        }
    }
}
