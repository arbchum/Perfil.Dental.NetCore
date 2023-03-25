using System.Collections.Generic;
using System.Net;

namespace Perfil.Dental.NetCore.Application.Contracts.Responses
{
    public class ApiResponse<TResponse>
    {
        public TResponse Response { get; set; }
        public bool Success { get; set; }
        public List<ErrorResponse> Errors { get; set; } = new List<ErrorResponse>();
    }

    public class ErrorResponse
    {
        public HttpStatusCode? Code { get; set; }
        public string Message { get; set; }
    }
}
