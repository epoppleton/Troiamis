using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Troiamis.Models
{
    public class Post
    {
        string fileName { get; set; }
        string posterName { get; set; }
        string postTitle { get; set; }
        string postContent { get; set; }
        DateTime timeStamp { get; set; }
        long postID { get; set; }
        int ratings { get; set; }
    }
}
