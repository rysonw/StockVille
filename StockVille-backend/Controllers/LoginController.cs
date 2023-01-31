using Microsoft.AspNetCore.Mvc;
using StockVille_backend.Models;
using StockVille_backend.Services.Security;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    [HttpGet]
    public IActionResult GetData()
    {
        var data = "example data";
        return Ok(data);
    }

    [HttpPost]
    public IActionResult PostData([FromBody] object payload)
    {
        // handle the posted data
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Login([FromBody] LoginRequest request)
    {
        // Hash the password using the password hashing function
        string hashedPassword = PasswordHashing.HashPassword((string)request.Password);

        // Store the hashed password in a database or use it for authentication purposes
        await Database.StoreHashedPasswordAsync(hashedPassword);

        return Ok();
    }
}

[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly MyDBContext _context;

    public RegistrationController(MyDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        _context.Users.Add(user); //Add to database
        _context.SaveChanges();

        return Ok(); //Returns 200, can also add data inside as an arg to return
    }
}


public class LoginRequest
{
    public string Password { get; set; }
}





