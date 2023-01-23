using System.Text.Json.Nodes;

var client = new RestClient("https://api.stockdata.org/v1/data/quote?symbols=AAPL%2CTSLA%2CMSFT%2CATVI%2CGOOG&api_token=PG6UF7SeVxHOR3EV2t1skuI4lsZZwhuR4W5nQiZ7");
//client.Timeout = -1;
var request = new RestRequest("", DataFormat.Json);

var response = client.Get(Request);

var json = JsonObject.Parse(response.Content["results"]);

Console.WriteLine(response.Content);

//request.AddQueryParameter("api_token", "PG6UF7SeVxHOR3EV2t1skuI4lsZZwhuR4W5nQiZ7");
//request.AddQueryParameter("symbols", "aapl,amzn");
//request.AddQueryParameter("limit", "50");

//IRestResponse response = client.Execute(request);
//Console.WriteLine(response.Content);