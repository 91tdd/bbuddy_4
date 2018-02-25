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
    }
}