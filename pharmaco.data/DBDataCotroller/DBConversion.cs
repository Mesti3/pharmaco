using System;
using System.Globalization;

namespace pharmaco.data.DBDataCotroller
{
    public class DBConversion
    {
        public static DateTime GetFromDbDateTime(object s)
        {
           if (s == DBNull.Value)
                return new DateTime(1900, 0, 0);
            else
                return DateTime.ParseExact(s.ToString(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        }
        public static string GetToDbDateTime(DateTime? value)
        {
            if ((!value.HasValue))
                return "NULL";
            else
            {
                var result = string.Format("CONVERT(DATETIME, '{0:yyyy-MM-dd HH:mm:s}', 102)", value.Value);
                return result;
            }
        }
        public static string GetFromDbString(object s)
        {
            if (s == DBNull.Value)
                return "";
            else
                return (s as string).Trim();
        }

        public static string GetToDbString(object s)
        {
            return "'"+(s as string).Trim().Replace("'", "''")+ "'";
        }

        public static Int32? GetFromDbInt(object s)
        {
            if (s == DBNull.Value)
                return null;
            else
                return System.Convert.ToInt32(s);
        }
        public static decimal? GetFromDbDecimal(object s)
        {
            if (s == DBNull.Value)
                return null;
            else
                return System.Convert.ToDecimal(s);
        }
        public static string GetToDbDecimal(decimal s)
        {
           return s.ToString(CultureInfo.InvariantCulture);
        }

        public static bool? GetFromDbBoolean(object s)
        {
            if (s == DBNull.Value)
                return null;
            else
                return System.Convert.ToBoolean(s);
        }

    }
}
