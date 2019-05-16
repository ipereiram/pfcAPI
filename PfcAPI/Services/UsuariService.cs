using PfcAPI.Models;
using PfcDataAccess;
using System.Linq;

namespace PfcAPI.Services
{
    public class UsuariService
    {
        private PfcEntitiesModel pfcEntitiesModel = new PfcEntitiesModel();

        public Usuari ValidateUser(string username, string password)
        {
            return pfcEntitiesModel.Usuari
                        .Where(u => u.NomUsuari == username 
                                    && u.Contrasenya.Any(c => c.Contrasenya1 == password))
                        .FirstOrDefault();
        }
    }
}