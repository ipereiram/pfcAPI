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
                            .Where(d => d.Estat == 2)
                            .Include(d => d.EstatDieta)
                            .Include(d => d.TipusDieta)
                            .Include(d => d.Usuari).ToList() : null;
        }

        public List<Dieta> GetPendingPayExpenses()
        {
            return UserGlobal.usuari.IdRol == 1 || UserGlobal.usuari.IdRol == 4 ?
                        pfcEntitiesModel.Dieta
                            .Where(d => d.Estat == 5 || d.Estat == 3)
                            .Include(d => d.EstatDieta)
                            .Include(d => d.TipusDieta)
                            .Include(d => d.Usuari).ToList() : null;
        }

        public Dieta GetExpense(int id)
        {
            return pfcEntitiesModel.Dieta.FirstOrDefault(d => d.Id == id);
        }

        public void AddExpense(Dieta dieta)
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

        public void UpdateExpense(Dieta dieta)
        {            
            pfcEntitiesModel.Entry(dieta).State = EntityState.Modified;
            pfcEntitiesModel.SaveChanges();
        }

        public void SaveExpense(Dieta dieta)
        {
            dieta.Estat = 2;
            dieta.EstatDieta = new EstatDieta { Id = 2, Estat = "Guardat" };

            pfcEntitiesModel.Entry(dieta).State = EntityState.Modified;
            pfcEntitiesModel.SaveChanges();
        }

        public void AcceptExpense(Dieta dieta)
        {
            dieta.Estat = 3;
            dieta.EstatDieta = new EstatDieta { Id = 3, Estat = "Aprovat" };
            //pfcEntitiesModel.Dieta.Remove(dieta);
            pfcEntitiesModel.Entry(dieta).State = EntityState.Modified;
            pfcEntitiesModel.SaveChanges();
        }

        public void RefuseExpense(Dieta dieta)
        {
            dieta.Estat = 4;
            dieta.EstatDieta = new EstatDieta { Id = 4, Estat = "Refusat" };
            //pfcEntitiesModel.Dieta.Attach(dieta);
            //pfcEntitiesModel.Dieta.Remove(dieta);
            pfcEntitiesModel.Entry(dieta).State = EntityState.Modified;
            pfcEntitiesModel.SaveChanges();
        }

        public void SetPendingPayExpense(Dieta dieta)
        {
            dieta.Estat = 5;
            dieta.EstatDieta = new EstatDieta { Id = 5, Estat = "Pendent pagament" };

            pfcEntitiesModel.Entry(dieta).State = EntityState.Modified;
            pfcEntitiesModel.SaveChanges();
        }

        public void PayExpense(Dieta dieta)
        {
            dieta.Estat = 6;
            dieta.EstatDieta = new EstatDieta { Id = 6, Estat = "Pagat" };

            pfcEntitiesModel.Entry(dieta).State = EntityState.Modified;
            pfcEntitiesModel.SaveChanges();
        }
    }
}