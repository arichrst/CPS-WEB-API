using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPS.Models;
using System.IO;

namespace CPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : MastersController
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var serverurl =  Directory.GetCurrentDirectory();
            CPSContext a = new CPSContext();
            return a.User.Select(x=>x.Name).ToList();
        }
    }
}
