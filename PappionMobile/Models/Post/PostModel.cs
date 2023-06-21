using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappionMobile.Models.Post
{
    public class PostModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Location { get; set; }
        public string AuthorId { get; set; }


      
    }

}
