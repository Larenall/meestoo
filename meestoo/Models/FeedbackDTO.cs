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
        public DateTime Date { get; set; }
        public int[] UserList { get; set; }
        public string Email { get; set; }

        public FeedbackDTO(int Id,string Name, string ImgUrl, string Description, DateTime Date, int[] UserList) //send to website
        {
            this.Id = Id;
            this.Name = Name;
            this.ImgUrl = ImgUrl;
            this.Description = Description;
            this.Date = Date;
            this.UserList = UserList;
        }
        public FeedbackDTO(string Email,string Description, DateTime Date, int[] UserList) //get from website
        {
            this.Email = Email;
            this.Description = Description;
            this.Date = Date;
            this.UserList = UserList;
        }
    }
    
}
