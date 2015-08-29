using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuxiliaryProject.AuxiliaryUnit
{
    public static class StringAU
    {
        public static string FixNullString(string Value)
        {
            try
            {
                if (!string.IsNullOrEmpty(Value))
                {
                    return Value;
                }
                else
                {
                    return "null";
                }
            }
            catch (Exception ex)
            {
                return "null";
            }
        }

        public static string FixNullStringWithEmptyString(string Value)
        {
            try
            {
                if (!string.IsNullOrEmpty(Value))
                {
                    return Value;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}