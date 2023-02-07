using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StockVille_backend.Models;
using StockVille_backend.Services.Security;
using System.Data;
using System.Data.SqlClient;

[ApiController]
[Route("api/update_user_info")]
public class FormController : ControllerBase
{

    private readonly IConfiguration _configuration;

    public FormController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult UpdateUserData(string firstName, string lastName, string email, string phoneNumber, string address, int buyingPower, int profit, string username, string password) //Puling from SQL Database; IACtionResult is used for HTTP return codes
    {
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
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            
                        }
                        reader.Close();
                        connection.Close();
                        return Ok();
                    }
                    else
                    {
                        reader.Close();
                        connection.Close();
                        return Problem();
                    }
                }
            }
        }
    }

}






