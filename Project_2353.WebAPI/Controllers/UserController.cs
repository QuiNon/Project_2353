using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_2353.Business.Structure.Abstract;
using Project_2353.Core.Factory.ResultFactory;
using Project_2353.DTO.EntityDTOS;
using Project_2353.Entity.Entities;

namespace Project_2353.WebAPI.Controllers
{
    
    
    public class UserController : BaseApiController
    {
        private readonly IBusinessService business;

        public UserController(IBusinessService business)
        {
            this.business = business;
        }

        [HttpPut]
        public ProcessResult Put([FromBody] UserDTO user)
        {
            var result = business.User.RegisterUser(new UserDTO(new UserEntity()
            {
                Email = user.Email,
                Firstname = user.Firstname,
                LastName = user.LastName,
                UserName = user.UserName
            }));
            return result;
        }
        [HttpPatch]
        public ProcessResult Patch([FromBody] UserDTO user)
        {
            var result = business.User.EditUser(new UserDTO(new UserEntity()
            {
                Email = user.Email,
                Firstname = user.Firstname,
                LastName = user.LastName,
                UserName = user.UserName,
                Id = user.Id
            }));
            return result;
        }
        [HttpDelete]
        public ProcessResult Delete([FromBody] int id)
        {
            var result = business.User.DeleteUser(new UserDTO(new UserEntity()
            {
                Id = id
            }));
            return result;
        }
        
        [HttpGet]  
        [Route("{id:int}")]
        public ProcessResult GetBy(int id)
        {
            var result = business.User.GetUserById(new UserDTO(new UserEntity()
            {
                Id = id
            }));
            return result;
        }
        
        [HttpGet]  
        
        public ProcessResult Get()
        {
            var result = business.User.GetAllUser();
            return result;
        }
        [HttpGet]  
        [Route("GetBy")]
        public ProcessResult Get(string userName)
        {
            var result = business.User.GetAllUser(userName);
            return result;
        }
    }
}