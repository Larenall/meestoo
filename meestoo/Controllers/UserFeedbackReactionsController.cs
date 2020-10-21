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
    public class UserFeedbackReactionsController : ControllerBase
    {
        private readonly postgresContext db;

        public UserFeedbackReactionsController(postgresContext context)
        {
            db = context;
        }
        [HttpGet]
        public List<UserFeedbackReaction> get()
        {
            return db.UserFeedbackReaction.ToList();
        }
        
    }
}
