using System.ComponentModel.DataAnnotations;

namespace Project_2353.Entity.Entities
{
    public class UserEntity : _BaseEntity
    {
        public UserEntity(string email,string firstname,string lastName,string userName)
        {
            this.Email = email;
            this.Firstname = firstname;
            this.LastName = lastName;
            this.UserName = userName;
        }
        public UserEntity(int id,string email,string firstname,string lastName,string userName)
        {
            this.Id = id;
            this.Email = email;
            this.Firstname = firstname;
            this.LastName = lastName;
            this.UserName = userName;
        }

        public UserEntity()
        {
            
        }
        
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "UserName Should be minimum 3 characters and a maximum of 100 characters")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(100, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string UserNameNormalized { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "*")]
        [StringLength(256)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
    }
}