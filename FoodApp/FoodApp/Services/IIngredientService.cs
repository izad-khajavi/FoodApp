using FoodApp.Models;

namespace FoodApp.Services
{
    public interface IIngredientService
    {
        Task AddIngredientAsync(Ingredient ingredient);
        Task<List<Ingredient>> GetAllIngredientsAsync();
    }
}