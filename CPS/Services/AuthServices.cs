using System;
using CPS.Controllers;

namespace CPS
{
    

    public class AuthServices
    {
        public AuthServices(MastersController controller)
        {
            
        }
        public string GenerateToken()
        {
            return Cryptographer.Encrypt(Guid.NewGuid().ToString());
        }
    }
}