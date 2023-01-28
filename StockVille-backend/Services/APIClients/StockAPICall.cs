using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RestSharp;
using Newton.Json.Linq;

namespace StockVille_backend
{
    public class StockAPICall
    {
        public string[] stock_dataset_2 = new string[10] { "SBUX", "UBER", "T", "KO", "WMT", "RBLX", "BA", "DKNG", "ABNB", "JNJ", "NKE", "RIOT" }; //Implement Later

        public Dictionary<string, new int[2]> stock_dataset_1_newPoint = new Dictionary<string, new int[2]>() //x, y coord for next point
        {
            { "MSFT", { 0, 0 } },
            { "AAPL", { 0, 0 } },
            { "GOOG", { 0, 0 } }
            { "TSLA", { 0, 0 } },
            { "ATVI", { 0, 0 } },
            { "AMZN", { 0, 0 } },
            { "DIS", { 0, 0 } },
            { "META", { 0, 0 } },
            { "AMC", { 0, 0 } },
            { "NFLX", { 0, 0 } },
            { "GPRO", { 0, 0 } },
        };

        private string API_token = "PG6UF7SeVxHOR3EV2t1skuI4lsZZwhuR4W5nQiZ7";
        public var client_1 = new RestClient("https://api.stockdata.org/v1/data/quote?symbols=AAPL%2CTSLA%2CMSFT%2CATVI%2CGOOG%2CAMZN%2CDIS%2CMETA%2CNFLX%2CGPRO&api_token=PG6UF7SeVxHOR3EV2t1skuI4lsZZwhuR4W5nQiZ7");
        var client_2 = new RestClient("https://api.stockdata.org/v1/data/quote?symbols=AAPL%2CTSLA%2CMSFT%2CATVI%2CGOOG&api_token=PG6UF7SeVxHOR3EV2t1skuI4lsZZwhuR4W5nQiZ7");

        private void Send_API_Request(string get_request)
        {
            var request = new RestRequest("", DataFormat.Json);

            var response = client_1.Get(Request);
            
            Console.WriteLine(response.Content);



        }
        
    }
}