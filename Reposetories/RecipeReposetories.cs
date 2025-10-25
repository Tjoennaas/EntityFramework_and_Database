
//https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-9.0&tabs=visual-studio#use-the-mapgroup-api


// https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-charset.html


using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories;

public class RecipeRepositories : IRecipeRepositories
{
    private readonly RecipeContext _database;
    public RecipeRepositories(RecipeContext database) => _database = database;




    public async Task<IReadOnlyList<Recipe>> GetAllAsync()
    {
        return await _database.Recipes.ToListAsync();
    }

    public async Task<Recipe?> GetByIdAsync(int id)
    {
        return await _database.Recipes.FindAsync(id);
    }

    public async Task<Recipe> AddAsync(Recipe recipe)
    {
        _database.Recipes.Add(recipe);
        await _database.SaveChangesAsync();

        return recipe;
    }

    public async Task<bool> UpdateAsync(int id, Recipe recipe)
    {
        var existing = await _database.Recipes.FindAsync(id);
        if (existing is null)
        {
            return false;
        }
  _database.Entry(existing).CurrentValues.SetValues(recipe);
        await _database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var recipe = await _database.Recipes.FindAsync(id);
        if (recipe is null)
        {
            return false;
        }

        _database.Recipes.Remove(recipe);
        await _database.SaveChangesAsync();

        return true;
    }
}

