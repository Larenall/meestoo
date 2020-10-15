using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meestoo.Models
{
    public class KarmaDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }


        public KarmaDTO(int Id,string Email)
        {
            this.Id = Id;
            this.Email = Email;
        }
    }
    
}
