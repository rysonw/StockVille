using System;
using System.Collections.Generic;
using System.Timers;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace StockVille_backend.API
{
    public class StockAPICall
    {
        //Every 5 minutes
        private string API_token = "PG6UF7SeVxHOR3EV2t1skuI4lsZZwhuR4W5nQiZ7"; //Move to .env file
        private RestClient stock_client;
        public string[] stock_dataset_1 = new string[5] { "MSFT", "UBER", "AAPL", "GOOG", "RBLX" };

        static System.Timers.Timer timer; //Every Minute; make an api call and write current time(x) and price(y) to graph
        public static void StartTimer()
        {
            timer = new System.Timers.Timer(300000); // 300000 milliseconds = 5 minutes
            timer.AutoReset = true;
            timer.Enabled = true;
            //Make API call
        }

        public void StockDataAPICall(object sender, ElapsedEventArgs e) {
            StockAPICall stock = new StockAPICall();
            stock.stock_client = new RestClient("https://api.stockdata.org/v1/data/quote?symbols=MSFT%2CUBER%2CAAPL%2CGOOG%2CRBLX%2CMETA%2CABNB%2CNFLX%2CNFLX%2CRIOT&api_token=" + stock.API_token);
            //var request = new RestRequest(Method.GET);
            //IRestResponse response = stock.stock_client.Execute(request);
            //Console.WriteLine(response.Content); //Should be stock info in json format; need to parse

        }
        
    }

}


    
    
        