
using System.Runtime.CompilerServices;
using K4os.Compression.LZ4.Streams;
using Models;
using Repositories;


namespace Services;


 
public class RecipesServices : IRecipeServices
{
    private readonly IRecipeRepositories _recipeRepositories;

  public RecipesServices(IRecipeRepositories recipeRepositories)
    {
        _recipeRepositories = recipeRepositories;
    }


    public async Task<IReadOnlyList<Recipe>> GetAllAsync()
    {
        return await _recipeRepositories.GetAllAsync();
    }


    public async Task<Recipe?> GetByIdAsync(int id)
    {
        return await _recipeRepositories.GetByIdAsync(id);
    }


    public async Task<Recipe> CreatAsync(string Name, List<string> Ingredients, List<string> Steps)
    {
        if (string.IsNullOrWhiteSpace(Name) || Name.Length < 3 || Name.Length > 100)

            throw new ArgumentException("Name can not bee empty, les then 3 ore higher then 100");

        if (Ingredients.Count == 0)
            throw new ArgumentException("Ingredients cannot be empty");


        if (Steps.Count < 3 || Steps.Count > 50)

            throw new ArgumentException("Steps cannot be les then 3  ore higher then 50");



   var recipe = new Recipe
        {
            Name = Name,
            Ingredients = Ingredients,
            Steps = Steps
        };

        return await _recipeRepositories.AddAsync(recipe);
    }
       

    public async Task<bool> UpdateAsync(string Name, List<string> Ingredient, List<string> Steps) { }
    
    public async Task<bool> DeleteAsync(int id){}



}


