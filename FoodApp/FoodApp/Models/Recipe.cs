using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace FoodApp.Models
{
    public class Recipe
    {
        
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SwaggerSchema(ReadOnly = true)]
        public virtual ICollection<RecipeIngredient>? RecipeIngredients { get; set; }

        //[JsonIgnore]
        //[XmlIgnore]
        //[SwaggerSchema(ReadOnly = true)]
        //public bool? IsSensitive { get; set; } = false;

    }
}
