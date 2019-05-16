using PfcDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PfcAPI.Utils.Global
{
    public static class UserGlobal
    {
        public static Usuari usuari
        {
            get
            {
                return HttpContext.Current.Application["Usuari"] as Usuari;
            }
            set
            {
                HttpContext.Current.Application["Usuari"] = value;
            }
        }
    }
}