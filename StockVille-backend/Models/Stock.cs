using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace StockVille_backend.Models { 
    public class Stock
    {
        public int stockID { get; set; }
        public int StockSymbol { get; set; }
        public string CompanyName { get; set; }
        public double StockChange { get; set; }
        public double CurrPrice { get; set; }

        List<double[]> StockDataPoints = new List<double[]>(); //X: Curr Time; Y: Price

    }
}
