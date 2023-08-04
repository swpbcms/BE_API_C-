using BCMS.DTO.Manager;
using BCMS.DTO.Member;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface IManager
    {
        Task<List<Manager>> GetList();
        Task<List<Member>> GetListmem();
        Task<Member> Acceptmem(string memid);
        Task<Manager> GetById(string id);
        Task<List<Manager>> GetByName(string name);
        Task<Manager> Register(ManagerCreateDTO newMem);
        Task<Manager> Update(ManagerUpdateDTO updateMem);
        Task<Manager> Login(ManagerLoginDTO login);
        Task<Manager> DeleteByID(string id);
    }
}
