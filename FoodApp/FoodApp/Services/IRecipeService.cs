using FoodApp.Models;

namespace FoodApp.Services
{
    public interface IRecipeService
    {
        Task AddRecipeAsync(Recipe recipe);
        Task<object?> GetAllRecipesForUserAsync(int userId);
    }
}