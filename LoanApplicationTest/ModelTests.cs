using LoanApplication.Models;

namespace LoanApplicationTest
{
    public class ModelTests
    {
        [Fact]
        public void LoanTest()
        {
            ILoan loan = new HouseLoan()
            {
                LoanId = 1,
                LoanPeriods = 10,
                LoanRate = 0.035M,
                LoanSize = 1000000,
            };
            Assert.NotNull(loan);
            Assert.True(loan.LoanId == 1);
            Assert.True(loan.LoanPeriods == 10);
            Assert.True(loan.LoanRate == 0.035M);
            Assert.True(loan.LoanSize == 1000000);

            Assert.True(loan.GetAnnualPayment() - 120241 < 10);
            Assert.True(loan.GetAnnualLoanSizeList().Count == loan.LoanPeriods);
            Assert.True(loan.GetAnnualLoanSizeList().Min() < 100);
        }
    }
}