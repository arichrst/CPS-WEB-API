using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPS.Models;

namespace CPS.Controllers
{
    [ApiController]
    public class MastersController : ControllerBase
    {
        public CPSContext Db { get; set; }
        public AuthServices Auth { get; set; }
        public FileServices Upload { get; set; }
        public NotificationServices Notification { get; set;}
        public MailServices Mail { get; set; }

        public MastersController()
        {
            Db = new CPSContext();
            Auth = new AuthServices(this);
            Upload = new FileServices(this);
            Notification = new NotificationServices(this);
            Mail = new MailServices(this);
        }
    }
}
