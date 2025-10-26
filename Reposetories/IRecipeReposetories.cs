

//   https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-example.html

using Models;

namespace Repositories;


public interface IRecipeRepositories
{
    Task<IReadOnlyList<Recipe>> GetAllAsync();
    Task<Recipe?> GetByIdAsync(int id);
    Task<Recipe> AddAsync(string Name,Recipe recipe);
    Task<bool> UpdateAsync( int id, Recipe recipe);
    Task<bool> DeleteAsync(int id);
}


 