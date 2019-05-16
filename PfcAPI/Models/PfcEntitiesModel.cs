using PfcDataAccess;

namespace PfcAPI.Models
{
    public class PfcEntitiesModel : PfcEntities
    {
        public PfcEntitiesModel()
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
    }
}