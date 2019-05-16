using PfcAPI.Services;
using PfcAPI.Utils.Global;
using PfcDataAccess;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PfcAPI.Controllers
{
    [RoutePrefix("Api/Usuari")]
    [EnableCors(origins: "http://localhost:8100", headers: "*", methods: "*", SupportsCredentials = true)]
    public class UsuariController : ApiController
    {
        protected UsuariService usuariService = new UsuariService();

        [HttpGet]
        [Route("ValidateUser")]
        public Usuari ValidateUser(string username, string pass)
        {
            try
            {
                UserGlobal.usuari = usuariService.ValidateUser(username, pass);
                return UserGlobal.usuari;
            }
            catch (Exception)
            {
                return null;
            }       
            
        }
    }
}
