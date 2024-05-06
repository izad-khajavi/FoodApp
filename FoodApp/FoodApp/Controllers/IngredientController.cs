using AutoMapper;
using FoodApp.DTOs;
using FoodApp.Models;
using FoodApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IngredientController :  ControllerBase 
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;

        public IngredientController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        /// <summary>
        /// درج مواد اولیه
        /// </summary>
        /// <param name="ingredientDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddIngredient(IngredientDTO ingredientDto)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientDto);
            await _ingredientService.AddIngredientAsync(ingredient);
            _mapper.Map(ingredient, ingredientDto);
            return Ok(ingredientDto);
        }

        /// <summary>
        /// نمایش مواد اولیه
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllIngredients()
        {
            var ingredients = await _ingredientService.GetAllIngredientsAsync();
            var ingredientDtos = _mapper.Map<List<IngredientDTO>>(ingredients);
            return Ok(ingredientDtos);
        }

    }
}
