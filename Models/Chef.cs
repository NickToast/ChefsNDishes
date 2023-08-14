#pragma warning disable CS8618

//Allows you use a feature of C# to do validations
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models;

public class Chef
{
    [Key] //UNIQUE KEY
    public int ChefId { get; set; }

    [Required(ErrorMessage = "First name is required to add Chef")]
    [Display(Name = "First Name")]
    public string FirstName { get; set;}

    [Required(ErrorMessage = "Last name is required to add Chef")]
    [Display(Name = "Last Name")]
    public string LastName { get; set;}

    [Required(ErrorMessage = "Please enter a valid Date of Birth")]
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> AllDishes { get; set; } = new List<Dish>();

}