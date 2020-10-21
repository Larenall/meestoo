using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using meestoo;

namespace meestoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactsController : ControllerBase
    {
        private readonly postgresContext db;

        public FactsController(postgresContext context)
        {
            db = context;
        }

        [HttpGet("{lat}/{lng}")]
        public Fact getFact(double lat,double lng)
        {
            Fact result = new Fact();
            double shortest = 9999999;
            var factList = db.Fact.ToList();
            factList.ForEach(el => {
            double length = Math.Pow((el.Lat - lat), 2) + Math.Pow((el.Lng - lng), 2);
                if (length < shortest)                          //AB = (xb - xa)2 + (yb - ya)2
                {
                    shortest = length;
                    result = el;
                }
            });
            return result;
        }
    }
}
