using PfcAPI.Models;
using PfcDataAccess;
using System.Collections.Generic;
using System.Linq;

namespace PfcAPI.Services
{
    public class TipusDietaService
    {
        private PfcEntitiesModel pfcEntitiesModel = new PfcEntitiesModel();

        public List<TipusDieta> GetAllTipusDieta()
        {
            return pfcEntitiesModel.TipusDieta.ToList();
        }
    }
}