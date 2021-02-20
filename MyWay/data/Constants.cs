using System;
using System.Collections.Generic;
using System.Text;

namespace MyWay.data
{
    public static class Constants
    {
        public static string webservice = "http://192.168.1.7:3000";
        public static string inscription = webservice+"/inscription";
        public static string mainpage = webservice + "/authentification";
        public static string affichageusers = webservice + "/listusers";
        public static string ajouteruser = webservice + "/request";
        public static string refuseruser = webservice + "/refuseRequest";
    }
}
