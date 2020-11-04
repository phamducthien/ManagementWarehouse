using System;
using System.Collections.Generic;

namespace Util.Pattern.DateTimeUtil
{
    public enum DateGroupType
    {
        none = 1,
        by_1day,
        by_3days,
        by_7days,
        by_week,
        by_month,
        by_quater,
        by_year
    }

    public enum Quarter
    {
        First = 1,
        Second,
        Third,
        Fourth
    }

    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    public class DateTimeSpan
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public TimeSpan Span => To - From;
    }

    public static class DateTimeExtend
    {
        #region Common DateTime functions

        public static DateTime StartOfDate(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime EndOfDate(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        public static DateTime AtMidday(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 12, 0, 0);
        }

        public static DateTime StartOfLastWeek(this DateTime dt)
        {
            var num = (int) (dt.DayOfWeek + 7);
            return dt.Subtract(TimeSpan.FromDays(num)).StartOfDate();
        }

        public static DateTime EndOfLastWeek(this DateTime dt)
        {
            return dt.StartOfLastWeek().AddDays(6.0).EndOfDate();
        }

        public static DateTime StartOfWeek(this DateTime dt)
        {
            var dayOfWeek = (int) dt.DayOfWeek;
            return dt.Subtract(TimeSpan.FromDays(dayOfWeek)).StartOfDate();
        }

        public static DateTime EndOfWeek(this DateTime dt)
        {
            return dt.StartOfWeek().AddDays(6.0).EndOfDate();
        }

        /// <summary>
        ///     Returns the next date which falls on the given day of the week
        /// </summary>
        /// <example>
        ///     DateTime nextTuesday = DateTime.Now.NextDayOfWeek(DayOfWeek.Tuesday);
        /// </example>
        /// <param name="dt">Start date</param>
        /// <param name="dayOfWeek">The required day of week</param>
        public static DateTime NextDayOfWeek(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var offsetDays = dayOfWeek - dt.DayOfWeek;
            return dt.AddDays(offsetDays > 0 ? offsetDays : offsetDays + 7).StartOfDate();
        }

        public static DateTime StartOfMonth(this DateTime dt)
        {
            return dt.AddDays(1 - dt.Day).StartOfDate();
        }

        /// <summary>
        ///     Returns the first specified day of the week in the current month
        /// </summary>
        /// <example>
        ///     DateTime firstTuesday = DateTime.Now.FirstDayOfMonth(DayOfWeek.Tuesday);
        /// </example>
        /// <param name="dt">Start date</param>
        /// <param name="dayOfWeek">The required day of week</param>
        /// <returns></returns>
        public static DateTime StartOfMonth(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var firstDayOfMonth = dt.StartOfMonth();
            return (firstDayOfMonth.DayOfWeek == dayOfWeek
                ? firstDayOfMonth
                : firstDayOfMonth.NextDayOfWeek(dayOfWeek)).StartOfDate();
        }

        public static DateTime EndOfMonth(this DateTime dt)
        {
            var daysInMonth = DateTime.DaysInMonth(dt.Year, dt.Month);
            return new DateTime(dt.Year, dt.Month, daysInMonth).EndOfDate();
        }

        public static DateTime GetStartOfMonth(int Month, int Year)
        {
            return new DateTime(Year, Month, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfMonth(int Month, int Year)
        {
            return new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month), 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastMonth()
        {
            DateTime startOfMonth;
            if (DateTime.Now.Month == 1)
                startOfMonth = GetStartOfMonth(12, DateTime.Now.Year - 1);
            else
                startOfMonth = GetStartOfMonth(DateTime.Now.Month - 1, DateTime.Now.Year);
            return startOfMonth;
        }

        public static DateTime GetEndOfLastMonth()
        {
            DateTime endOfMonth;
            if (DateTime.Now.Month == 1)
                endOfMonth = GetEndOfMonth(12, DateTime.Now.Year - 1);
            else
                endOfMonth = GetEndOfMonth(DateTime.Now.Month - 1, DateTime.Now.Year);
            return endOfMonth;
        }

        public static DateTime GetStartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public static DateTime GetStartOfCurrentWeek()
        {
            var dayOfWeek = (int) DateTime.Now.DayOfWeek;
            var dateTime = DateTime.Now.Subtract(TimeSpan.FromDays(dayOfWeek));
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfCurrentWeek()
        {
            var dateTime = GetStartOfCurrentWeek().AddDays(6.0);
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastWeek()
        {
            var num = (int) (DateTime.Now.DayOfWeek + 7);
            var dateTime = DateTime.Now.Subtract(TimeSpan.FromDays(num));
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfLastWeek()
        {
            var dateTime = GetStartOfLastWeek().AddDays(6.0);
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999);
        }


        /// <summary>
        ///     Returns the last specified day of the week in the current month
        /// </summary>
        /// <example>
        ///     DateTime finalTuesday = DateTime.Now.LastDayOfMonth(DayOfWeek.Tuesday);
        /// </example>
        /// <param name="dt" />
        /// Start date
        /// <param name="dayOfWeek" />
        /// The required day of week
        /// <returns />
        public static DateTime EndOfMonth(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var lastDayOfMonth = dt.EndOfMonth();
            return lastDayOfMonth.AddDays(lastDayOfMonth.DayOfWeek < dayOfWeek
                ? dayOfWeek - lastDayOfMonth.DayOfWeek - 7
                : dayOfWeek - lastDayOfMonth.DayOfWeek);
        }

        public static DateTime StartOfQuarter(int year, Quarter qtr)
        {
            if (qtr == Quarter.First) return new DateTime(year, 1, 1, 0, 0, 0, 0);
            if (qtr == Quarter.Second) return new DateTime(year, 4, 1, 0, 0, 0, 0);
            if (qtr == Quarter.Third) return new DateTime(year, 7, 1, 0, 0, 0, 0);
            return new DateTime(year, 10, 1, 0, 0, 0, 0);
        }

        public static DateTime EndOfQuarter(int year, Quarter qtr)
        {
            if (qtr == Quarter.First) return new DateTime(year, 3, DateTime.DaysInMonth(year, 3), 23, 59, 59, 999);
            if (qtr == Quarter.Second) return new DateTime(year, 6, DateTime.DaysInMonth(year, 6), 23, 59, 59, 999);
            if (qtr == Quarter.Third) return new DateTime(year, 9, DateTime.DaysInMonth(year, 9), 23, 59, 59, 999);
            return new DateTime(year, 12, DateTime.DaysInMonth(year, 12), 23, 59, 59, 999);
        }

        public static Quarter GetQuarter(Month month)
        {
            if (month <= Month.March) return Quarter.First;
            if (month >= Month.April && month <= Month.June) return Quarter.Second;
            if (month >= Month.July && month <= Month.September) return Quarter.Third;
            return Quarter.Fourth;
        }

        public static DateTime StartOfLastQuarter(this DateTime dt)
        {
            var startOfQuarter = dt.Month <= 3
                ? StartOfQuarter(dt.Year - 1, GetQuarter(Month.December))
                : StartOfQuarter(dt.Year, GetQuarter((Month) dt.Month));
            return startOfQuarter;
        }

        public static DateTime EndOfLastQuarter(this DateTime dt)
        {
            var endOfQuarter = dt.Month <= 3
                ? EndOfQuarter(dt.Year - 1, GetQuarter(Month.December))
                : EndOfQuarter(dt.Year, GetQuarter((Month) dt.Month));
            return endOfQuarter;
        }

        public static DateTime StartOfQuarter(this DateTime dt)
        {
            return StartOfQuarter(dt.Year, GetQuarter((Month) dt.Month));
        }

        public static DateTime EndOfQuarter(this DateTime dt)
        {
            return EndOfQuarter(dt.Year, GetQuarter((Month) dt.Month));
        }

        public static DateTime StartOfYear(int year)
        {
            return new DateTime(year, 1, 1, 0, 0, 0, 0);
        }

        public static DateTime EndOfYear(int year)
        {
            return new DateTime(year, 12, DateTime.DaysInMonth(year, 12), 23, 59, 59, 999);
        }

        public static DateTime StartOfLastYear(this DateTime dt)
        {
            return StartOfYear(dt.Year - 1);
        }

        public static DateTime EndOfLastYear(this DateTime dt)
        {
            return EndOfYear(dt.Year - 1);
        }

        public static DateTime StartOfYear(this DateTime dt)
        {
            return StartOfYear(dt.Year);
        }

        public static DateTime EndOfYear(this DateTime dt)
        {
            return EndOfYear(dt.Year);
        }

        public static DateTime StarOfLastMonth(this DateTime dt)
        {
            return dt.EndOfMonth().AddMonths(-1).StartOfMonth();
        }

        public static DateTime EndOfLastMonth(this DateTime dt)
        {
            return dt.EndOfMonth().AddMonths(-1).EndOfMonth();
        }

        #endregion

        #region DateTimeSpliter

        private static DateTime getNextStop(DateTime from, DateTime to, DateGroupType groupType)
        {
            var stop = DateTime.MinValue;

            switch (groupType)
            {
                case DateGroupType.none:
                    stop = to;
                    break;
                case DateGroupType.by_1day:
                    stop = from.AddDays(1).EndOfDate();
                    break;
                case DateGroupType.by_3days:
                    stop = from.AddDays(3).EndOfDate();
                    break;
                case DateGroupType.by_7days:
                    stop = from.AddDays(7).EndOfDate();
                    break;
                case DateGroupType.by_week:
                    stop = from.EndOfWeek();
                    break;
                case DateGroupType.by_month:
                    stop = from.EndOfMonth();
                    break;
                case DateGroupType.by_quater:
                    stop = from.EndOfQuarter();
                    break;
                case DateGroupType.by_year:
                    stop = from.EndOfYear();
                    break;
            }

            return stop > to ? to : stop;
        }

        public static List<DateTimeSpan> DateTimeSplit(DateTime from, DateTime to, DateGroupType groupType)
        {
            var list = new List<DateTimeSpan>();
            if (from > to) return list;

            DateTime start = from, stop = to;

            while (start <= stop)
            {
                stop = getNextStop(start, from, groupType);
                list.Add(new DateTimeSpan
                {
                    From = start,
                    To = stop
                });
                start = stop.AddDays(1).StartOfDate();
            }

            return list;
        }

        #endregion
    }
}