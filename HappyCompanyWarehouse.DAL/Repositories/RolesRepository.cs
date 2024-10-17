using HappyCompanyWarehouse.Domain;
using HappyCompanyWarehouse.Domain.Interfaces;
using HappyCompanyWarehouse.Domain.Models;

namespace HappyCompanyWarehouse.DAL.Repositories
{
    public class RolesRepository : GenericRepository<Role>, IRolesRepository
    {
        public RolesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
