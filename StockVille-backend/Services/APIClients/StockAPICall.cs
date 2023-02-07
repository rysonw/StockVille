using System;
using System.Collections.Generic;
using System.Timers;
using System.Linq;

using System.Text;
using System.Threading;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace StockVille_backend.API
{
    public class StockAPICall
    {

        private string API_token = "PG6UF7SeVxHOR3EV2t1skuI4lsZZwhuR4W5nQiZ7";
        private RestClient stock_client;
        public string[] stock_dataset_1 = new string[10] { "MSFT", "UBER", "AAPL", "GOOG", "RBLX", "META", "AMZN", "ABNB", "NFLX", "RIOT" };

        static System.Timers.Timer timer; //Every Minute; make an api call and write current time(x) and price(y) to graph
        static void Main(string[] args)
        {
            timer = new System.Timers.Timer(60000); // interval is set to 60,000 milliseconds (1 minute)
            //timer.Elapsed += Timer_Elapsed;
            timer.Start();
            Console.ReadLine();
        }

        public StockAPICall() {
            stock_client = new RestClient("https://api.stockdata.org/v1/data/quote?symbols=MSFT%2CUBER%2CAAPL%2CGOOG%2CRBLX%2CMETA%2CABNB%2CNFLX%2CNFLX%2CRIOT&api_token=PG6UF7SeVxHOR3EV2t1skuI4lsZZwhuR4W5nQiZ7");


        }
        
    }

}


    
    
        