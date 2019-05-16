using PfcAPI.Utils.Global;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PfcAPI.ActionFilters
{
    public class UsuariActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ControllerContext.Request.RequestUri.AbsolutePath != "/Api/Usuari/ValidateUser" 
                && UserGlobal.usuari == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
        }
    }
}
