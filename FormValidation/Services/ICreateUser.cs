using System.Data.SqlClient;
using FormValidation.Models;

namespace FormValidation.Services
{
    public interface ICreateUser
    {
        SqlCommand AddUser(UserInfoModel userModel);
    }
}