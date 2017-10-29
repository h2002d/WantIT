using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DAO
{
    public class PostDAO: DAO
    {
        public static int savePost(Post post)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_SavePost", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        if(post.Id==null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", post.Id);

                        command.Parameters.AddWithValue("@PostText", post.PostText);
                        command.Parameters.AddWithValue("@Status", post.Status);
                        command.Parameters.AddWithValue("@UserId ", post.UserId);
                        command.Parameters.AddWithValue("@CategoryId", post.CategoryId);

                        command.ExecuteNonQuery();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        return 1;
                    }

                }
            }
        }
        public static List<Post> getPostByUserId(int userId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetPostByUserId", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        SqlDataReader rdr = command.ExecuteReader();
                        List<Post> postList = new List<Post>();
                        while(rdr.Read())
                        {
                            Post post = new Post();
                            post.Id = Convert.ToInt32(rdr["Id"]);
                            post.PostText = rdr["PostText"].ToString();
                            post.Status= Convert.ToInt32(rdr["Status"]);
                            post.CategoryId= Convert.ToInt32(rdr["CategoryId"]);
                            post.CreateDate = Convert.ToDateTime(rdr["CreateDate"]);
                            post.UserId= Convert.ToInt32(rdr["UserId"]);
                            postList.Add(post);
                        }
                        return postList;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
        }
    }
}
