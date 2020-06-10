using System.ComponentModel.DataAnnotations;

namespace Project_2353.Entity.Entities
{
    public class UserEntity : _BaseEntity
    { 
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name Should be minimum 3 characters and a maximum of 100 characters")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [RegularExpression(
            "^(([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5}){1,25})+)*$",
            ErrorMessage = "Please write valid email address")]
        [Required(ErrorMessage = "*")]
        [StringLength(256)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
    }
}