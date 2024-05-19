using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardOS.Models.UserCredentials
{
    public class Credentials
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }

        public bool VerifyCredentialsRef(Credentials UserSection, Credentials UserCredential)
        {
            if (UserSection.Login == UserCredential.Login && UserCredential.Password == UserCredential.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}