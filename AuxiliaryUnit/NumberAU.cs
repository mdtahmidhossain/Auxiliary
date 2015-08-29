using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuxiliaryProject.AuxiliaryUnit
{
    public static class NumberAU
    {
        public static dynamic getNumber(dynamic number,int numberOfDecimalPlaces=2)
        {
            return Math.Round(number,numberOfDecimalPlaces);
        }
        public static bool IsPositive(dynamic number)
        {
            return number > 0;
        }

        public static bool IsNegative(dynamic number)
        {
            return number < 0;
        }

        public static bool IsZero(dynamic number)
        {
            return number == 0;
        }
        public static dynamic OnlyNumber(dynamic str)
        {
            return System.Text.RegularExpressions.Regex.Replace(str, @"[^0-9]+", "");
        }


}
}