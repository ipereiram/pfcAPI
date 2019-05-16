using PfcAPI.Models;
using PfcAPI.Utils.Global;
using PfcDataAccess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PfcAPI.Services
{
    public class DietaService
    {
        private PfcEntitiesModel pfcEntitiesModel = new PfcEntitiesModel();
       
        public List<Dieta> GetMyExpenses()
        {
            return pfcEntitiesModel.Dieta
                        .Where(d => d.NomUsuari == UserGlobal.usuari.Id).Include(d => d.EstatDieta)
                        .ToList();
        }

        public List<Dieta> GetPendingValidateExpenses()
        {
            return UserGlobal.usuari.IdRol == 1 || UserGlobal.usuari.IdRol == 3 ? 
                        pfcEntitiesModel.Dieta
                            .Where(d => d.Estat == 2).ToList() : null;
        }

        public List<Dieta> GetPendingPayExpenses()
        {
            return UserGlobal.usuari.IdRol == 1 || UserGlobal.usuari.IdRol == 4 ?
                        pfcEntitiesModel.Dieta
                            .Where(d => d.Estat == 5).ToList() : null;
        }

        public Dieta GetDieta(int id)
        {
            return pfcEntitiesModel.Dieta.FirstOrDefault(d => d.Id == id);
        }

        public void AddDieta(Dieta dieta)
        {
            Dieta d = new Dieta
            {
                Descripcio = dieta.Descripcio,
                NomUsuari = UserGlobal.usuari.Id,
                Data = dieta.Data,
                Import = dieta.Import,
                Tipus = dieta.Tipus,
                Estat = 1,
            };

            pfcEntitiesModel.Dieta.Add(d);
            pfcEntitiesModel.SaveChanges();            
            
        }
    }
}