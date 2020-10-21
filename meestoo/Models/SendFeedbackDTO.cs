using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meestoo.Models
{
    public class SendFeedbackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Karma { get; set; }
        public bool LikedBy { get; set; }
        public bool OfUser { get; set; }

        public SendFeedbackDTO(int Id,string Name, string ImgUrl, string Description, DateTime Date, int Karma,bool LikedBy, bool OfUser) //send to website
        {
            this.Id = Id;
            this.Name = Name;
            this.ImgUrl = ImgUrl;
            this.Description = Description;
            this.Date = Date;
            this.Karma = Karma;
            this.LikedBy = LikedBy;
            this.OfUser = OfUser;
        }
       
    }
    
}
