using HappyCompanyWarehouse.Domain;
using HappyCompanyWarehouse.Domain.Interfaces;
using HappyCompanyWarehouse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCompanyWarehouse.DAL.Repositories
{
    public class WarehousesRepository : GenericRepository<Warehouse>, IWareHousesRepository
    {
        private readonly ApplicationDbContext _context;

        public WarehousesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
