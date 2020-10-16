using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meestoo.Models;
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

        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public void OnLogin(UserDTO getUser)
        {
            _userService.CreateOrUpdateUser(getUser);
        }
    }
}