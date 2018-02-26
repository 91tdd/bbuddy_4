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
                return new DateTime(StartDay.Year, StartDay.Month, GetDaysInMonth());
            }
        }

        private int GetDaysInMonth()
        {
            return DateTime.DaysInMonth(this.StartDay.Year, this.StartDay.Month);
        }

        public int DailyAmount()
        {
            return Amount / GetDaysInMonth();
        }
    }
}