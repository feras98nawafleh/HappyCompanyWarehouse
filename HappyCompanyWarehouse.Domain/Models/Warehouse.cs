using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCompanyWarehouse.Domain.Models
{
    public class Warehouse
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public Collection<WarehouseItem> WarehouseItems { get; set; }
    }
}
