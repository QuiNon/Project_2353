using System;
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
            _unitOfWork.User.Add(new UserEntity()
            {
                Email = user.Email,
                Firstname = user.Firstname,
                LastName = user.LastName,
                UserName = user.UserName
            });
            var saveRes = _unitOfWork.SaveChanges();
            return _unitOfWork.CreateResult().SuccessAddResult();
        }

        public ProcessResult EditUser(UserDTO user)
        {
            _unitOfWork.User.Edit(user);
            return _unitOfWork.CreateResult().SuccessUpdateResult();
        }

        public ProcessResult DeleteUser(UserDTO user)
        {
            _unitOfWork.User.Delete(user);
            return _unitOfWork.CreateResult().SuccessDeleteResult();
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
                    .Where(x=>String.Equals(x.UserName, userName, StringComparison.CurrentCultureIgnoreCase))
                ;
            var returnResult = _unitOfWork.CreateResult().SuccessAddResult();
            returnResult.returnObj = returnModel;
            return returnResult;
        }
    }
}