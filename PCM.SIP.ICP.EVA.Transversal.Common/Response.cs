using FluentValidation.Results;

namespace PCM.SIP.ICP.EVA.Transversal.Common
{
    public class Response<T> : Response
    {
        public T Data { get; set; }
    }

    public class Response
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
