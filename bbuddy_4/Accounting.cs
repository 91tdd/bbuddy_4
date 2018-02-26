using System;
using System.Linq;

namespace bbuddy_4
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }

    public class Accounting
    {
        private readonly IBudgetRepo _budgetRepo;

        public Accounting(IBudgetRepo budgetRepo)
        {
            _budgetRepo = budgetRepo;
        }

        public decimal TotalBudget(DateTime startDate, DateTime endDate)
        {
            var budgets = _budgetRepo.GetAll();
            if (budgets.Any())
            {
                return EffectiveDays(new Period(startDate, endDate), budgets[0]);
            }
            return 0;
        }

        private static decimal EffectiveDays(Period period, Budget budget)
        {
            if (period.StartDate > budget.EndDay)
            {
                return 0;
            }
            if (period.EndDate < budget.StartDay)
            {
                return 0;
            }
            var effectiveEndDate = period.EndDate > budget.EndDay ? budget.EndDay : period.EndDate;
            var effectiveStartDate = EffectiveStartDate(period, budget);

            var days = (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
            return days;
        }

        private static DateTime EffectiveStartDate(Period period, Budget budget)
        {
            return period.StartDate < budget.StartDay ? budget.StartDay : period.StartDate;
        }
    }
}