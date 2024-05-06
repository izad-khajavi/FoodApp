using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodApp.DTOs
{
    public class UserSensitiveIngredientDTO
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int IngredientId { get; set; }
    }
}
