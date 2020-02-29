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
        [Required(AllowEmptyStrings = false, ErrorMessage = "filename cannot be empty")]
        public string fileName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "postName cannot be empty")]
        public string posterName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "post must have a title")]
        public string postTitle { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "post must have conntent")]
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
        [StringLength(64, ErrorMessage = "user name must be within the valid character count (6 - 64)", MinimumLength = 6)]
        public string userName { get; set; }
        [Required (AllowEmptyStrings = false, ErrorMessage = "Password cannot be empty")]
        public string password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email cannot be empty")]
        public string userEmail { get; set; }
        [Range(13, int.MaxValue, ErrorMessage = "You must be at least 13 years old")]
        public int age { get; set; }
        public string avatarImageString { get; set; }
    }
}
