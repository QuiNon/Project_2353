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
        public ProcessResult Put([FromBody] UserAddDTO user)
        {
            var result = business.User.RegisterUser(user);
            return result;
        }

        [HttpPatch]
        public ProcessResult Patch([FromBody] UserDTO user)
        {
            var result = business.User.EditUser(user);
            return result;
        }

        [HttpDelete]
        public ProcessResult Delete(int id)
        {
            var result = business.User.DeleteUser(id);
            return result;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ProcessResult GetBy(int id)
        {
            var result = business.User.GetUserById(new UserDTO(id));
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