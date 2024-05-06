using FoodApp.Data;
using FoodApp.Models;
using FoodApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Services
{

    public class UserSensitiveIngredientService : IUserSensitiveIngredientService
    {
        private readonly IUserSensitiveIngredientRepository _userSensitiveIngredientRepository;

        public UserSensitiveIngredientService(IUserSensitiveIngredientRepository userSensitiveIngredientRepository)
        {
            _userSensitiveIngredientRepository = userSensitiveIngredientRepository;
        }

        public async Task AddUserSensitiveIngredientAsync(UserSensitiveIngredient userSensitiveIngredient)
        {
            try
            {
                await _userSensitiveIngredientRepository.AddUserSensitiveIngredientAsync(userSensitiveIngredient);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<object?> GetUserSensitiveIngredientByIDAsync(int userId)
        {
            try
            {
                return await _userSensitiveIngredientRepository.GetUserSensitiveIngredientByIDAsync(userId);  
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<object?> GetAllUserSensitiveIngredientsAsync()
        {
            try
            {
                return await _userSensitiveIngredientRepository.GetAllUserSensitiveIngredientsAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
