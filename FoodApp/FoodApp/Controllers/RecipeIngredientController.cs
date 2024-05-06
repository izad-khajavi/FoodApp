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
    public class RecipeIngredientController : Controller
    {
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IMapper _mapper;

        public RecipeIngredientController(IRecipeIngredientService recipeIngredientService, IMapper mapper)
        {
            _recipeIngredientService = recipeIngredientService;
            _mapper = mapper;
        }

        /// <summary>
        /// درج ارتباط بین مواد اولیه و دستور پخت(تعیین مواد اولیه دستور پخت)
        /// </summary>
        /// <param name="recipeIngredient"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddRecipeIngredient(RecipeIngredientDTO recipeIngredientDto)
        {
            var recipeIngredient = _mapper.Map<RecipeIngredient>(recipeIngredientDto);
            await _recipeIngredientService.AddRecipeIngredientAsync(recipeIngredient);
            _mapper.Map(recipeIngredient, recipeIngredientDto);
            return Ok(recipeIngredientDto);
        }

        /// <summary>
        /// نمایش اطلاعات دستور پخت
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpGet("{recipeId}")]
        public async Task<IActionResult> GetRecipeIngredientByID(int recipeId)
        {
            var recipeIngredients = await _recipeIngredientService.GetRecipeIngredientByIDAsync(recipeId);
            return Ok(recipeIngredients);
        }

        /// <summary>
        /// نمایش همه دستورهای پخت
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllRecipeIngredients()
        {
            var recipeIngredients = await _recipeIngredientService.GetAllRecipeIngredientsAsync();
            return Ok(recipeIngredients);
        }
    }
}
