namespace LoanApplication.Models
{
    public interface ILoan
    {
        public int LoanId { get; set; }

        public int LoanPeriods { get; set; }

        public decimal LoanRate { get; set; }

        public long LoanSize { get; set; }

        public string? LoanName { get; set;}
        public int GetAnnualPayment();
        public List<double> GetAnnualLoanSizeList();
        public Decimal CalculateLoanRate();
    }
}
