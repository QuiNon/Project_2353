using Project_2353.Entity.Entities;

namespace Project_2353.DTO.EntityDTOS
{
    public class _BaseDTO<T>:UserEntity 
    {
        public _BaseDTO(T entity)
        {
            
        }
    }
}