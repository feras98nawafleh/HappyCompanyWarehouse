using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCompanyWarehouse.Domain.Models
{
    public static class Constants
    {
        public const string ADMIN = "Admin";
        public const string MANAGEMENT = "Management";
        public const string Auditor = "Auditor";
        public const string USERNAME_DEFAULT = "admin@happywarehouse";
        public const string EMAIL_DEFAULT = "admin@happywarehouse.com";
        public const string PASSWORD_DEFAULT = "P@ssw0rd";
        public static readonly Role ROLE_ADMIN = Role.CreateAdmin();
        public static readonly Role ROLE_MANAGEMENT = Role.CreateManagement();
        public static readonly Role ROLE_AUDITOR = Role.CreateAuditor();
        public const string TOKEN_KEY = "FERAS_ADEL_@!_KEY_!@_FERAS_ADEL";
        public const int TOKEN_EXPIRATION_IN_MINUTES = 15;
    }
}
