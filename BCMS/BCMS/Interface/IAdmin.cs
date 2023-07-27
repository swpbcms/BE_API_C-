using BCMS.DTO;

namespace BCMS.Interface
{
    public interface IAdmin
    {
        Admin update(string username, string password, string newpass);
        Admin login(string username, string password);
    }
}
