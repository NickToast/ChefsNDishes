#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using ChefsNDishes.Models;

namespace ChefsNDishes;

public class ChefsDishes
{
    [Key] 
    public int ChefsDishesId { get; set; }

    public int ChefId { get; set; }
    public Chef Chef { get; set; }

    public int DishId { get; set; }
    public Dish Dish { get; set; } 

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}