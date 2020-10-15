using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meestoo.Models
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImgUrl { get; set; }

        public UserDTO(string Name, string Email, string ImgUrl)
        {
            this.Name = Name;
            this.Email = Email;
            this.ImgUrl = ImgUrl;
        }
    }
    
}
