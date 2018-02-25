using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace bbuddy_4
{
    [TestClass]
    public class BbuddyTests
    {
        [TestMethod]
        public void no_budgets()
        {
            var accounting = new Accounting();
            var totalBudget = accounting.TotalBudget(new DateTime(2018, 3, 1), new DateTime(2018, 3, 1));
            Assert.AreEqual(totalBudget, 0);
        }
    }
}