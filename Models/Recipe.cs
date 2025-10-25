

//https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-9.0&tabs=visual-studio#the-model-and-database-context-classes

// https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwith-nrt


using System.ComponentModel.DataAnnotations;


namespace Models;

public class Recipe
{


    [Key]
    public int Id { get; set; }

    [Required]
   [StringLength(100, MinimumLength = 3)] 
    public string Name { get; set; } = "";

    [MinLength(1)]
    public List<string> Ingredients { get; set; } = new();


    [MinLength(1)]
    [MaxLength(50)]
    public List<string> Steps { get; set; } = new();

}