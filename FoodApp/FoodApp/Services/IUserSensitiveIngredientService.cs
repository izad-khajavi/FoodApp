using FoodApp.Models;

namespace FoodApp.Services
{
    public interface IUserSensitiveIngredientService
    {
        Task AddUserSensitiveIngredientAsync(UserSensitiveIngredient userSensitiveIngredient);
        Task<object?> GetAllUserSensitiveIngredientsAsync();
        Task<object?> GetUserSensitiveIngredientByIDAsync(int userId);
    }
}