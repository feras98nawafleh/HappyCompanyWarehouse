using HappyCompanyWarehouse.Domain.Models;

namespace HappyCompanyWarehouse.Domain.Interfaces
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<User> GetUserWithRole(int userId);
    }
}
