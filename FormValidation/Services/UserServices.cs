using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Connect;
using FormValidation.Models;

namespace FormValidation.Services
{
    public class UserServices : IUserServices
    {
        public DataTable GetData(int id)
        {
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spUserInfo", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@id", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                DataTable dtblUser = new DataTable();
                dtblUser.Load(sqlread);
                sqlConn.Close();
                return dtblUser;
            }
        }

        public DataTable GetData()
        {
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spUserInfo", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "SelectAll"); 
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                DataTable dtblUser = new DataTable();
                dtblUser.Load(sqlread);
                sqlConn.Close();
                return dtblUser;
            }
        }
    }

    public class CreateUser : ICreateUser
    {
        public SqlCommand AddUser(UserInfoModel userModel)
        {
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spUserInfo", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@first", userModel.FirstName);
                sqlCmd.Parameters.AddWithValue("@last", userModel.LastName);
                sqlCmd.Parameters.AddWithValue("@email", userModel.Email);
                sqlCmd.Parameters.AddWithValue("@dob", userModel.DOB);
                sqlCmd.Parameters.AddWithValue("@age", userModel.Age);
                sqlCmd.Parameters.AddWithValue("@gender", userModel.Gender);
                sqlCmd.Parameters.AddWithValue("@cnic", userModel.Cnic);
                sqlCmd.Parameters.AddWithValue("@mobNo", userModel.MobileNo);
                sqlCmd.Parameters.AddWithValue("@homeno", userModel.HomeNo);
                sqlCmd.Parameters.AddWithValue("@address", userModel.Address);
                sqlCmd.Parameters.AddWithValue("@regDate", userModel.RegistrationDate);
                sqlCmd.Parameters.AddWithValue("@image", userModel.UserImage);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Insert");
                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                return sqlCmd;
            }
        }
    }




    public class ReadData : IReadData
    {
        public UserInfoModel ReadUser(int id)
        {
            UserInfoModel user = new UserInfoModel();
            DataTable dtblUser = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spUserInfo", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "Select");
                cmd.Parameters.AddWithValue("@id", id);
                sqlConn.Open();
                SqlDataReader sqlread = cmd.ExecuteReader();
                dtblUser.Load(sqlread);
                sqlConn.Close();
            }
            if (dtblUser.Rows.Count == 1)
            {
                user.UserId = Convert.ToInt32(dtblUser.Rows[0][0].ToString());
                user.FirstName = dtblUser.Rows[0][1].ToString();
                user.LastName = dtblUser.Rows[0][2].ToString();
                user.Email = dtblUser.Rows[0][3].ToString();
                user.DOB = Convert.ToDateTime(dtblUser.Rows[0][4]);
                user.Age = Convert.ToInt32(dtblUser.Rows[0][5].ToString());
                user.Gender = Convert.ToChar(dtblUser.Rows[0][6].ToString());
                user.Cnic = Convert.ToInt64(dtblUser.Rows[0][7].ToString());
                user.MobileNo = Convert.ToInt64(dtblUser.Rows[0][8].ToString());
                user.HomeNo = Convert.ToInt64(dtblUser.Rows[0][9].ToString());
                user.Address = dtblUser.Rows[0][10].ToString();
                user.RegistrationDate = Convert.ToDateTime(dtblUser.Rows[0][11]);
                user.UserImage = dtblUser.Rows[0][12].ToString();
            }
            return user;
        }
    }


    public class EditData : IEditData
    {
        public SqlCommand EditUser(UserInfoModel userModel)
        {
            using (SqlConnection sqlConn = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spUserInfo", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@id", userModel.UserId);
                sqlCmd.Parameters.AddWithValue("@first", userModel.FirstName);
                sqlCmd.Parameters.AddWithValue("@last", userModel.LastName);
                sqlCmd.Parameters.AddWithValue("@email", userModel.Email);
                sqlCmd.Parameters.AddWithValue("@dob", userModel.DOB);
                sqlCmd.Parameters.AddWithValue("@age", userModel.Age);
                sqlCmd.Parameters.AddWithValue("@gender", userModel.Gender);
                sqlCmd.Parameters.AddWithValue("@cnic", userModel.Cnic);
                sqlCmd.Parameters.AddWithValue("@mobNo", userModel.MobileNo);
                sqlCmd.Parameters.AddWithValue("@homeno", userModel.HomeNo);
                sqlCmd.Parameters.AddWithValue("@address", userModel.Address);
                sqlCmd.Parameters.AddWithValue("@regDate", userModel.RegistrationDate);
                sqlCmd.Parameters.AddWithValue("@image", userModel.UserImage);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Update");
                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
                return sqlCmd;
            }
        }
    }


    public class DeleteData : IDeleteData
    {
        public SqlCommand DeleteUser(int id, UserInfoModel userModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spBanner", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@prodID", id);
                sqlCmd.Parameters.AddWithValue("@StatementType", "Delete");
                sqlCon.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                return sqlCmd;
            }
        }
    }
}