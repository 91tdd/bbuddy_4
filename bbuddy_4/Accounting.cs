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
                return EffectiveDays(startDate, endDate, budgets[0]);
            }
            return 0;
        }

        private static decimal EffectiveDays(DateTime startDate, DateTime endDate, Budget budget)
        {
            if (endDate < budget.StartDay)
            {
                return 0;
            }
            var days = (endDate.AddDays(1) - startDate).Days;
            return days;
        }
    }
}