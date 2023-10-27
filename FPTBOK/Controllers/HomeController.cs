using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FPTBOK.Models;
using Microsoft.EntityFrameworkCore;

namespace FPTBOK.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly testASMContext _context;
    public HomeController(ILogger<HomeController> logger,testASMContext context )
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // return _context.Products != null ? 
        //                   View(await _context.Products.ToListAsync()) :
        //                   Problem("Entity set 'testASMContext.Products'  is null.");
        var testContext = _context.Products.Include(b => b.IdCatNavigation);
        return View(await testContext.ToListAsync());
    }
    public async Task<IActionResult> Search(string search)
    {
        
        if (string.IsNullOrEmpty(search))
            {
                // Handle the case when no search term is provided. You can return a default view or a message.
                return View(await _context.Products.Include(p => p.IdCatNavigation).ToListAsync());
            }

            var matchingProducts = _context.Products
                .Include(p => p.IdCatNavigation).Where(p => p.Name.Contains(search) || p.Description.Contains(search))
                .ToList();
                return View(matchingProducts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
