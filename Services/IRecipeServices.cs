


using Models;

namespace Services;

public interface IRecipeServices
{


    Task<IReadOnlyList<Recipe>> GetAllAsync();
    Task<Recipe?> GetByIdAsync(int id);
    Task<Recipe> CreatAsync(string Name, List<string> Ingredients, List<string> Steps);
    Task<bool> UpdateAsync( int id, string Name, List<string> Ingredients, List<string> Steps);
    Task<bool> DeleteAsync(int id);

}
