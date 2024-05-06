using AutoMapper;
using FoodApp.DTOs;
using FoodApp.Models;
using System.Diagnostics.Metrics;
using FoodApp.DTOs;

namespace FoodApp.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ingredient, IngredientDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Recipe, RecipeDTO>().ReverseMap();
            CreateMap<RecipeIngredient, RecipeIngredientDTO>().ReverseMap();
            CreateMap<UserSensitiveIngredient, UserSensitiveIngredientDTO>().ReverseMap();
         
        }
    }
}
