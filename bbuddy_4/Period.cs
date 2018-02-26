using System;

namespace bbuddy_4
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException();
            }
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime EndDate { get; private set; }
        public DateTime StartDate { get; private set; }

        public decimal EffectiveDays(Period period)
        {
            if (StartDate > period.EndDate)
            {
                return 0;
            }
            if (EndDate < period.StartDate)
            {
                return 0;
            }
            var effectiveEndDate = EffectiveEndDate(period.EndDate);
            var effectiveStartDate = EffectiveStartDate(period.StartDate);

            var days = (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
            return days;
        }

        private DateTime EffectiveEndDate(DateTime periodEndDate)
        {
            var effectiveEndDate = EndDate > periodEndDate ? periodEndDate : EndDate;
            return effectiveEndDate;
        }

        private DateTime EffectiveStartDate(DateTime periodStartDate)
        {
            return StartDate < periodStartDate ? periodStartDate : StartDate;
        }
    }
}