#pragma warning disable CS8618

//Allows you use a feature of C# to do validations
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace ChefsNDishes.Models;

public class Dish
{
    [Key] //UNIQUE KEY
    public int DishId { get; set; }

    [Required(ErrorMessage = "Name of dish is required to add a dish")]
    [Display(Name = "Name of Dish")]
    public string DishName { get; set;}

    // [Required(ErrorMessage = "Chef name is required to add a dish")]
    // [Display(Name = "Chef's Name")]
    // public string ChefName { get; set;}

    [Required(ErrorMessage = "Calories are required to add a dish")]
    [Range(1, Int32.MaxValue)]
    [Display(Name = "Calories")]
    public int NumCalories { get; set; }

    [Required(ErrorMessage = "Tastiness is required to add a dish")]
    [Range(1,6, ErrorMessage = "Tastiness must be between 1 and 5")]
    public int Tastiness { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [Required]
    [Display(Name = "Chef's Name")]
    public int ChefId { get; set; }

    //adding instance of the Chef class
    public Chef? Creator { get; set; }
}