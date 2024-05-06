using FoodApp.Data;
using FoodApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Repositories
{
    public class UserSensitiveIngredientRepository : IUserSensitiveIngredientRepository
    {
        private readonly FoodDBContext _context;

        public UserSensitiveIngredientRepository(FoodDBContext context)
        {
            _context = context;
        }

        public async Task AddUserSensitiveIngredientAsync(UserSensitiveIngredient userSensitiveIngredient)
        {
            _context.UserSensitiveIngredients.Add(userSensitiveIngredient);
            await _context.SaveChangesAsync();
        }

        public async Task<object?> GetUserSensitiveIngredientByIDAsync(int userId)
        {
            return await GetUserSensitiveIngredientsAsync(userId);
        }

        public async Task<object?> GetAllUserSensitiveIngredientsAsync()
        {
            return await GetUserSensitiveIngredientsAsync(null);
        }

        protected async Task<object?> GetUserSensitiveIngredientsAsync(int? userId)
        {
            var query = _context.Users.Select(usr => new
            {
                usr.UserId,
                usr.UserName,

                UserSensitiveIngredients = usr.UserSensitiveIngredients.Select(senIng => new
                {
                    senIng.IngredientId,
                    senIng.Ingredient.IngredientName
                })
            });

            #region or
            //var query = from usrSen in _context.UserSensitiveIngredients
            //            join usr in _context.Users on usrSen.UserId equals usr.UserId
            //            join ing in _context.Ingredients on usrSen.IngredientId equals ing.IngredientId
            //            where usrSen.UserId == userId
            //            select new
            //            {
            //                usrSen.UserId,
            //                usr.UserName,
            //                usrSen.IngredientId,
            //                ing.IngredientName
            //            };
            #endregion

            if (userId != null)
            {
                query = query.Where(usr => usr.UserId == userId);
            }

            return await query?.ToListAsync();
        }

    }
}
