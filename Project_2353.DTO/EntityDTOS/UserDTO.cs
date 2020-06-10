using Project_2353.Entity.Entities;

namespace Project_2353.DTO.EntityDTOS
{
    public class UserDTO:_BaseDTO<UserEntity>
    {
        public UserDTO(UserEntity entity) : base(entity)
        {
            this.Email = entity.Email;
            this.Firstname = entity.Firstname;
            this.Id = entity.Id;
            // this.IsDeleted = entity.IsDeleted;
            this.LastName = entity.LastName;
            this.UserName = entity.UserName;
            // this.CreatedDateTime = entity.CreatedDateTime;
        }
    } 
}