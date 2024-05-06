using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace FoodApp.Models
{
    public class User
    {

        public int UserId { get; set; }
        public string UserName { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [SwaggerSchema(ReadOnly = true)]
        public virtual ICollection<UserSensitiveIngredient>? UserSensitiveIngredients { get; set; }
    }
}
