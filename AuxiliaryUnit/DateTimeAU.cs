using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuxiliaryProject.AuxiliaryUnit
{
    public static class DateTimeAU
    {
        public static dynamic ConvertToSpecificTimeZone(string SystemTimeZoneByID = "Eastern Standard Time")
        {
            TimeZoneInfo AtlanticTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, AtlanticTimeZone);
        }

        public static DateTime ConvertToSpecificTimeZone(DateTime UtcTime, string SystemTimeZoneByID = "Eastern Standard Time")
        {
            TimeZoneInfo AtlanticTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(UtcTime, AtlanticTimeZone);
        }
    }
}