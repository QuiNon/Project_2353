namespace Project_2353.DTO.EntityDTOS
{
    public class UserAddDTO
    {
        public UserAddDTO()
        {
            
        }
        public UserAddDTO(string email,string firstname,string lastName,string userName)
        {
            this.Email = email;
            this.FirstName = firstname;
            this.LastName = lastName;
            this.UserName = userName;
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}