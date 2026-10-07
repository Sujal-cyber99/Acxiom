using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AcxiomCRM.Data;
using System.Linq;

namespace AcxiomCRM.Controllers;

[Authorize]
public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;
    public DashboardController(ApplicationDbContext context) { _context = context; }

    public IActionResult Index()
    {
        ViewBag.TotalCustomers = _context.Customers.Count();
        ViewBag.TotalLeads = _context.Leads.Count();
        ViewBag.OpenOpportunities = _context.Opportunities.Count(o => o.Status != "Closed");
        return View();
    }
}
