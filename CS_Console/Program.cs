using CS_Console.Model;
using CS_Console.EquityRepo;
using BondConsoleApp.Repository;
using BondConsoleApp.Models;

namespace CS_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server = 192.168.0.13\sqlexpress,49753; Database = IVP_OS_CS; user Id = sa; Password = sa@12345678; TrustServerCertificate = True";
            string csvFilePath = @"C:\Users\snvernekar\Downloads\Bonds.csv";
            string csvEquitiesFilePath = @"C:\Users\snvernekar\Downloads\Equities.csv";

            //IEquity _obj = new EquityOperation();
            //Controller obj = new Controller(_obj);
            //BondOperations bond = new BondOperations(connectionString);
            //var bondData = new EditBondModel
            //{
            //    SecurityID = 31,
            //    SecurityDescription = "Updated Bond Description",
            //    Coupon = 5.5m,
            //    IsCallable = true,
            //    PenultimateCouponDate = new DateTime(2030, 12, 31),
            //    FormPFCreditRating = "A+",
            //    AskPrice = 102.75m,
            //    BidPrice = 101.50m
            //};
            //bond.UpdateBondData(bondData);
            //bond.DeleteBondData(33);
            //bond.ImportDataFromCsv(csvFilePath);

            EquityOperation obj = new EquityOperation();
            EditEquityModel model = new EditEquityModel
            {
                SecurityID =55,
                SecurityDescription = "Updated Equity Description",
                PricingCurrency = "USD",
                TotalSharesOutstanding = 5000000m,
                OpenPrice = 150.75m,
                ClosePrice = 152.30m,
                DividendDeclaredDate = DateTime.Now.AddDays(-7),
                FormPFCreditRating = "AAA"
            };
            obj.UpdateSecurityData(model);
            //obj.DeleteSecurityData(57);
            //obj.ImportDataFromCsv(csvEquitiesFilePath);

            Console.ReadLine();

            //obj.ImportData(csvFilePath);
            //obj.DeleteData(1);
            //EditSecurityModel esmObj = new EditSecurityModel()
            //{
            //    securityId = 1,
            //    description = " International Business Machines Corp",   
            //    pricingCurrency = "USD",
            //    totalSharesOutstanding = 989660474,
            //    openPrice = 164.160000000m,
            //    closePrice = 164.160000000m,
            //    dividendDeclaredDate = new DateTime(2002, 09, 15),
            //    pfCreditRating = "AA+"
            //};
            //obj.UpdateData(esmObj);
            //List<EditEquityModel> equity = obj.GetData();
            //foreach (var equityItem in equity)
            //{
            //    Console.WriteLine($"{equityItem.securityId} - {equityItem.securityName} - {equityItem.description} - {equityItem.pricingCurrency} - {equityItem.totalSharesOutstanding} - {equityItem.openPrice} - {equityItem.closePrice} - {equityItem.dividendDeclaredDate} - {equityItem.pfCreditRating}");
            //}
        }
    }
}
