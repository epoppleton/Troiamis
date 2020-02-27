using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DbSet<User> Users { get; set; }
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
        [Key]
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

    public class User
    {
        [Key]
        public string userName { get; set; }
        public string password { get; set; }
        public string userEmail { get; set; }
        public int age { get; set; }
        public string avatarImageString { get; set; }
    }
}
