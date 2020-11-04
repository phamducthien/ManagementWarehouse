using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;

namespace Util.Pattern
{
    public static class ConvertUtil
    {
        public const string DateTimeDisplayedFormat = "dd/MM/yyyy";
        public const string DateTimeCodeFormat = "yyyyMMdd";
        public const string DateTimeDatabaseFormat = "yyyy-MM-dd HH:mm:ss:ff";

        public static char ThousandSeparator =
            Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator);

        public static char DecimalSeparator =
            Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        public static DateTime DefaultDateTime = new DateTime(1990, 1, 1, 0, 0, 0);

        public static byte DefaultInt = 0;

        private static MD5 md5 = MD5.Create();

        public static DataTable ConvertToDataTable<T>(List<T> data)
        {
            var properties =
                TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }

            return table;
        }

        #region Long method

        public static string ToNumericString(this long? number)
        {
            return number != null ? ((long) number).ToNumericString() : "0";
        }

        public static string ToNumericString(this long number)
        {
            return number.ToString("N0");
        }

        public static string ToPlainString(this long? number)
        {
            return number != null ? ((long) number).ToPlainString() : "0";
        }

        public static string ToPlainString(this long number)
        {
            return number.ToString();
        }

        #endregion

        #region Int method

        public static string ToNumericString(this int? number)
        {
            return number != null ? ((int) number).ToNumericString() : "0";
        }

        public static string ToNumericString(this int number)
        {
            return number.ToString("N0");
        }

        public static string ToPlainString(this int? number)
        {
            return number != null ? ((int) number).ToPlainString() : "0";
        }

        public static string ToPlainString(this int number)
        {
            return number.ToString();
        }

        #endregion

        #region DateTime method

        public static string ToDisplayingFormat(this DateTime? value)
        {
            var valueNotNull = value ?? DefaultDateTime;
            return valueNotNull.ToDisplayingFormat();
        }

        public static string ToDisplayingFormat(this DateTime value)
        {
            return value.ToFormat(DateTimeDisplayedFormat);
        }

        public static string ToCodeFormat(this DateTime? value)
        {
            var valueNotNull = value ?? DefaultDateTime;
            return valueNotNull.ToCodeFormat();
        }

        public static string ToCodeFormat(this DateTime value)
        {
            return value.ToFormat(DateTimeCodeFormat);
        }

        public static string ToDatabaseFormat(this DateTime? value)
        {
            var valueNotNull = value ?? DefaultDateTime;
            return valueNotNull.ToDatabaseFormat();
        }

        public static string ToDatabaseFormat(this DateTime value)
        {
            return value.ToFormat(DateTimeDatabaseFormat);
        }

        public static string ToFormat(this DateTime value, string formatString)
        {
            return value.ToString(formatString);
        }

        #endregion
    }
}