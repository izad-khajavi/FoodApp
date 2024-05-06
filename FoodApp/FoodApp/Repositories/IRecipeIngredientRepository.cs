using FoodApp.Models;

namespace FoodApp.Repositories
{
    public interface IRecipeIngredientRepository
    {
        Task AddRecipeIngredientAsync(RecipeIngredient recipeIngredient);
        Task<object?> GetRecipeIngredientByIDAsync(int recipeId);
        Task<object?> GetAllRecipeIngredientsAsync();

    }
}