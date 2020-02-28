using System.Collections.Generic;
using CPS.Controllers;
using CPS.Models;

namespace CPS
{
    public class NotificationServices
    {
        public NotificationServices(MastersController controller)
        {
            
        }

        public void SendToMe(string message)
        {}

        public void SendToOthers(User target , string message)
        {}
 
        public void SendToOthers(IEnumerable<User> target , string message)
        {
            if (target is null)
            {
                throw new System.ArgumentNullException(nameof(target));
            }
        }
    }
}