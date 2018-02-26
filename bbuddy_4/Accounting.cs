using System;

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
            var totalBudget = 0m;
            foreach (var budget in budgets)
            {
                totalBudget += budget.EffectiveAmount(period);
            }
            return totalBudget;
        }
    }
}