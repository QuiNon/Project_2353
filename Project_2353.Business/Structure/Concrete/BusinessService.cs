using Project_2353.Business.Abstract;
using Project_2353.Business.Concrete;
using Project_2353.Business.Structure.Abstract;
using Project_2353.Entity.Abstract;

namespace Project_2353.Business.Structure.Concrete
{
    public class BusinessService:IBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IUserService _user;
        public IUserService User => _user ??= new UserService(_unitOfWork);
    }
}