using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace MyBGList.Controllers.v2
{
    [ApiController]
    [Route("/v{version:ApiVersion}/[controller]")]
    public class CodeOnDemandController : ControllerBase
    {
        [HttpGet("Test")]
        [ApiVersion("2.0")]
        [ResponseCache(NoStore = true)]
        [EnableCors("AnyOrigin_GetOnly")]
        public ContentResult Test()
        {
            return Content("<script>" +
            "window.alert('Your client supports JavaScript!" +
            "\\r\\n\\r\\n" +
            $"Server time (UTC): {DateTime.UtcNow.ToString("o")}" +
            "\\r\\n" +
            "Client time (UTC): ' + new Date().toISOString());" +
            "</script>" +
            "<noscript>Your client does not support JavaScript</noscript>"
            , "text/html"
            );
        }

        [HttpGet("Test2")]
        [ApiVersion("2.0")]
        [ResponseCache(NoStore = true)]
        [EnableCors("AnyOrigin_GetOnly")]
        public ContentResult Test2(int? addMinutes)
        {
            if (addMinutes > 0)
            {
                return Content("<script>" +
                        "window.alert('Your client supports JavaScript!" +
                        "\\r\\n\\r\\n" +
                        $"Server time (UTC): {DateTime.UtcNow.AddMinutes((double)addMinutes).ToString("o")}" +
                        "\\r\\n" +
                        "Client time (UTC): ' + new Date().toISOString());" +
                        "</script>" +
                        "<noscript>Your client does not support JavaScript</noscript>"
                        , "text/html"
                        );
            }
            else
            {
                return Content("<script>" +
                        "window.alert('Your client supports JavaScript!" +
                        "\\r\\n\\r\\n" +
                        $"Server time (UTC): {DateTime.UtcNow.ToString("o")}" +
                        "\\r\\n" +
                        "Client time (UTC): ' + new Date().toISOString());" +
                        "</script>" +
                        "<noscript>Your client does not support JavaScript</noscript>"
                        , "text/html"
                        );
            }
        }

        [HttpGet("Test2")]
        [ApiVersion("3.0")]
        [ResponseCache(NoStore = true)]
        [EnableCors("AnyOrigin_GetOnly")]
        public ContentResult Test3(int? minutesToAdd)
        {
            if (minutesToAdd > 0)
            {
                return Content("<script>" +
                        "window.alert('Your client supports JavaScript!" +
                        "\\r\\n\\r\\n" +
                        $"Server time (UTC): {DateTime.UtcNow.AddMinutes((double)minutesToAdd).ToString("o")}" +
                        "\\r\\n" +
                        "Client time (UTC): ' + new Date().toISOString());" +
                        "</script>" +
                        "<noscript>Your client does not support JavaScript</noscript>"
                        , "text/html"
                        );
            }
            else
            {
                return Content("<script>" +
                        "window.alert('Your client supports JavaScript!" +
                        "\\r\\n\\r\\n" +
                        $"Server time (UTC): {DateTime.UtcNow.ToString("o")}" +
                        "\\r\\n" +
                        "Client time (UTC): ' + new Date().toISOString());" +
                        "</script>" +
                        "<noscript>Your client does not support JavaScript</noscript>"
                        , "text/html"
                        );
            }
        }
    }
}
