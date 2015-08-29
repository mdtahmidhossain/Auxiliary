using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

namespace AuxiliaryProject.AuxiliaryUnit
{
    public static class JsonAU
    {
        public static string listToJson<T>(List<T> list)
        {
            return JsonConvert.SerializeObject(list);
        }

      

        public static T jsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

       
    }
}