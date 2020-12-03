using System.Data;

namespace FormValidation.Services
{
    public interface IUserServices
    {
        DataTable GetData(int id);
        DataTable GetData();
    }
}