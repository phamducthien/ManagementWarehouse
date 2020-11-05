using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Util.Pattern
{
    public static class ExtendMethod
    {
        public const string DateTimeDisplayedFormat = "dd/MM/yyyy";
        public const string DateTimeCodeFormat = "yyyyMMdd";
        public const string DateTimeDatabaseFormat = "yyyy-MM-dd HH:mm:ss:ff";

        public static char ThousandSeparator =
            Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator);

        public static char DecimalSeparator =
            Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        public static DateTime DefaultDateTime = new DateTime(1990, 1, 1, 0, 0, 0);

        public static bool DefaultBoolean = false;

        public static int DefaultInt = 0;
        public static double DefaultDouble = 0;
        public static Guid DefaultGuid = Guid.Empty;

        private static readonly MD5 md5 = MD5.Create();

        public static string ToUnsign(this string input)
        {
            if (input == null) return null;
            var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            var temp = input.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static string ToSpaceIfBlank(this string input)
        {
            if (input.IsBlank()) return input.ToDefaultIfBlank(" ");
            return input;
        }

        public static string ToNullIfEqual(this string input, string compareString)
        {
            if (input == compareString) return null;
            return input;
        }

        public static string ToDefaultIfBlank(this string input, string defaultString = "")
        {
            if (input.IsBlank()) return defaultString;
            return input;
        }

        public static bool IsBlank(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool IsNull(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static string ToDbFormatString(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static object ToObject(this object o)
        {
            return o;
        }

        public static object ToObject(this object o, object b)
        {
            return b;
        }

        private static object CheckChange(object value1, object value2, ref int count)
        {
            var kq = !value1.Equals(value2);
            if (kq)
            {
                count++;
                return value1;
            }

            return value2;
        }

        public static string SetValue<T>(this T obj, T value)
        {
            if (obj.isNull()) return "";
            return value.ToString();
        }

        public static bool isNull<T>(this List<T> list)
        {
            return list == null;
        }

        public static bool isNullOrZero<T>(this List<T> list)
        {
            if (list != null && list.Count == 0) return true;
            return list == null;
        }

        public static bool isNull<T>(this T obj)
        {
            return obj == null;
        }

        public static DateTime ToDateTime(this string input
            , string strFomatter = DateTimeDisplayedFormat
            , DateTime? defaultValue = null)
        {
            DateTime obj;
            try
            {
                try
                {
                    obj = DateTime.ParseExact(input, strFomatter,
                        CultureInfo.CurrentCulture);
                }
                catch (Exception)
                {
                    //06/04/2016
                    // input =
                    var sdate = input.Substring(0, 10);
                    var date = sdate.Split('/');
                    var y = int.Parse(date[2]);
                    int m;
                    int d;
                    //string sTime = input.Replace(_date, "");
                    //string [] time = sTime.Split('/');
                    //int HH;
                    //int mm;
                    //int ss;

                    if (strFomatter.Contains("MM/dd/yyyy"))
                    {
                        m = int.Parse(date[0]);
                        d = int.Parse(date[1]);
                        obj = new DateTime(y, m, d);
                    }
                    else if (strFomatter.Contains("dd/MM/yyyy"))
                    {
                        m = int.Parse(date[1]);
                        d = int.Parse(date[0]);
                        obj = new DateTime(y, m, d);
                    }
                    else
                    {
                        obj = DateTime.Parse(input);
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    if (strFomatter.Contains("MM/dd/yyyy"))
                        obj = DateTime.ParseExact(input, strFomatter,
                            CultureInfo.CurrentCulture);
                    else if (strFomatter.Contains("dd/MM/yyyy"))
                        obj = DateTime.ParseExact(input, strFomatter,
                            CultureInfo.CurrentCulture);
                    else
                        obj = DateTime.Parse(input);
                }
                catch (Exception)
                {
                    obj = defaultValue ?? DefaultDateTime;
                }
            }

            return obj;
        }

        public static bool IsMD5Of(this string value, string md5)
        {
            return value.EncodeMD5() == md5;
        }

        public static string EncodeMD5(this string value)
        {
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            return Convert.ToBase64String(bytes);
        }

        public static string EncodeB64(this string value)
        {
            var data = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(data);
        }

        public static string DecodeB64(this string value)
        {
            var data = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(data);
        }

        public static string ToAscii(this string value)
        {
            var ss = Regex.Replace(value.ToLower(), "[áàảãạăắằẳẵặâấầẩẫậ]", "a");
            ss = Regex.Replace(ss, "[đ]", "d");
            ss = Regex.Replace(ss, "[éèẻẽẹêếềểễệ]", "e");
            ss = Regex.Replace(ss, "[íìỉĩị]", "i");
            ss = Regex.Replace(ss, "[óòỏõọôốồổỗộơớờởỡợ]", "o");
            ss = Regex.Replace(ss, "[úùủũụưứừửữự]", "u");
            ss = Regex.Replace(ss, "[ýỳỷỹỵ]", "y");
            ss = Regex.Replace(ss, @"[\s]+", "-");
            return ss;
        }

        public static string ToShorten(this string value, int length)
        {
            if (value == null || value.Length < length)
                return value;
            var iNextSpace = value.LastIndexOf(" ", length);
            return value.Substring(0, iNextSpace > 0 ? iNextSpace : length).Trim();
        }

        public static string ToCapitalize(this string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
        }

        public static DataTable ToDatatable<T>(this List<T> list)
        {
            var properties =
                TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (var item in list)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    try
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    catch
                    {
                        row[prop.Name] = null;
                    }

                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable ToDatatable<T>(this IEnumerable<T> list)
        {
            var properties =
                TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (var item in list)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    try
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    catch
                    {
                        row[prop.Name] = null;
                    }

                table.Rows.Add(row);
            }

            return table;
        }

        #region Number Extendsion Method

        public static int ToInt(this string input)
        {
            return int.Parse(input);
        }

        public static int ToIntOrDefault(this string input)
        {
            int i;
            var res = int.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out i);

            return res ? i : DefaultInt;
        }

        public static decimal ToDecimal(this string input)
        {
            decimal i;
            var res = decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out i);

            return res ? i : DefaultInt;
        }

        public static decimal ToDecimalOrDefault(this string input)
        {
            decimal i;
            var res = decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out i);

            return res ? i : DefaultInt;
        }

        public static double ToDouble(this string input)
        {
            return double.Parse(input);
        }

        public static bool ToBoolOrDefault(this string input)
        {
            bool i;
            var res = bool.TryParse(input, out i);
            return res && i;
        }

        public static bool ToBool(this string input)
        {
            return bool.Parse(input);
        }

        public static Guid ToGuidOrDefault(this string input)
        {
            Guid i;
            var res = Guid.TryParse(input, out i);

            return res ? i : DefaultGuid;
        }

        public static Guid ToGuid(this string input)
        {
            return Guid.Parse(input);
        }

        public static double ToDoubleOrDefault(this string input)
        {
            double i;
            var res = double.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out i);

            return res ? i : DefaultDouble;
        }

        public static bool IsInt(this string input)
        {
            if (input.IsBlank()) return false;
            int i;
            return int.TryParse(input, out i);
        }

        public static long ToLong(this string input)
        {
            return long.Parse(input);
        }

        public static long ToLongOrDefault(this string input)
        {
            long i;
            var res = long.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out i);
            return res ? i : DefaultInt;
        }

        #region Default Value

        public static DateTime ToDefault(this DateTime? value)
        {
            return value ?? DefaultDateTime;
        }

        public static DateTime ToDefault(this DateTime value)
        {
            return value != null ? value : DefaultDateTime;
        }

        public static long ToDefault(this long? value)
        {
            return value ?? DefaultInt;
        }

        public static int ToDefault(this int? value)
        {
            return value ?? DefaultInt;
        }

        public static decimal ToDefault(this decimal? value)
        {
            return value ?? DefaultInt;
        }

        public static bool ToDefault(this bool? value)
        {
            return value ?? DefaultBoolean;
        }

        #endregion

        #endregion

        #region Image

        public static byte[] ToBytes(this Image img)
        {
            if (img == null)
                return null;
            try
            {
                var ms = new MemoryStream();
                img.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
            catch
            {
                return null;
            }
        }

        public static Image ToImage(this byte[] b)
        {
            if (b == null)
                return null;
            try
            {
                var ms = new MemoryStream(b);
                var returnImage = Image.FromStream(ms);
                return returnImage;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        public static decimal? AdjustRound(double value)
        {
            var whole = Math.Truncate(value);
            var remainder = value - whole;
            if (remainder < 0.5)
            {
                remainder = 0;
            }
            else if (remainder == 0.5)
            {
                remainder = 0.5;
            }
            else
            {
                remainder = 1;
            }
            return (decimal?)(whole + remainder);
        }
    }
}
