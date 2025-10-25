

//   https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-example.html

using Models;

namespace Repositories;


public interface IRecipeRepositories
{
    Task<IReadOnlyList<Recipe>> GetAllAsync();
    Task<Recipe?> GetByIdAsync(int Id);
    Task<Recipe> CreateAsync(Recipe recipes);
    Task<bool> UpdateAsync(Recipe recipes);
    Task<bool> DeleteAsync(int id);
}


