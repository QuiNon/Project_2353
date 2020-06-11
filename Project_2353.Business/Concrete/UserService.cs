﻿using System;
using System.Linq;
using Project_2353.Business.Abstract;
using Project_2353.Core.Factory.ResultFactory;
using Project_2353.DTO.EntityDTOS;
using Project_2353.Entity.Abstract;
using Project_2353.Entity.Entities;
using Project_2353.Entity.Structure.Abstract;

namespace Project_2353.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ProcessResult RegisterUser(UserDTO user)
        {
            var dalResult= _unitOfWork.User.Add(new UserEntity()
            {
                Email = user.Email,
                Firstname = user.Firstname,
                LastName = user.LastName,
                UserName = user.UserName
            });
            if (!dalResult.State)
                return dalResult;
            var saveRes = _unitOfWork.SaveChanges();
            return saveRes > 0 ? (ProcessResult) _unitOfWork.CreateResult().SuccessAddResult() : _unitOfWork.CreateResult().FailAddResult();
        }

        public ProcessResult EditUser(UserDTO user)
        {
            var dalResult= _unitOfWork.User.Edit(user);
            if (!dalResult.State)
                return dalResult;
            var saveRes = _unitOfWork.SaveChanges();
            return saveRes > 0 ? (ProcessResult) _unitOfWork.CreateResult().SuccessAddResult() : _unitOfWork.CreateResult().FailAddResult();
        }

        public ProcessResult DeleteUser(int id)
        {
            var dalResult=  _unitOfWork.User.Delete(new UserEntity()
            {
                Id = id
            });
            if (!dalResult.State)
                return dalResult;
            var saveRes = _unitOfWork.SaveChanges();
            return saveRes > 0 ? (ProcessResult) _unitOfWork.CreateResult().SuccessAddResult() : _unitOfWork.CreateResult().FailAddResult();
        }

        public ProcessResult GetUserById(UserDTO user)
        {
            var returnModel = _unitOfWork.User.GetBy(x => x.Id == user.Id).FirstOrDefault();
            var returnResult = _unitOfWork.CreateResult().SuccessAddResult();
            returnResult.returnObj = returnModel;
            return returnResult;
        }

        public ProcessResult GetAllUser()
        {
            var returnModel = _unitOfWork.User.GetAll();
            var returnResult = _unitOfWork.CreateResult().SuccessAddResult();
            returnResult.returnObj = returnModel;
            return returnResult;
        }

        public ProcessResult GetAllUser(string userName)
        {
            
            var returnModel = _unitOfWork.User.GetAll()
                    .Where(x=>string.Equals(x.UserName, userName))
                ;
            var returnResult = _unitOfWork.CreateResult().SuccessAddResult();
            returnResult.returnObj = returnModel;
            return returnResult;
        }
    }
}