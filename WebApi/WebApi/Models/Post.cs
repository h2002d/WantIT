using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAO;

namespace WebApi.Models
{
    public class Post
    {
        public int? Id { get; set; }
        public string PostText { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public int CategoryId { get; set; }

        public int Save()
        {
            return PostDAO.savePost(this);
        }
        public static List<Post> GetPostsByUserId(int userId)
        {
            return PostDAO.getPostByUserId(userId);
        }
    }
}
