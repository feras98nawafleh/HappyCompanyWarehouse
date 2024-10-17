using HappyCompanyWarehouse.Domain;
using HappyCompanyWarehouse.Domain.Interfaces;
using HappyCompanyWarehouse.Domain.Models;

namespace HappyCompanyWarehouse.DAL.Repositories
{
    public class WarehouseItemsRepository : GenericRepository<WarehouseItem>, IWareHouseItemsRepository
    {
        public WarehouseItemsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
