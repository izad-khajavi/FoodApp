using FoodApp.Data;
using FoodApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly FoodDBContext _context;

        public RecipeRepository(FoodDBContext context)
        {
            _context = context;
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
        }


        public async Task<object?> GetAllRecipesForUserAsync(User user)
        {
            var sensitiveIngredients = user.UserSensitiveIngredients?.Select(i => i.IngredientId).ToList();

            return await _context.Recipes.Select(rcp => new
            {
                rcp.RecipeId,
                rcp.RecipeName,
                rcp.RecipeDescription,
                RecipeIngredients = rcp.RecipeIngredients.Select(rcpIng => new
                {
                    rcpIng.IngredientId,
                    rcpIng.Ingredient.IngredientName
                }),
                IsSensitive = user.UserSensitiveIngredients.Any() && rcp.RecipeIngredients.Any(i => sensitiveIngredients.Contains(i.IngredientId)),
                UserSensitiveIngredients = rcp.RecipeIngredients.Select(senIng => new
                {
                    senIng.IngredientId,
                    sensitiveIngredientName = senIng.Ingredient.IngredientName
                }).Where(senIng => sensitiveIngredients.Contains(senIng.IngredientId))
            }).ToListAsync();
        }
    }
}
