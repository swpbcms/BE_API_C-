using BCMS.DTO.Manager;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BCMS.Services
{
    public class ManagerService : IManager
    {
        private readonly BCMSContext _context;
        public ManagerService(BCMSContext context)
        {
            _context = context;
        }

        public async Task<Member> Acceptmem(string memid)
        {
            try
            {
                var check = await this._context.Member.Where(x=>x.MemberId== memid).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.MemberStatus = "active";
                    this._context.Member.Update(check);
                    await this._context.SaveChangesAsync();
                    return check;
                }
                else
                {
                    throw new Exception("null");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Manager> DeleteByID(string id)
        {
            try
            {
                var check = await this._context.Manager.Where(x=>x.ManagerId.Equals(id)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.ManagerStatus = false;
                    this._context.Manager.Update(check);
                    await this._context.SaveChangesAsync();

                    return check;
                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Manager> GetById(string id)
        {
            try
            {
                var check = await this._context.Manager.Where(x => x.ManagerId.Equals(id)).FirstOrDefaultAsync();
                if (check != null)
                {
                    return check;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Manager>> GetByName(string name)
        {
            try
            {
                var check = await this._context.Manager.Where(x => x.ManagerFullName.Contains(name)).ToListAsync();
                if (check != null)
                {
                    return check;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Manager>> GetList()
        {
            try
            {
                var check = await this._context.Manager.ToListAsync();
                if (check != null)
                {
                    return check;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Member>> GetListmem()
        {
            try
            {
                var check = await this._context.Member.Where(x => x.MemberStatus.Equals("pending")).ToListAsync();
                if (check != null)
                {
                    return check;
                }
                else
                {
                    throw new Exception("null");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Manager> Login(ManagerLoginDTO login)
        {
            try
            {
                var check = await this._context.Manager.Where(x => x.ManagerUserName.Equals(login.ManagerUserName)&& x.ManagerPassword.Equals(login.ManagerPassword)).FirstOrDefaultAsync();
                if (check != null)
                {
                    return check;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Manager> Register(ManagerCreateDTO newMem)
        {
            try
            {
                var mng = new Manager();
                mng.ManagerStatus = true;
                mng.ManagerUserName = newMem.ManagerUserName;
                mng.ManagerPassword = newMem.ManagerPassword;
                mng.ManagerPhone = newMem.ManagerPhone;
                mng.ManagerEmail = newMem.ManagerEmail;
                mng.ManagerImage = newMem.ManagerImage;
                mng.ManagerFullName = newMem.ManagerFullName;
                mng.ManagerId = "MNG"+Guid.NewGuid().ToString().Substring(0,7);

                await this._context.Manager.AddAsync(mng);
                await this._context.SaveChangesAsync();

                return mng;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Manager> Update(ManagerUpdateDTO updateMem)
        {
            try
            {
                var check = await this._context.Manager.Where(x => x.ManagerId.Equals(updateMem.ManagerID)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.ManagerPhone = updateMem.ManagerPhone;
                    check.ManagerEmail = updateMem.ManagerEmail;
                    check.ManagerImage = updateMem.ManagerImage;
                    check.ManagerFullName = updateMem.ManagerFullName;
                    check.ManagerPassword = updateMem.ManagerPassword;
                    this._context.Manager.Update(check);
                    await this._context.SaveChangesAsync();
                    return check;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
