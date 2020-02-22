using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Troiamis.ModelsCombined
{
    public class TroiamisDBContext : DbContext
    {
        public TroiamisDBContext(DbContextOptions<TroiamisDBContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        //public DbSet<ImagePost> ImagePosts { get; set; }
        //public DbSet<PostsGallery> PostsGalleries { get; set; }
        //public DbSet<User> Users { get; set; }
    }


    //public class ImagePost : Post
    //{
    //    string imageString { get; set; }
    //}

    public class Post
    {
        public string fileName { get; set; }
        public string posterName { get; set; }
        public string postTitle { get; set; }
        public string postContent { get; set; }
        public DateTime timeStamp { get; set; }
        public long postID { get; set; }
        public int ratings { get; set; }
    }
     
    //public class PostsGallery 
    //{
    //    public static IEnumerable<Post> pagePosts;

    //    public void populatePage()
    //    {
    //        //Code to pull a number of pages from the database
    //    }
    //}

    //public class User
    //{
    //    string userName { get; set; }
    //    string password { get; set; }
    //    string userEmail { get; set; }
    //    int age { get; set; }
    //    string avatarImageString { get; set; }
    //}
}
