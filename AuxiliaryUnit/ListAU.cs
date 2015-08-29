using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuxiliaryProject.AuxiliaryUnit
{
    public static class ListAU
    {
        public static List<T> toList<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}