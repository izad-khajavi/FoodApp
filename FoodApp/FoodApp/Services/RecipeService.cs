using FoodApp.Data;
using FoodApp.Models;
using FoodApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IUserRepository _userRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public RecipeService(IRecipeRepository recipeRepository, IRecipeIngredientService recipeIngredientService)
        {
            _recipeRepository = recipeRepository;
            _recipeIngredientService = recipeIngredientService;
        }


        public RecipeService(IRecipeRepository recipeRepository, IRecipeIngredientService recipeIngredientService, IUserRepository userRepository)
        {
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            try
            {
                await _recipeRepository.AddRecipeAsync(recipe);

                if (recipe.RecipeIngredients != null)
                {
                    foreach (var recipeIngredient in recipe.RecipeIngredients)
                    {
                        await _recipeIngredientService.AddRecipeIngredientAsync(recipeIngredient);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<object?> GetAllRecipesForUserAsync(int userId)
        {
            try
            {
                var user = await _userRepository.GetUserIncudingSensitiveIngredientsByIDAsync(userId);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                return await _recipeRepository.GetAllRecipesForUserAsync(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
