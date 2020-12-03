using System.Data.SqlClient;
using FormValidation.Models;

namespace FormValidation.Services
{
    public interface IEditData
    {
        SqlCommand EditUser(UserInfoModel userModel);
    }
}