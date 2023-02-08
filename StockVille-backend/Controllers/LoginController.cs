using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using StockVille_backend.Models;
using StockVille_backend.Services.Security;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

public class LoginRequest
{
    public string User { get; set; }
    public string Password { get; set; }
}

[ApiController]
[Route("~/api/login_data")]
//[Produces("application/json")] /*Swagger UI Testing purposes*/
//[ProducesResponseType(typeof(Dictionary<string, object>), 200)]
public class LoginController : ControllerBase
{

    private readonly IConfiguration _configuration;

    public LoginController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult TryLogin([FromBody] LoginRequest request) //Puling from SQL Database; IActionResult is used for HTTP return codes
    {
        var user = request.User;
        var password = request.Password;
        string query;
        string hashedPassword = PasswordHashing.HashPassword(password);

        if (user.Contains('@'))
        {
            query = $"SELECT * FROM Users WHERE Email = '{user}' AND Password = '{password}';";
        }
        else
        {
            query = $"SELECT * FROM Users WHERE Username = '{user}' AND Password = '{password}';";
        }

        Dictionary<string, object> currUserData = new Dictionary<string, object>();
        string connectionString = _configuration.GetConnectionString("PrimaryDatabase");

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to DB");
            }

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //command.Parameters.AddWithValue("@user", user); //Used to mask the actual data being passed through
                //command.Parameters.AddWithValue("@password", hashedPassword);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (reader.GetName(i) == "Password" || reader.GetName(i) == "Username") { continue; }
                            else { currUserData.Add(reader.GetName(i), reader.GetValue(i)); }
                        }
                        reader.Close();
                        connection.Close();
                        var json = JsonConvert.SerializeObject(currUserData);
                        return Ok(currUserData);
                    }
                    else
                    {
                        reader.Close();
                        connection.Close();
                        return Problem("Bad Request");
                    }
                }
            }
        }
    }
}

    [ApiController]
    [Route("/api/register_data")]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult CreateUserThorughRegister(string firstName, string lastName, string email, string phoneNumber, string address, int buyingPower, int profit, string username, string password) //Puling from SQL Database; IACtionResult is used for HTTP return codes
        {
            //mock data
            //string firstName = "Barack Obama";
            //string lastName = "Doe";
            //string email = "rock.ob@example.com";
            //string phoneNumber = "555-555-5555";
            //string address = "123 Main St";
            //decimal buyingPower = 10.00M;
            //decimal profit = 10.00M;
            //string username = "b_obama";
            //string password = "password";

            string hashedPassword = PasswordHashing.HashPassword(password);
            string query = $"INSERT INTO Users (FirstName, LastName, Email, PhoneNumber, Address, BuyingPower, ProfitForDay, Username, Password) VALUES ('{firstName}', '{lastName}', '{email}', '{phoneNumber}', '{address}', {buyingPower}, {profit}, '{username}', '{hashedPassword}');";
            string connectionString = _configuration.GetConnectionString("PrimaryDatabase");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error connecting to DB");
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Close();
                        connection.Close();
                        return Ok(); //200
                    }

                    catch
                    {
                        connection.Close();
                        return Problem(); //Bad request code
                    }


                }
            }
        }

}








