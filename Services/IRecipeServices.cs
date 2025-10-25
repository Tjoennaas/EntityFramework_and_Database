


using Models;

namespace Services;

public interface IRecipeServices
{
    Task<IReadOnlyList<Recipe>> GetAllAsync();
    Task<Recipe?> GetByIdAsync(int Id);
    Task<Recipe> CreateAsync( Recipe recipes);
    Task<bool> UpdateAsync(Recipe recipes);
    Task<bool> DeleteAsync(int id);
}
