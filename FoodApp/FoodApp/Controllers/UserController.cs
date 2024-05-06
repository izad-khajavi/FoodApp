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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// درج کاربر
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.AddUserAsync(user);
            _mapper.Map(user, userDto);
            return Ok(userDto);
        }

        /// <summary>
        /// نمایش اطلاعات کاربر
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByID(int userId)
        {
            var user = await _userService.GetUserByIDAsync(userId);
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }

        /// <summary>
        /// نمایش همه کاربران
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            var userDtos = _mapper.Map<List<UserDTO>>(users);
            return Ok(userDtos);
        }
    }
}
