using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Domain.Model;
using Domain.Service.Common.Errors;

namespace BackendLibrary.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public ActionResult<ResponseDto> Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception is IServiceException serviceException)
            {
                Response.Headers.Add("Status-Code", ((int)serviceException.StatusCode).ToString());

                var responseServiceException = new ResponseDto
                {
                    Response = serviceException.ErrorMessage
                };

                return StatusCode((int)serviceException.StatusCode, responseServiceException);
            }

            return Problem();
        }

    }
}