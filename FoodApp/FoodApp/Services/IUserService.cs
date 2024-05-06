using FoodApp.Models;

namespace FoodApp.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIDAsync(int userId);
    }
}