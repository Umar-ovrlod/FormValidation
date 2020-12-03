using FormValidation.Models;

namespace FormValidation.Services
{
    public interface IReadData
    {
        UserInfoModel ReadUser(int id);
    }
}