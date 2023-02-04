using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;

namespace System
{
    public struct PersianDateTime
    {

        private readonly DateTime _dateData;
        private PersianCalendar persianCalendar = new PersianCalendar();
        private readonly DateTime MinValue = new DateTime(622, 3, 22);

        public PersianDateTime()
        {
            _dateData = MinValue;
        }

        public PersianDateTime(DateTime dateTime)
        {
            _dateData = (dateTime >= MinValue) ? dateTime : MinValue;
        }

        public PersianDateTime(int year, int month, int day) : this(year, month, day, 0, 0, 0, 0)
        {
        }

        public PersianDateTime(int year, int month, int day, int hour, int minute, int second) : this(year, month, day, hour, minute, second, 0)
        {
        }

        public PersianDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            _dateData = new DateTime(year, month, day, hour, minute, second, millisecond, persianCalendar);
        }


        public static PersianDateTime Now => new PersianDateTime(DateTime.Now);

        public static PersianDateTime Today => Now.Date;

        public PersianDateTime Date => new PersianDateTime(_dateData.Date);

        public TimeSpan TimeOfDay => _dateData.TimeOfDay;

        public long Ticks => _dateData.Ticks;

        public int Millisecond => _dateData.Millisecond;
        public int Second => _dateData.Second;
        public int Minute => _dateData.Minute;
        public int Hour => _dateData.Hour;
        public int Day => persianCalendar.GetDayOfMonth(_dateData);
        public int Month => persianCalendar.GetMonth(_dateData);
        public int Year => persianCalendar.GetYear(_dateData);

        public PersianDayOfWeek DayOfWeek => (PersianDayOfWeek)(int)_dateData.DayOfWeek;
        public int DayOfYear => persianCalendar.GetDayOfYear(_dateData);

        public int DaysInMonth => persianCalendar.GetDaysInMonth(Year, Month);
        public int DaysInYear => persianCalendar.GetDaysInYear(Year);


        public override string ToString()
        {
            return "";
        }


        public PersianDateTime Add(TimeSpan value)
        {
            return new PersianDateTime(_dateData.Add(value));
        }

        public PersianDateTime AddMilliseconds(double value)
        {
            return new PersianDateTime(_dateData.AddMilliseconds(value));
        }

        public PersianDateTime AddSeconds(double value)
        {
            return new PersianDateTime(_dateData.AddSeconds(value));
        }

        public PersianDateTime AddMinutes(double value)
        {
            return new PersianDateTime(_dateData.AddMinutes(value));
        }

        public PersianDateTime AddHours(double value)
        {
            return new PersianDateTime(_dateData.AddHours(value));
        }

        public PersianDateTime AddDays(double value)
        {
            return new PersianDateTime(_dateData.AddDays(value));
        }

        public PersianDateTime AddMonths(int months)
        {
            return new PersianDateTime(_dateData.AddMonths(months));
        }

        public PersianDateTime AddYears(int value)
        {
            return new PersianDateTime(_dateData.AddYears(value));
        }

        public static int Compare(PersianDateTime t1, PersianDateTime t2)
        {
            return DateTime.Compare(t1._dateData, t2._dateData);
        }

        public static bool IsLeapYear(int year)
        {
            PersianCalendar persian = new PersianCalendar();
            return persian.IsLeapYear(year);
        }


        public static PersianDateTime operator +(PersianDateTime d, TimeSpan t)
        {
            return new PersianDateTime(d._dateData + t);
        }

        public static PersianDateTime operator -(PersianDateTime d, TimeSpan t)
        {
            return new PersianDateTime(d._dateData - t);
        }

        public static TimeSpan operator -(PersianDateTime d1, PersianDateTime d2) => new TimeSpan(d1.Ticks - d2.Ticks);

        public static bool operator ==(PersianDateTime d1, PersianDateTime d2) => d1.Ticks == d2.Ticks;

        public static bool operator !=(PersianDateTime d1, PersianDateTime d2) => d1.Ticks != d2.Ticks;

        public static bool operator <(PersianDateTime t1, PersianDateTime t2) => t1.Ticks < t2.Ticks;

        public static bool operator <=(PersianDateTime t1, PersianDateTime t2) => t1.Ticks <= t2.Ticks;

        public static bool operator >(PersianDateTime t1, PersianDateTime t2) => t1.Ticks > t2.Ticks;

        public static bool operator >=(PersianDateTime t1, PersianDateTime t2) => t1.Ticks >= t2.Ticks;


        public override bool Equals([NotNullWhen(true)] object? value)
        {
            if (value is PersianDateTime)
            {
                return Ticks == ((PersianDateTime)value).Ticks;
            }
            return false;
        }

        public bool Equals(PersianDateTime value)
        {
            return Ticks == value.Ticks;
        }

        public static bool Equals(PersianDateTime t1, PersianDateTime t2)
        {
            return t1.Ticks == t2.Ticks;
        }

        public override int GetHashCode()
        {
            return _dateData.GetHashCode();
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
