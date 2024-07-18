using Microsoft.Extensions.Configuration;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IAppLogger<DocumentService> _logger;

        public DocumentService(IUnitOfWork unitOfWork, IConfiguration configuration, IAppLogger<DocumentService> logger)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<PcmResponse> UploadDocumentAsync(UploadDocumentRequestDto request)
        {
            try
            {
                var result = await _unitOfWork.Document.SaveDocumentAsync(request.filename, request.base64content, request.category);

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return !string.IsNullOrEmpty(result) ? ResponseUtil.Ok(result, TransactionMessage.SaveSuccess) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> DownloadDocumentAsync(DownloadDocumentRequestDto request)
        {
            try
            {
                var (fileName, base64Content) = await _unitOfWork.Document.DownloadDocumentAsync(request.category, request.filename);

                var result = new DownloadDocumentResponseDto
                {
                    filename = fileName,
                    extension = request.extension,
                    base64content = base64Content
                };

                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return result != null ? ResponseUtil.Ok(result, TransactionMessage.QuerySuccess) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }       
    }
}
