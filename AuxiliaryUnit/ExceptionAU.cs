using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuxiliaryProject.AuxiliaryUnit
{
    public static class ExceptionAU
    {
        public static string GetExceptionDetails(Exception exception)
        {
            var properties = exception.GetType()
                                    .GetProperties();
            var fields = properties
                             .Select(property => new {
                                 Name = property.Name,
                                 Value = property.GetValue(exception, null)
                             })
                             .Select(x => String.Format(
                                 "{0} = {1}",
                                 x.Name,
                                 x.Value != null ? x.Value.ToString() : String.Empty
                             ));
            return String.Join("\n", fields);
        }
        public static string BuildExceptionMessage(Exception x)
        {
            Exception logException = x;
            if (x.InnerException != null)
                logException = x.InnerException;

            string strErrorMsg = Environment.NewLine + "Error in Path :" + System.Web.HttpContext.Current.Request.Path;

            // Get the QueryString along with the Virtual Path
            strErrorMsg += Environment.NewLine + "Raw Url :" + System.Web.HttpContext.Current.Request.RawUrl;

            // Get the error message
            strErrorMsg += Environment.NewLine + "Message :" + logException.Message;

            // Source of the message
            strErrorMsg += Environment.NewLine + "Source :" + logException.Source;

            // Stack Trace of the error

            strErrorMsg += Environment.NewLine + "Stack Trace :" + logException.StackTrace;

            // Method where the error occurred
            strErrorMsg += Environment.NewLine + "TargetSite :" + logException.TargetSite;
            return strErrorMsg;
        }

    }
}