using System;
using System.Globalization;

namespace PersianDateTime
{
    public struct PersianDateTime
    {
        private DateTime dateTimeData;
        private PersianCalendar persianCalendar = new PersianCalendar();


        public PersianDateTime(DateTime dateTime) { dateTimeData = dateTime; }
        public PersianDateTime(int year, int month, int day) : this(year, month, day, 0, 0, 0, 0) { }
        public PersianDateTime(int year, int month, int day, int hour, int minute, int second) : this(year, month, day, hour, minute, second, 0) { }
        public PersianDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            dateTimeData = new DateTime(year, month, day, hour, minute, second, millisecond, persianCalendar);
        }


        public static PersianDateTime Now
        {
            get { return new PersianDateTime(DateTime.Now); }
        }
        public static PersianDateTime Today
        {
            get { return PersianDateTime.Now.Date; }
        }

        public int Millisecond
        {
            get { return (int)persianCalendar.GetMilliseconds(dateTimeData); }
        }
        public int Second
        {
            get { return persianCalendar.GetSecond(dateTimeData); }
        }
        public int Minute
        {
            get { return persianCalendar.GetMinute(dateTimeData); }
        }
        public int Hour
        {
            get { return persianCalendar.GetHour(dateTimeData); }
        }
        public int Day
        {
            get { return persianCalendar.GetDayOfMonth(dateTimeData); }
        }
        public int Month
        {
            get { return persianCalendar.GetMonth(dateTimeData); }
        }
        public int Year
        {
            get { return persianCalendar.GetYear(dateTimeData); }
        }
        public PersianDayOfWeek DayOfWeek
        {
            get { return (PersianDayOfWeek)(int)dateTimeData.DayOfWeek; }
        }
        public int DayOfYear
        {
            get { return persianCalendar.GetDayOfYear(dateTimeData); }
        }

        public PersianDateTime Date
        {
            get { return new PersianDateTime(DateTime.Now.Date); }
        }
        public TimeSpan TimeOfDay
        {
            get { return dateTimeData.TimeOfDay; }
        }

        public int DaysInMonth
        {
            get { return persianCalendar.GetDaysInMonth(Year, Month); }
        }
        public int DaysInYear
        {
            get { return persianCalendar.GetDaysInYear(Year); }
        }




        public static int Compare(PersianDateTime t1, PersianDateTime t2)
        {
            return 0;
        }

    }

    public enum PersianDayOfWeek
    {
        یکشنبه = 0,
        دوشنبه = 1,
        سه‌شنبه = 2,
        چهارشنبه = 3,
        پنجشنبه = 4,
        جمعه = 5,
        شنبه = 6
    }
}