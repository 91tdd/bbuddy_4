using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace bbuddy_4
{
    [TestClass]
    public class BbuddyTests
    {
        private Accounting _accounting;

        [TestInitialize]
        public void TestInit()
        {
            InitAccounting();
        }

        [TestMethod]
        public void no_budgets()
        {
            TotalBudgetShouldBe(0, new DateTime(2018, 3, 1), new DateTime(2018, 3, 1));
        }

        private void TotalBudgetShouldBe(int expected, DateTime startDate, DateTime endDate)
        {
            Assert.AreEqual(expected, _accounting.TotalBudget(startDate, endDate));
        }

        private void InitAccounting()
        {
            _accounting = new Accounting();
        }
    }
}