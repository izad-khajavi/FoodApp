using FoodApp.Models;

namespace FoodApp.Repositories
{
    public interface IUserSensitiveIngredientRepository
    {
        Task AddUserSensitiveIngredientAsync(UserSensitiveIngredient userSensitiveIngredient);
        Task<object?> GetUserSensitiveIngredientByIDAsync(int userId);
        Task<object?> GetAllUserSensitiveIngredientsAsync();

    }
}