using Microsoft.EntityFrameworkCore;
using System.Xml;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Transactions;

namespace StockVille_backend.Models { 
    public class User
    {
        public int userID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ?PhoneNumber { get; set; }
        public string ?Address { get; set; }
        public double BuyingPower { get; set; }
        public double ProfitForDay { get; set; } //Create Function to calculate profit; 


    }
}
