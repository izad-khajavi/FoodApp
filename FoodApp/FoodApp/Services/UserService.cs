using FoodApp.Data;
using FoodApp.Models;
using FoodApp.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class UserService : IUserService
    {
        private readonly  IUserRepository _userRepository;
        private readonly IUserSensitiveIngredientService _userSensitiveIngredientService;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserService(IUserRepository userRepository, IUserSensitiveIngredientService userSensitiveIngredientService)
        {
            _userRepository = userRepository;
            _userSensitiveIngredientService = userSensitiveIngredientService;
        }

        public async Task AddUserAsync(User user)
        {
            try
            {
                await _userRepository.AddUserAsync(user);

                if (user.UserSensitiveIngredients != null)
                {
                    foreach (var userSensitiveIngredient in user.UserSensitiveIngredients)
                    {
                        await _userSensitiveIngredientService.AddUserSensitiveIngredientAsync(userSensitiveIngredient);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User?> GetUserByIDAsync(int userId)
        {
            try
            {
                return await _userRepository.GetUserByIDAsync(userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                return await _userRepository.GetAllUsersAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
