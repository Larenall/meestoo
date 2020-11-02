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
    public class InfoesController : ControllerBase
    {
        private readonly postgresContext db;

        public InfoesController(postgresContext context)
        {
            db = context;
        }        
    }
}
