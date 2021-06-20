using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace JazariDotCom.DAL
{
    public class myDAL
    {
        private static readonly string connString =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;

        public string SignUp(string email, string password, string name)
        {
            SqlConnection SignUp_con = new SqlConnection(connString);
            SqlCommand SignUp_command = new SqlCommand("RegisterUser", SignUp_con);
            SignUp_command.CommandType = CommandType.StoredProcedure;

            SignUp_command.Parameters.Add("@email", SqlDbType.NVarChar, 50);
            SignUp_command.Parameters["@email"].Value = email;
            SignUp_command.Parameters.Add("@password", SqlDbType.NVarChar, 50);
            SignUp_command.Parameters["@password"].Value = password;
            SignUp_command.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
            SignUp_command.Parameters["@Name"].Value = name;

            SignUp_command.Parameters.Add("@Result", SqlDbType.NVarChar, 50);
            SignUp_command.Parameters["@Result"].Direction = ParameterDirection.Output;

            SignUp_con.Open();
            string o_Result;
            SignUp_command.ExecuteNonQuery();
            o_Result = (string)SignUp_command.Parameters["@Result"].Value;
            SignUp_con.Close();
            return o_Result;
        }

        public string LogIn(string email, string password)
        {
            SqlConnection LogIn_con = new SqlConnection(connString);
            SqlCommand LogIn_command = new SqlCommand("LoginUser", LogIn_con);
            LogIn_command.CommandType = CommandType.StoredProcedure;

            LogIn_command.Parameters.Add("@email", SqlDbType.NVarChar, 50);
            LogIn_command.Parameters["@email"].Value = email;
            LogIn_command.Parameters.Add("@password", SqlDbType.NVarChar, 50);
            LogIn_command.Parameters["@password"].Value = password;

            LogIn_command.Parameters.Add("@Result", SqlDbType.NVarChar, 50);
            LogIn_command.Parameters["@Result"].Direction = ParameterDirection.Output;

            LogIn_con.Open();
            string o_Result;
            LogIn_command.ExecuteNonQuery();
            o_Result = (string)LogIn_command.Parameters["@Result"].Value;
            LogIn_con.Close();

            return o_Result;
        }

        public int complete_profile(string email, string website, string linkedin, string image, string city,string about)
        {
            int result = -1;

            SqlConnection cp_con = new SqlConnection(connString);
            SqlCommand cp_command = new SqlCommand("completeprofile",cp_con);


            cp_command.Parameters.Add("@email", SqlDbType.NVarChar, 50);
            cp_command.Parameters["@email"].Value = email;

            cp_command.Parameters.Add("@website", SqlDbType.NVarChar, 50);
            cp_command.Parameters["@website"].Value = website;

            cp_command.Parameters.Add("@linkedin", SqlDbType.NVarChar, 50);
            cp_command.Parameters["@linkedin"].Value = linkedin;

            cp_command.Parameters.Add("@image", SqlDbType.NVarChar, 50);
            cp_command.Parameters["@image"].Value = image;

            cp_command.Parameters.Add("@city", SqlDbType.NVarChar, 50);
            cp_command.Parameters["@city"].Value = city;

            cp_command.Parameters.Add("@about", SqlDbType.NVarChar, 256);
            cp_command.Parameters["@about"].Value = about;

            cp_command.Parameters.Add("@flag", SqlDbType.Int);
            cp_command.Parameters["@falg"].Direction = ParameterDirection.Output;

            cp_con.Open();
            cp_command.ExecuteNonQuery();
            result = (int)cp_command.Parameters["@flag"].Value;
            cp_con.Close();

            return result;
        }
    }
}