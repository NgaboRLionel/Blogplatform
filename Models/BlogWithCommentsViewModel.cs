using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPl.Models
{
    public class BlogWithCommentsViewModel
    {
        public Blog Blog { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}