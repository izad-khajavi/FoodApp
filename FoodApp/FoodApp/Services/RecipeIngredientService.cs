using FoodApp.Data;
using FoodApp.Models;
using FoodApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace FoodApp.Services
{

    public class RecipeIngredientService :  IRecipeIngredientService
    {
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;

        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
        }

        public async Task AddRecipeIngredientAsync(RecipeIngredient recipeIngredient)
        {
            try
            {
                await _recipeIngredientRepository.AddRecipeIngredientAsync(recipeIngredient);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<object?> GetRecipeIngredientByIDAsync(int recipeId)
        {
            try
            {
                return await _recipeIngredientRepository.GetRecipeIngredientByIDAsync(recipeId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<object?> GetAllRecipeIngredientsAsync()
        {

            return await _recipeIngredientRepository.GetAllRecipeIngredientsAsync();
        }
    }
}
