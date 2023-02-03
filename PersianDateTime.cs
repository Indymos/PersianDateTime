using System.Globalization;

namespace System
{
    public struct PersianDateTime
    {
        private DateTime dateTimeData;
        private PersianCalendar persianCalendar = new PersianCalendar();


        public PersianDateTime(DateTime dateTime) { dateTimeData = dateTime; }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, and day.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999. -or- month is less than 1 or greater
        //     than 12. -or- day is less than 1 or greater than the number of days in month.
        public PersianDateTime(int year, int month, int day) : this(year, month, day, 0, 0, 0, 0) { }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, and second.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999. -or- month is less than 1 or greater
        //     than 12. -or- day is less than 1 or greater than the number of days in month.
        //     -or- hour is less than 0 or greater than 23. -or- minute is less than 0 or greater
        //     than 59. -or- second is less than 0 or greater than 59.
        public PersianDateTime(int year, int month, int day, int hour, int minute, int second) : this(year, month, day, hour, minute, second, 0) { }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, second, and millisecond.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   millisecond:
        //     The milliseconds (0 through 999).
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999. -or- month is less than 1 or greater
        //     than 12. -or- day is less than 1 or greater than the number of days in month.
        //     -or- hour is less than 0 or greater than 23. -or- minute is less than 0 or greater
        //     than 59. -or- second is less than 0 or greater than 59. -or- millisecond is less
        //     than 0 or greater than 999.
        public PersianDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            dateTimeData = new DateTime(year, month, day, hour, minute, second, millisecond, persianCalendar);
        }

        //
        // Summary:
        //     Gets a System.DateTime object that is set to the current date and time on this
        //     computer, expressed as the local time.
        //
        // Returns:
        //     An object whose value is the current local date and time.
        public static PersianDateTime Now
        {
            get
            {
                return new PersianDateTime(DateTime.Now);
            }
        }

        //
        // Summary:
        //     Gets the current date.
        //
        // Returns:
        //     An object that is set to today's date, with the time component set to 00:00:00.
        public static PersianDateTime Today
        {
            get
            {
                return PersianDateTime.Now.Date;
            }
        }

        //
        // Summary:
        //     Gets the date component of this instance.
        //
        // Returns:
        //     A new object with the same date as this instance, and the time value set to 12:00:00
        //     midnight (00:00:00).
        public PersianDateTime Date
        {
            get
            {
                return new PersianDateTime(DateTime.Now.Date);
            }
        }

        //
        // Summary:
        //     Gets the time of day for this instance.
        //
        // Returns:
        //     A time interval that represents the fraction of the day that has elapsed since
        //     midnight.
        public TimeSpan TimeOfDay
        {
            get
            {
                return dateTimeData.TimeOfDay;
            }
        }

        //
        // Summary:
        //     Gets the milliseconds component of the date represented by this instance.
        //
        // Returns:
        //     The milliseconds component, expressed as a value between 0 and 999.
        public int Millisecond
        {
            get
            {
                return (int)persianCalendar.GetMilliseconds(dateTimeData);
            }
        }

        //
        // Summary:
        //     Gets the seconds component of the date represented by this instance.
        //
        // Returns:
        //     The seconds component, expressed as a value between 0 and 59.
        public int Second
        {
            get
            {
                return persianCalendar.GetSecond(dateTimeData);
            }
        }

        //
        // Summary:
        //     Gets the minute component of the date represented by this instance.
        //
        // Returns:
        //     The minute component, expressed as a value between 0 and 59.
        public int Minute
        {
            get
            {
                return persianCalendar.GetMinute(dateTimeData);
            }
        }

        //
        // Summary:
        //     Gets the hour component of the date represented by this instance.
        //
        // Returns:
        //     The hour component, expressed as a value between 0 and 23.
        public int Hour
        {
            get
            {
                return persianCalendar.GetHour(dateTimeData);
            }
        }

        //
        // Summary:
        //     Gets the day of the month represented by this instance.
        //
        // Returns:
        //     The day component, expressed as a value between 1 and 31.
        public int Day
        {
            get
            {
                return persianCalendar.GetDayOfMonth(dateTimeData);
            }
        }
        public int Month
        {
            get
            {
                return persianCalendar.GetMonth(dateTimeData);
            }
        }

        //
        // Summary:
        //     Gets the year component of the date represented by this instance.
        //
        // Returns:
        //     The year, between 1 and 9999.
        public int Year
        {
            get
            {
                return persianCalendar.GetYear(dateTimeData);
            }
        }

        //
        // Summary:
        //     Gets the day of the week represented by this instance.
        //
        // Returns:
        //     An enumerated constant that indicates the day of the week of this System.PersianDateTime
        //     value.
        public PersianDayOfWeek DayOfWeek
        {
            get
            {
                return (PersianDayOfWeek)(int)dateTimeData.DayOfWeek;
            }
        }

        //
        // Summary:
        //     Gets the day of the year represented by this instance.
        //
        // Returns:
        //     The day of the year, expressed as a value between 1 and 366.
        public int DayOfYear
        {
            get
            {
                return persianCalendar.GetDayOfYear(dateTimeData);
            }
        }


        public int DaysInMonth
        {
            get
            {
                return persianCalendar.GetDaysInMonth(Year, Month);
            }
        }
        public int DaysInYear
        {
            get
            {
                return persianCalendar.GetDaysInYear(Year);
            }
        }


        //
        // Summary:
        //     Compares two instances of System.PersianDateTime and returns an integer that indicates
        //     whether the first instance is earlier than, the same as, or later than the second
        //     instance.
        //
        // Parameters:
        //   t1:
        //     The first object to compare.
        //
        //   t2:
        //     The second object to compare.
        //
        // Returns:
        //     A signed number indicating the relative values of t1 and t2.
        //     Value Type – Condition
        //     Less than zero –t1 is earlier than t2.
        //     Zero –t1 is the same as t2.
        //     Greater than zero –t1 is later than t2.
        public static int Compare(PersianDateTime t1, PersianDateTime t2)
        {
            return 0;
        }

    }

    //
    // Summary:
    //     Specifies the day of the week.
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
