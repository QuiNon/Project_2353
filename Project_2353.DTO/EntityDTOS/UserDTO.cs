﻿using Project_2353.Entity.Entities;

namespace Project_2353.DTO.EntityDTOS
{
    public class UserDTO
    { 

        public UserDTO()
        {
            
        }
        public UserDTO(int id)
        {
            this.Id = id;
        }
        public UserDTO(int id,string email,string firstname,string lastName,string userName)
        {
            this.Id = id;
            this.Email = email;
            this.FirstName = firstname;
            this.LastName = lastName;
            this.UserName = userName;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    } 
    
}