using Microsoft.AspNetCore.Mvc;
using AcxiomCRM.Data;
using AcxiomCRM.Models;
using System.Linq;

namespace AcxiomCRM.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class CustomersApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public CustomersApiController(ApplicationDbContext context) { _context = context; }

    [HttpGet]
    public IActionResult Get() => Ok(_context.Customers.ToList());
    
    [HttpPost]
    public IActionResult Post([FromBody] Customer customer) {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return Ok(customer);
    }
}
