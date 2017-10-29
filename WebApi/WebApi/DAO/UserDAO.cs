using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DAO
{
    public class UserDAO : DAO
    {
        public static int registerUser(User User)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_RegisterUser", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Name", User.Name);
                        command.Parameters.AddWithValue("@SurName", User.SurName);
                        command.Parameters.AddWithValue("@Password", User.Password);
                        command.Parameters.AddWithValue("@PhoneNumber", User.PhoneNumber);
                        command.Parameters.AddWithValue("@Email", User.Email);

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

        public static User loginUser(string email, string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_LoginUser", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        SqlDataReader rdr = command.ExecuteReader();
                        if (rdr.Read())
                        {
                            User loggedUser = new User();
                            loggedUser.Id = Convert.ToInt32(rdr["ID"]);
                            loggedUser.Name = rdr["Name"].ToString();
                            loggedUser.SurName = rdr["SurName"].ToString();
                            loggedUser.Password = rdr["Password"].ToString();
                            loggedUser.Email = rdr["Email"].ToString();

                            loggedUser.IsBlocked = Convert.ToBoolean(rdr["IsBlocked"]==DBNull.Value? false:true);
                            loggedUser.IsDeleted = Convert.ToBoolean(rdr["IsDeleted"] == DBNull.Value ? false : true);
                            loggedUser.PhoneNumber = rdr["PhoneNumber"].ToString();
                            return loggedUser;


                        }
                        else
                        {
                            return null;
                        }

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
