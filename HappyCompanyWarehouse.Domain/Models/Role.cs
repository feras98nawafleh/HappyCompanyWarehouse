using System.ComponentModel.DataAnnotations;

namespace HappyCompanyWarehouse.Domain.Models
{
    public class Role
    {
        [Key]public int Id { get; set; }
        public string Name { get; set; }

        public static Role CreateAdmin()
        {
            return new Role
            {
                Id = 1,
                Name = Constants.ADMIN,
            };
        }
        public static Role CreateManagement()
        {
            return new Role
            {
                Id = 2,
                Name = Constants.MANAGEMENT,
            };
        }

        public static Role CreateAuditor()
        {
            return new Role
            {
                Id = 3,
                Name = Constants.Auditor,
            };
        }
    }
}