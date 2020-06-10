using Project_2353.Business.Abstract;
using Project_2353.Entity.Abstract;

namespace Project_2353.Business.Concrete
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}