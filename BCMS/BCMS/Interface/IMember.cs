using BCMS.DTO.Category;
using BCMS.DTO.Member;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface IMember
    {
        Task<List<Member>> GetList();
        Task<Member> GetById(string id);
        Task<List<Member>> GetByName(string name);
        Task<Member> Register(MemberRegisterDTO newMem);
        Task<Member> Update(updateMemberDTO updateMem);
        Task<Member> Login(MemberLoginDTO login);
        Task<Member> DeleteByID(string id);
    }
}
