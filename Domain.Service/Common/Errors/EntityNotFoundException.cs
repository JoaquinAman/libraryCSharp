using Domain.Service.Common.Errors;
using System.Net;
using System.Xml.Linq;

namespace Domain.Service.Common.Errors
{
    public class EntityNotFoundException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        public string ErrorMessage => "Entity not found!";
    }
}