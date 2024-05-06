using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace FoodApp.DTOs
{
    public class UserDTO
    {

        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
