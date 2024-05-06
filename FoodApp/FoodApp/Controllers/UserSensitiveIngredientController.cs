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
    public class UserSensitiveIngredientController : ControllerBase
    {
        private readonly IUserSensitiveIngredientService _userSensitiveIngredientService;
        private readonly IMapper _mapper;

        public UserSensitiveIngredientController(IUserSensitiveIngredientService userSensitiveIngredientService, IMapper mapper)
        {
            _userSensitiveIngredientService = userSensitiveIngredientService;
            _mapper = mapper;
        }

        /// <summary>
        /// تعیین مواد اولیه به عنوان حساسیت زا برای کاربر
        /// </summary>
        /// <param name="userSensitiveIngredient"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUserSensitiveIngredient(UserSensitiveIngredientDTO userSensitiveIngredientDto)
        {
            var userSensitiveIngredient = _mapper.Map<UserSensitiveIngredient>(userSensitiveIngredientDto);
            await _userSensitiveIngredientService.AddUserSensitiveIngredientAsync(userSensitiveIngredient);
            _mapper.Map(userSensitiveIngredient, userSensitiveIngredientDto);
            return Ok();
        }

        /// <summary>
        /// نمایش مواد اولیه حساسیت زا برای کاربر
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserSensitiveIngredientByID(int userId)
        {
            var user = await _userSensitiveIngredientService.GetUserSensitiveIngredientByIDAsync(userId);
            return Ok(user);
        }

        /// <summary>
        /// نمایش مواد اولیه حساسیت زا همه کاربران
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUserSensitiveIngredients()
        {
            var users = await _userSensitiveIngredientService.GetAllUserSensitiveIngredientsAsync();
            return Ok(users);
        }
    }
}
