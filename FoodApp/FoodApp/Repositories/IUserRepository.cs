using FoodApp.Models;

namespace FoodApp.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetUserByIDAsync(int userId);
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserIncudingSensitiveIngredientsByIDAsync(int userId);
        
    }
}