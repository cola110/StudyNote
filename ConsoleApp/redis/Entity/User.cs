using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.redis.Entity
{
    public class User
    {
        public User()
        {
            this.BlogIds = new List<long>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public List<long> BlogIds { get; set; }
    }


    public class BlogPostComment
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
