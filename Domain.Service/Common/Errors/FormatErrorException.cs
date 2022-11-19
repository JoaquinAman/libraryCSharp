using System.Net;

namespace Domain.Service.Common.Errors
{
    public class FormatErrorException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public string ErrorMessage => "Invalid Format!";

    }
}
