using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuxiliaryProject.AuxiliaryUnit
{
    public static class MapperAU
    {
        public static dynamic Mapper(dynamic sourceObj, dynamic destObj)
        {
            Type typeB = destObj.GetType();
            foreach (System.Reflection.PropertyInfo property in sourceObj.GetType().GetProperties())
            {
                if (!property.CanRead || (property.GetIndexParameters().Length > 0))
                    continue;

                System.Reflection.PropertyInfo other = typeB.GetProperty(property.Name);
                if ((other != null) && (other.CanWrite))
                    other.SetValue(destObj, property.GetValue(sourceObj, null), null);
            }
            return destObj;
        }
    }
}