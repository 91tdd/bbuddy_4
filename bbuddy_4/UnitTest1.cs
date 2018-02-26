using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;

namespace bbuddy_4
{
    [TestClass]
    public class BbuddyTests
    {
        private Accounting _accounting;
        private IBudgetRepo _budgetRepo = Substitute.For<IBudgetRepo>();

        [TestInitialize]
        public void TestInit()
        {
            InitAccounting();
        }

        [TestMethod]
        public void no_budgets()
        {
            GivenBudgets();
            TotalBudgetShouldBe(0, new DateTime(2018, 3, 1), new DateTime(2018, 3, 1));
        }

        [TestMethod]
        public void one_effective_day()
        {
            GivenBudgets(new Budget { YearMonth = "201803", Amount = 31 });
            TotalBudgetShouldBe(1, new DateTime(2018, 3, 1), new DateTime(2018, 3, 1));
        }

        [TestMethod]
        public void no_effective_days_period_before_budget_month()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalBudgetShouldBe(0, new DateTime(2018, 3, 31), new DateTime(2018, 3, 31));
        }

        [TestMethod]
        public void no_effective_days_period_after_budget_month()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalBudgetShouldBe(0, new DateTime(2018, 5, 1), new DateTime(2018, 5, 1));
        }

        [TestMethod]
        public void one_effective_days_period_overlap_budget_StartDay()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalBudgetShouldBe(1, new DateTime(2018, 3, 31), new DateTime(2018, 4, 1));
        }

        [TestMethod]
        public void one_effective_days_period_overlap_budget_LastDay()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalBudgetShouldBe(1, new DateTime(2018, 4, 30), new DateTime(2018, 5, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void invalid_period()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalBudgetShouldBe(1, new DateTime(2018, 4, 30), new DateTime(2018, 5, 1));
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            _budgetRepo.GetAll().Returns(budgets.ToList());
        }

        private void TotalBudgetShouldBe(int expected, DateTime startDate, DateTime endDate)
        {
            Assert.AreEqual(expected, _accounting.TotalBudget(startDate, endDate));
        }

        private void InitAccounting()
        {
            _accounting = new Accounting(_budgetRepo);
        }
    }
}