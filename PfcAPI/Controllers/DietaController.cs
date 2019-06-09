using PfcDataAccess;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using PfcAPI.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PfcAPI.Controllers
{
    [RoutePrefix("Api/Dieta")]
    [EnableCors(origins: "http://localhost:8100", headers: "*", methods: "*", SupportsCredentials = true)]
    public class DietaController : ApiController
    {
        protected DietaService dietaService = new DietaService();
        protected TipusDietaService tipusDietaService = new TipusDietaService();
        protected EstatDietaService estatDietaService = new EstatDietaService();

        [HttpGet]
        [Route("GetMyExpenses")]
        public IEnumerable<Dieta> GetMyExpenses()
        {
            try
            {
                List<Dieta> dietas = dietaService.GetMyExpenses();
                return dietas;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        [HttpGet]
        [Route("GetPendingValidateExpenses")]
        public IEnumerable<Dieta> GetPendingValidateExpenses()
        {
            try
            {
                List<Dieta> dietas = dietaService.GetPendingValidateExpenses();
                return dietas;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetPendingPayExpenses")]
        public IEnumerable<Dieta> GetPendingPayExpenses()
        {
            try
            {
                List<Dieta> dietas = dietaService.GetPendingPayExpenses();
                return dietas;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetDieta/{id}")]
        public Dieta GetDieta(int id)
        {
            try
            {
                Dieta dieta = dietaService.GetExpense(id);
                return dieta;
            }
            catch (Exception)
            {
                return null;
            }
        }        

        [HttpGet]
        [Route("GetEstatDietaById")]
        public EstatDieta GetEstatDietaById(int id)
        {
            try
            {
                EstatDieta estatDieta = estatDietaService.GetEstatDietaById(id);
                return estatDieta;
            }
            catch (Exception)
            {
                return null;            
            }
        }

        [HttpGet]
        [Route("GetAllTipusDieta")]
        public IEnumerable<TipusDieta> GetAllTipusDieta()
        {
            try
            {
                List<TipusDieta> tipusDietas = tipusDietaService.GetAllTipusDieta();
                return tipusDietas;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("AddDieta")]
        public void AddDieta([FromBody] JObject json)
        {
            try
            {
                Dieta request = JsonConvert.DeserializeObject<Dieta>(json.ToString());
                dietaService.AddExpense(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateDieta")]
        public void UpdateDieta([FromBody] JObject json)
        {
            try
            {
                Dieta request = JsonConvert.DeserializeObject<Dieta>(json.ToString());
                dietaService.UpdateExpense(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost]
        [Route("SaveDieta")]
        public void SaveDieta([FromBody] JObject json)
        {
            try
            {
                Dieta request = JsonConvert.DeserializeObject<Dieta>(json.ToString());
                dietaService.SaveExpense(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost]
        [Route("AcceptDieta")]
        public void AcceptDieta([FromBody] JObject json)
        {
            try
            {
                Dieta request = JsonConvert.DeserializeObject<Dieta>(json.ToString());
                dietaService.AcceptExpense(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost]
        [Route("RefuseDieta")]
        public void RefuseDieta([FromBody] JObject json)
        {
            try
            {
                Dieta request = JsonConvert.DeserializeObject<Dieta>(json.ToString());
                dietaService.RefuseExpense(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost]
        [Route("SetPendingPayDieta")]
        public void SetPendingPayDieta([FromBody] JObject json)
        {
            try
            {
                Dieta request = JsonConvert.DeserializeObject<Dieta>(json.ToString());
                dietaService.SetPendingPayExpense(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost]
        [Route("PayDieta")]
        public void PayDieta([FromBody] JObject json)
        {
            try
            {
                Dieta request = JsonConvert.DeserializeObject<Dieta>(json.ToString());
                dietaService.PayExpense(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
