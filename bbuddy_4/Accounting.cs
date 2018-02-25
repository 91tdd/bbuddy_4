using System;
using System.Linq;

namespace bbuddy_4
{
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
                return EffectiveDays(startDate, endDate);
            }
            return 0;
        }

        private static decimal EffectiveDays(DateTime startDate, DateTime endDate)
        {
            var days = (endDate.AddDays(1) - startDate).Days;
            return days;
        }
    }
}