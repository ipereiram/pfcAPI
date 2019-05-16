using PfcAPI.Models;
using PfcDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PfcAPI.Services
{
    public class EstatDietaService
    {
        private PfcEntitiesModel pfcEntitiesModel = new PfcEntitiesModel();

        public EstatDieta GetEstatDietaById(int id)
        {
            return pfcEntitiesModel.EstatDieta.FirstOrDefault(d => d.Id == id);
        }
    }
}