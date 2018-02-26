using System;

namespace bbuddy_4
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }

        public DateTime StartDay
        {
            get
            {
                var startDayOfString = this.YearMonth + "01";
                return DateTime.ParseExact(startDayOfString, "yyyyMMdd", null);
            }
        }

        public DateTime LastDay
        {
            get
            {
                var daysInMonth = DateTime.DaysInMonth(this.StartDay.Year, this.StartDay.Month);
                return new DateTime(StartDay.Year, StartDay.Month, daysInMonth);
            }
        }

        public int DaysInMonth
        {
            get
            {
                var daysInMonth = DateTime.DaysInMonth(this.StartDay.Year, this.StartDay.Month);
                return daysInMonth;
            }
        }
    }
}