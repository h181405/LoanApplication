using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanApplication.Models;
using LoanApplication.DTO;

namespace LoanApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly LoanDbContext _context;

        public LoanController(LoanDbContext context)
        {
            _context = context;
        }

        // GET: api/Loan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ILoan>>> GetHouseLoans()
        {
          if (_context.HouseLoans == null)
          {
              return NotFound();
          }
            return await _context.HouseLoans.ToListAsync();
        }

        // GET: api/Loan/5
        [HttpGet("{periods}/{size}")]
        public IEnumerable<AnnualPaymentDTO> GetHouseLoan(int periods, long size)
        {
            var TempLoan = new HouseLoan
            {
                LoanId = -1,
                LoanPeriods = periods,
                LoanSize = size,
            };
            TempLoan.LoanRate = TempLoan.CalculateLoanRate();

            List<AnnualPaymentDTO> AnnualPayments = new List<AnnualPaymentDTO>();

            var LoanSizeTemp = size;
            var AnnualPayment = TempLoan.GetAnnualPayment();

            foreach (var loanSize in TempLoan.GetAnnualLoanSizeList())
            {
                var LoanAdded = (int)(LoanSizeTemp * TempLoan.LoanRate);

                AnnualPayments.Add(new AnnualPaymentDTO
                {
                    LoanLeft = loanSize,
                    LoanAdded = LoanAdded,
                    LoanSubtracted = AnnualPayment,
                    LoanChanged = LoanAdded-AnnualPayment,
                });

                LoanSizeTemp = (long)loanSize;
            }

            return AnnualPayments;

        }
    }
}
