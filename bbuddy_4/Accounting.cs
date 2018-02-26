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
            var period = new Period(startDate, endDate);
            var budgets = _budgetRepo.GetAll();
            if (budgets.Any())
            {
                var budget = budgets[0];
                var effectiveDays = period.EffectiveDays(new Period(budget.StartDay, budget.LastDay));
                return effectiveDays * budget.DailyAmount();
            }
            return 0;
        }
    }
}