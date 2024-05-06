using FoodApp.Data;
using FoodApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Repositories
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly FoodDBContext _context;

        public RecipeIngredientRepository(FoodDBContext context)
        {
            _context = context;
        }

        public async Task AddRecipeIngredientAsync(RecipeIngredient recipeIngredient)
        {
            _context.RecipeIngredients.Add(recipeIngredient);
            await _context.SaveChangesAsync();
        }

        public async Task<object?> GetRecipeIngredientByIDAsync(int recipeId)
        {
            return await GetRecipeIngredientsAsync(recipeId);
        }

        public async Task<object?> GetAllRecipeIngredientsAsync()
        {
            return await GetRecipeIngredientsAsync(null);
        }

        protected async Task<object?> GetRecipeIngredientsAsync(int? recipeId)
        {
            var query = _context.Recipes.Select(rcp => new
            {
                rcp.RecipeId,
                rcp.RecipeName,
                rcp.RecipeDescription,

                RecipeIngredients = rcp.RecipeIngredients.Select(rcpIng => new
                {
                    rcpIng.IngredientId,
                    rcpIng.Ingredient.IngredientName
                })
            });

            #region or
            //var query = from rcpIng in _context.RecipeIngredients
            //            join rcp in _context.Recipes on rcpIng.RecipeId equals rcp.RecipeId
            //            join ing in _context.Ingredients on rcpIng.IngredientId equals ing.IngredientId
            //            select new
            //            {
            //                rcpIng.RecipeId,
            //                rcp.RecipeName,
            //                rcp.RecipeDescription,
            //                ing.IngredientId,
            //                ing.IngredientName
            //            };
            //return await query?.ToListAsync();
            #endregion
            
            if (recipeId != null)
            {
                query = query.Where(rcp => rcp.RecipeId == recipeId);
            }

            return await query?.ToListAsync();
        }
    }
}
