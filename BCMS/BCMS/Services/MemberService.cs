using BCMS.DTO.Member;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BCMS.Services
{
    public class MemberService : IMember
    {
        private readonly BCMSContext _context;
        public MemberService(BCMSContext context)
        {
            _context = context;
        }
        public async Task<Member> DeleteByID(string id)
        {
            try
            {
                var mem = await this._context.Member.Where(x=>x.MemberId.Equals(id)).FirstOrDefaultAsync();
                if (mem != null)
                {
                    mem.MemberStatus = false;
                    await this._context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("not valid member id");
                }

                return mem;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Member> GetById(string id)
        {
            try
            {
                var mem = await this._context.Member.Where(x => x.MemberId.Equals(id))
                    .Select(x => new Member
                    {
                        MemberGender = x.MemberGender,
                        MemberCreateAt = x.MemberCreateAt,
                        MemberDob = x.MemberDob,
                        MemberEmail = x.MemberEmail,
                        MemberFullName = x.MemberFullName,
                        MemberId = x.MemberId,
                        MemberImage = x.MemberImage,
                        MemberStatus = x.MemberStatus
                    })
                    .FirstOrDefaultAsync();
                if (mem != null)
                {
                    return mem;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Member> GetByName(string name)
        {
            try
            {
                var mem = await this._context.Member.Where(x=>x.MemberFullName.Contains(name))
                    .Select(x => new Member
                    {
                        MemberGender = x.MemberGender,
                        MemberCreateAt = x.MemberCreateAt,
                        MemberDob = x.MemberDob,
                        MemberEmail = x.MemberEmail,
                        MemberFullName = x.MemberFullName,
                        MemberId = x.MemberId,
                        MemberImage = x.MemberImage,
                        MemberStatus = x.MemberStatus
                    })
                    .FirstOrDefaultAsync();
                if (mem != null)
                {
                    return mem;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Member>> GetList()
        {
            try
            {
                var mem = await this._context.Member
                    .Select(x=> new Member
                    {
                        MemberGender = x.MemberGender,
                        MemberCreateAt= x.MemberCreateAt,
                        MemberDob= x.MemberDob,
                        MemberEmail= x.MemberEmail,
                        MemberFullName= x.MemberFullName,
                        MemberId= x.MemberId,
                        MemberImage= x.MemberImage,
                        MemberStatus= x.MemberStatus
                    })
                    .ToListAsync();
                if(mem != null)
                {
                    return mem;
                }return null;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Member> Login(MemberLoginDTO login)
        {
            try
            {
                var checkLogin = await this._context.Member.Where(x=>x.MemberUserName.Equals(login.MemberUserName)
                && x.MemberPassword.Equals(login.MemberPassword) && x.MemberStatus).FirstOrDefaultAsync();
                if (checkLogin == null)
                {
                    throw new Exception("invalid account");
                }
                return checkLogin;
            }catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Member> Register(MemberRegisterDTO newMem)
        {
            try
            {
                var mem = new Member();
                mem.MemberUserName = newMem.MemberUserName;
                mem.MemberPassword = newMem.MemberPassword;
                mem.MemberGender = newMem.MemberGender;
                mem.MemberCreateAt = DateTime.Now;
                mem.MemberDob = newMem.MemberDob;
                mem.MemberEmail = newMem.MemberEmail;
                mem.MemberImage = newMem.MemberImage;
                mem.MemberStatus = true;
                mem.MemberId = "Mem"+Guid.NewGuid().ToString().Substring(0,7);
                mem.MemberFullName= newMem.MemberFullName;
                
                await this._context.Member.AddAsync(mem);
                await this._context.SaveChangesAsync();

                return mem;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Member> Update(updateMemberDTO updateMem)
        {
            try
            {
                var mem = await this._context.Member.Where(x => x.MemberId.Equals(updateMem.MemberId)).FirstOrDefaultAsync();
                mem.MemberPassword = updateMem.MemberPassword;
                mem.MemberGender = updateMem.MemberGender;
                mem.MemberDob = updateMem.MemberDob;
                mem.MemberEmail = updateMem.MemberEmail;
                mem.MemberImage = updateMem.MemberImage;
                mem.MemberFullName = updateMem.MemberFullName;

                this._context.Member.Update(mem);
                await this._context.SaveChangesAsync();

                return mem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
