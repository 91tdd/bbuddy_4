using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

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
            _budgetRepo.GetAll().Returns(new List<Budget>());
            TotalBudgetShouldBe(0, new DateTime(2018, 3, 1), new DateTime(2018, 3, 1));
        }

        [TestMethod]
        public void one_effective_day()
        {
            _budgetRepo.GetAll().Returns(new List<Budget> { new Budget { YearMonth = "201803", Amount = 31 } });
            TotalBudgetShouldBe(1, new DateTime(2018, 3, 1), new DateTime(2018, 3, 1));
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