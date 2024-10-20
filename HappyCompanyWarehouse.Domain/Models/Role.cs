using System.ComponentModel.DataAnnotations;

namespace HappyCompanyWarehouse.Domain.Models
{
    public class Role
    {
        [Key]public int Id { get; set; }
        public string Name { get; set; }

        public static object CreateAdmin()
        {
            return new Role
            {
                Id = Constants.ROLE_ADMIN,
                Name = Constants.ADMIN,
            };
        }
        public static object CreateManagement()
        {
            return new Role
            {
                Id = Constants.ROLE_MANAGEMENT,
                Name = Constants.MANAGEMENT,
            };
        }

        public static object CreateAuditor()
        {
            return new Role
            {
                Id = 3,
                Name = Constants.Auditor,
            };
        }
    }
}