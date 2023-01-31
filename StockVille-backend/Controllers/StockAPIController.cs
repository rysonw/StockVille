using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
//Primarily used for adding/updating data in database from API

namespace StockVille_backend.Controllers
{
    public class StockController
    {
        private const string API_URL = "https://api.stockdata.org/v1/data/quote?symbols=AAPL%2CTSLA%2CMSFT%2CATVI%2CGOOG%2CAMZN%2CDIS%2CMETA%2CNFLX%2CGPRO&api_token=PG6UF7SeVxHOR3EV2t1skuI4lsZZwhuR4W5nQiZ7";

        private const string CONNECTION_STRING = "Server=tcp:stockville-db01.database.windows.net,1433;Initial Catalog=db01;Persist Security Info=False;User ID=stockville;Password=Ryson031100;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET method for the stock endpoint
        [HttpGet]
        public HttpResponseMessage Get()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(API_URL).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                }

                // Parse the response data
                var json = response.Content.ReadAsStringAsync().Result;
                var stockData = JsonConvert.DeserializeObject<Stock>(json);

                // Insert the data into the SQL database
                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO Stock (StockSymbol, CompanyName, CurrentPrice) VALUES (@symbol, @name, @price)";
                        cmd.Parameters.AddWithValue("@symbol", stockData.StockSymbol);
                        cmd.Parameters.AddWithValue("@name", stockData.CompanyName);
                        cmd.Parameters.AddWithValue("@price", stockData.CurrentPrice);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
        }

        [HttpPut]
        public JsonResult Put(Department dep)
        {
            string query = @"
                               update dbo.Department
                               set DepartmentName= @DepartmentName
                                where DepartmentId=@DepartmentId
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", dep.DepartmentId);
                    myCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                               delete from dbo.Department
                                where DepartmentId=@DepartmentId
                                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }


    }
}