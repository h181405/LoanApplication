namespace LoanApplication.Models
{
    public class HouseLoan : Loan, ILoan
    {
        public String? LoanName { get; set; }

        public Decimal CalculateLoanRate()
        {
            Double Factor = LoanSize/100000;
            Factor /= LoanPeriods;
            Decimal Result = (decimal)(Factor * Factor / 12 - Factor * 0.75 + 31 / 6);
            return 0.035M;
        }
    }
}
