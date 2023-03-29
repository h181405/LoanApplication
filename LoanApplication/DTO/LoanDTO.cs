namespace LoanApplication.DTO
{
    public class LoanDTO
    {
        public string? Name { get; set; }

        public int LoanPeriods { get; set; }

        public decimal LoanRate { get; set; }

        public long LoanSize { get; set; }

        public int AnnualPayment { get; set; }
    }
}
