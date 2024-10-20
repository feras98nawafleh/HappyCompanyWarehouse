using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace HappyCompanyWarehouse.Domain.Models
{
    public class Country
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
    }
}