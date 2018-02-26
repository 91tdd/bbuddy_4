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

        public DateTime EffectiveEndDate(Budget budget)
        {
            var effectiveEndDate = EndDate > budget.LastDay ? budget.LastDay : EndDate;
            return effectiveEndDate;
        }

        public DateTime EffectiveStartDate(Budget budget)
        {
            return StartDate < budget.StartDay ? budget.StartDay : StartDate;
        }

        public decimal EffectiveDays(Budget budget)
        {
            if (StartDate > budget.LastDay)
            {
                return 0;
            }
            if (EndDate < budget.StartDay)
            {
                return 0;
            }
            var effectiveEndDate = EffectiveEndDate(budget);
            var effectiveStartDate = EffectiveStartDate(budget);

            var days = (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
            return days;
        }
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
                return new Period(startDate, endDate).EffectiveDays(budgets[0]);
            }
            return 0;
        }
    }
}