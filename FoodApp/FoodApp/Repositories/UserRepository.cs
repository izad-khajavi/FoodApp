using FoodApp.Data;
using FoodApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodDBContext _context;

        public UserRepository(FoodDBContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByIDAsync(int userId)
        {
            return await _context.Users
                        .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserIncudingSensitiveIngredientsByIDAsync(int userId)
        {
           return await  _context.Users
                        .Include(u => u.UserSensitiveIngredients)
                        .FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}
