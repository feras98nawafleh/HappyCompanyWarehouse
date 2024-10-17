using HappyCompanyWarehouse.Domain;
using HappyCompanyWarehouse.Domain.Interfaces;
using HappyCompanyWarehouse.Domain.Models;

namespace HappyCompanyWarehouse.DAL.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
