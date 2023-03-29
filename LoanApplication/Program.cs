using LoanApplication.Models;
using Microsoft.EntityFrameworkCore;

CreateDB();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LoanDbContext>(
        options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("LoanDB"));
        });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

static List<ILoan> CreateLoanList()
{
    return new List<ILoan>()
    {
        new HouseLoan()
        {
            LoanId = 1,
            LoanPeriods = 10,
            LoanRate = 0.035M,
            LoanSize = 1000000,
            LoanName = "HouseLoan1",
        },
        new HouseLoan()
        {
            LoanId = 2,
            LoanPeriods = 20,
            LoanRate = 0.035M,
            LoanSize = 1000000,
            LoanName = "HouseLoan2",
        },
        new HouseLoan()
        {
            LoanId = 3,
            LoanPeriods = 30,
            LoanRate = 0.035M,
            LoanSize = 1000000,
            LoanName = "HouseLoan3",
        },
        new HouseLoan()
        {
            LoanId = 4,
            LoanPeriods = 10,
            LoanRate = 0.035M,
            LoanSize = 2000000,
            LoanName = "HouseLoan4",
        },
        new HouseLoan()
        {
            LoanId = 5,
            LoanPeriods = 20,
            LoanRate = 0.035M,
            LoanSize = 2000000,
            LoanName = "HouseLoan5",
        },
        new HouseLoan()
        {
            LoanId = 6,
            LoanPeriods = 30,
            LoanRate = 0.035M,
            LoanSize = 2000000,
            LoanName = "HouseLoan6",
        },
        new HouseLoan()
        {
            LoanId = 7,
            LoanPeriods = 10,
            LoanRate = 0.035M,
            LoanSize = 5000000,
            LoanName = "HouseLoan7",
        },
        new HouseLoan()
        {
            LoanId = 8,
            LoanPeriods = 20,
            LoanRate = 0.035M,
            LoanSize = 5000000,
            LoanName = "HouseLoan8",
        },
        new HouseLoan()
        {
            LoanId = 9,
            LoanPeriods = 30,
            LoanRate = 0.035M,
            LoanSize = 5000000,
            LoanName = "HouseLoan9",
        }
    };
}

static void CreateDB()
{
    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

    var options = new DbContextOptionsBuilder<LoanDbContext>()
        .UseSqlServer(config.GetConnectionString("LoanDB")).Options;

    using var db = new LoanDbContext(options);

    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    var loanList = CreateLoanList();
    loanList.ForEach(loan => db.HouseLoans.Add((HouseLoan)loan));
    db.SaveChanges();
}
