using Project_2353.Core.Factory.ResultFactory;
using Project_2353.DTO.EntityDTOS;

namespace Project_2353.Business.Abstract
{
    public interface IUserService
    {
        ProcessResult RegisterUser(UserAddDTO user);
        ProcessResult EditUser(UserDTO user);
        ProcessResult DeleteUser(int id);
        ProcessResult GetUserById(UserDTO user);
        ProcessResult GetAllUser();
        ProcessResult GetAllUser(string userName);
    }
}