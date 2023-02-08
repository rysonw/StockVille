using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StockVille_backend.Models;
using StockVille_backend.Services.Security;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Net;

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
        string query = "UPDATE users " +
            "SET FirstName = CASE WHEN FirstName <> firstName THEN firstName ELSE FirstName END," +
            "LastName = CASE WHEN LastName <> lastName THEN lastName ELSE LastName END," +
            "Email = CASE WHEN Email <> email THEN email ELSE Email END," +
            "PhoneNumber = CASE WHEN PhoneNumber <> phoneNumber THEN phoneNumber ELSE PhoneNumber END," +
            "Address = CASE WHEN Address <> address THEN address ELSE Address END," +
            "BuyingPower = CASE WHEN BuyingPower <> buyingPower THEN buyingPower ELSE BuyingPower END," +
            "ProfitForDay = CASE WHEN ProfitForDay <> profit THEN profit ELSE ProfitForDay END," +
            "Username = CASE WHEN Username <> username THEN username ELSE Username END," +
            "Password = CASE WHEN Password <> password THEN password ELSE Password END," +
            "WHERE userID = @userID;";


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
                return Problem("Error connecting to database");
            }

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    int result = command.ExecuteNonQuery(); //returns the amount of rows changed
                    Console.WriteLine($"{result} fields updated.");
                    connection.Close();
                    return Ok();
                }

                catch(Exception ex)
                {
                    connection.Close();
                    Console.WriteLine(ex);
                    return Problem("Error updating user data");
                }
           
            }
        }
    }
}






