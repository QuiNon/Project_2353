using Project_2353.Business.Abstract;

namespace Project_2353.Business.Structure.Abstract
{
    public interface IBusinessService
    {
        IUserService User { get; }
    }
}