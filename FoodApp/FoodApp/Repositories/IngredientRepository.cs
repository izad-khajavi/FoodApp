using FoodApp.Data;
using FoodApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly FoodDBContext _context;

        public IngredientRepository(FoodDBContext context)
        {
            _context = context;
        }


        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }

    }
}
