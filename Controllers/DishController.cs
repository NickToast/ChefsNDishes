using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;


public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;

    private MyContext db;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet("dishes")]
    public IActionResult Index()
    {
        List<Dish> allDishes = db.Dishes.Include(d => d.Creator).OrderBy(d => d.CreatedAt).ToList();
        return View (allDishes);
    }

    [HttpGet("dishes/new")]
    public IActionResult New()
    {
        ViewBag.allChefs = db.Chefs.ToList();
        return View("AddDish");
    }

    [HttpPost("dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.allChefs = db.Chefs.ToList();
            return View("Index");
        }
        db.Dishes.Add(newDish);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}