using AutoMapper;
using FoodApp.DTOs;
using FoodApp.Models;
using FoodApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        /// <summary>
        /// درج دستور پخت
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddRecipe(RecipeDTO recipeDto)
        {
            var recipe = _mapper.Map<Recipe>(recipeDto);
            await _recipeService.AddRecipeAsync(recipe);
            _mapper.Map(recipe, recipeDto);

            return Ok(recipeDto);
        }

        /// <summary>
        /// نمایش دستورهای پخت با تعیین حساسیت زا بودن یا نبودن برای کاربر
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllRecipesForUser(int userId)
        {
            var recipes = await _recipeService.GetAllRecipesForUserAsync(userId);
            return Ok(recipes);
        }
    }
}
