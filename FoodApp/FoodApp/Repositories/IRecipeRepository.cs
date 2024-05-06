using FoodApp.Models;

namespace FoodApp.Repositories
{
    public interface IRecipeRepository
    {
        Task AddRecipeAsync(Recipe recipe);
        Task<object?> GetAllRecipesForUserAsync(User user);

    }
}