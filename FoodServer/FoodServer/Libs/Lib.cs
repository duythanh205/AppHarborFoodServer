using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace FoodServer.Libs
{
    public static class Lib
    {
        public static string ToJson(this object obj, bool isLoopHandling = false)
        {
            try
            {
                return !isLoopHandling ? JsonConvert.SerializeObject(obj) :
                    JsonConvert.SerializeObject(obj, Formatting.Indented,
                    new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
            }
            catch
            {
                throw;
            }
        }

        public static T FromJson<T>(this string value, bool isLoopHandling = false)
        {
            try
            {
                return isLoopHandling ? JsonConvert.DeserializeObject<T>(value,
                    new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore }) : JsonConvert.DeserializeObject<T>(value);
            }
            catch
            {
                throw;
            }
        }

        public static DateTime ToDateTime(this string value, string format)
        {
            try
            {
                return DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);
            }
            catch
            {
                throw;
            }
        }

        public static DateTime ToStartDate(this DateTime value)
        {
            try
            {
                return new DateTime(value.Year, value.Month, value.Day, 0, 0, 0, 0);
            }
            catch
            {
                throw;
            }
        }

        public static DateTime ToEndDate(this DateTime value, int millisecond = 999)
        {
            try
            {
                return new DateTime(value.Year, value.Month, value.Day, 23, 59, 59, millisecond);
            }
            catch
            {
                throw;
            }
        }
    }
}