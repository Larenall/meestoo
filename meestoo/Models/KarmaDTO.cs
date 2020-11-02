using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meestoo.Models
{
    public class KarmaDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }


        public KarmaDTO(int Id,int UserId)
        {
            this.Id = Id;
            this.UserId = UserId;
        }
    }
    
}
