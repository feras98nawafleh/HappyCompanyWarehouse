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
        public static readonly int ROLE_ADMIN = 1;
        public static readonly int ROLE_MANAGEMENT = 2;
        public static readonly int ROLE_AUDITOR = 3;
        public const string TOKEN_KEY = "FERAS_ADEL_@!_KEY_!@_FERAS_ADEL";
        public const int TOKEN_EXPIRATION_IN_MINUTES = 15;
    }
}
