using System;
using System.Collections.Generic;

namespace LoanApplication.Models;

public abstract class Loan
{
    public int LoanId { get; set; }

    public int LoanPeriods { get; set; }

    public decimal LoanRate { get; set; }

    public long LoanSize { get; set; }

    public int GetAnnualPayment()
    {
        return (int)((double) LoanRate * LoanSize / (1 - Math.Pow((double)(1 + LoanRate), -LoanPeriods)));
    }
    public List<double> GetAnnualLoanSizeList()
    {
        List<double> result = new List<double>();
        int payment = GetAnnualPayment();
        long CurrentLoanSize = LoanSize;
        for (int i = 0; i < LoanPeriods; i++)
        {
            CurrentLoanSize += (long) (LoanRate * CurrentLoanSize - payment);
            result.Add(CurrentLoanSize);
        }
        return result;
    }
}
