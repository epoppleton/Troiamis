using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Troiamis.ModelsCombined
{
    public class ImagePost : Post
    {
        string imageString { get; set; }
    }

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
     
    public class PostsGallery 
    {
        public static IEnumerable<Post> pagePosts;

        public void populatePage()
        {
            //Code to pull a number of pages from the database
        }
    }

    public class User
    {
        string userName { get; set; }
        string password { get; set; }
        string userEmail { get; set; }
        int age { get; set; }
        string avatarImageString { get; set; }
    }
}
