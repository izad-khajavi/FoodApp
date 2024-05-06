using FoodApp.Models;

namespace FoodApp.Repositories
{
    public interface IIngredientRepository
    {
        Task AddIngredientAsync(Ingredient ingredient);
        Task<List<Ingredient>> GetAllIngredientsAsync();

    }
}