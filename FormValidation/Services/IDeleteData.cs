using System.Data.SqlClient;
using FormValidation.Models;

namespace FormValidation.Services
{
    public interface IDeleteData
    {
        SqlCommand DeleteUser(int id, UserInfoModel userModel);
    }
}