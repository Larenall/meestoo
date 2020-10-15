using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meestoo.Models
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string[] UserList { get; set; }

        public FeedbackDTO(int Id,string Name, string ImgUrl, string Description, string Date, string[] UserList)
        {
            this.Id = Id;
            this.Name = Name;
            this.ImgUrl = ImgUrl;
            this.Description = Description;
            this.Date = Date;
            this.UserList = UserList;
        }
    }
    
}
