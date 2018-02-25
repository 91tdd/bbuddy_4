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
                var days = (endDate.AddDays(1) - startDate).Days;
                return days;
            }
            return 0;
        }
    }
}