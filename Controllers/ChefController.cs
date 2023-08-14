//Chef controller
//Chef models & login models
//Chef views folders & views
//Routes home, register, login, logout
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class ChefController : Controller
{
    private readonly ILogger<ChefController> _logger;
    // Add a private variable of type MyContext (or whatever you named your context file)
    private MyContext db;         
    // Here we can "inject" our context service into the constructor 
    // The "logger" was something that was already in our code, we're just adding around it   
    public ChefController(ILogger<ChefController> logger, MyContext context)    
    {        
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        db = context;    
    }        

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Chef> allChefs = db.Chefs.Include(d => d.AllDishes).ToList();

        return View("Chef", allChefs);
    }


    [HttpGet("chefs/new")]
    public IActionResult New()
    {
        return View("AddChef");
    }

    [HttpPost("chefs/create")]
    public IActionResult Create(Chef newChef)
    {
        if (!ModelState.IsValid)
        {
            return View ("New");
        }
        db.Chefs.Add(newChef);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}