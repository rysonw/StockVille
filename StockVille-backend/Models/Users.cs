using Microsoft.EntityFrameworkCore;
using System.Xml;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Transactions;

namespace StockVille_backend.Models { 
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ?PhoneNumber { get; set; }
        public string ?Address { get; set; }
        public double BuyingPower { get; set; }
        public string ProfitForDay { get; set; } //Create Function to calculate profit; 
        
        List<double[]> StockDataPoints = new List<double[]>(); //X: Curr Time; Y: Price

    }
}
