using FoodApp.Data;
using FoodApp.Extensions;
using FoodApp.Models;
using FoodApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Services
{

    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IUserSensitiveIngredientService _userSensitiveIngredientService;
        private readonly IRecipeIngredientService _recipeIngredientService;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public IngredientService(IIngredientRepository ingredientRepository,
                            IUserSensitiveIngredientService userSensitiveIngredientService,
                            IRecipeIngredientService recipeIngredientService)
        {
            _ingredientRepository = ingredientRepository;
            _userSensitiveIngredientService = userSensitiveIngredientService;
            _recipeIngredientService = recipeIngredientService;
        }

        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            try
            {
                await _ingredientRepository.AddIngredientAsync(ingredient);

                if (ingredient.UserSensitiveIngredients != null)
                {
                    foreach (var userSensitiveIngredient in ingredient.UserSensitiveIngredients)
                    {
                        await _userSensitiveIngredientService.AddUserSensitiveIngredientAsync(userSensitiveIngredient);
                    }
                }

                if (ingredient.RecipeIngredients != null)
                {
                    foreach (var recipeIngredient in ingredient.RecipeIngredients)
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

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            try
            {
               return await _ingredientRepository.GetAllIngredientsAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }

}
