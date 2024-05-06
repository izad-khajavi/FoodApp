using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace FoodApp.DTOs
{
    public class IngredientDTO
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }

    }
}
