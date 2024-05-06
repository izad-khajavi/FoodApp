using FoodApp.Models;

namespace FoodApp.Services
{
    public interface IRecipeIngredientService
    {
        Task AddRecipeIngredientAsync(RecipeIngredient recipeIngredient);
        Task<object?> GetAllRecipeIngredientsAsync();
        Task<object?> GetRecipeIngredientByIDAsync(int recipeId);
    }
}