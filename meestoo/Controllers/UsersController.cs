using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meestoo.Infrastructure.Helper;
using meestoo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace meestoo
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public readonly postgresContext db;

        private readonly IJwtAuthenticationManager JwtAuthentiocationManager;
        public UsersController(UserService userService, IJwtAuthenticationManager JwtAuthentiocationManager, postgresContext context)
        {
            _userService = userService;
            this.JwtAuthentiocationManager = JwtAuthentiocationManager;
            db = context;
        }
        [HttpPost]
        public int OnLogin(UserDTO getUser)
        {
            return _userService.CreateOrUpdateUser(getUser);

        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred usercred)
        {
            var token = JwtAuthentiocationManager.Authenticate(usercred.Id,usercred.Email, db.Users.ToList());
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}