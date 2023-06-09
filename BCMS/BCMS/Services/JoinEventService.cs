﻿using BCMS.DTO.Interact;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Services
{
    public class JoinEventService : IJoinEvent
    {
        private readonly BCMSContext _context;
        public JoinEventService(BCMSContext context)
        {
            _context = context;
        }

        public async Task<bool> DisJoin(JoinEventDTO join)
        {
            try
            {
                var check = await this._context.JoinEvent.Where(x=>x.PostId.Equals(join.PostId) && x.MemberId.Equals(join.MemberId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Status = false;
                    await this._context.SaveChangesAsync();

                    var post = await this._context.Post.Where(x => x.PostId.Equals(join.PostId)).FirstOrDefaultAsync();
                    post.PostNumberJoin -= 1;

                    await this._context.SaveChangesAsync();
                    return true;
                }return false;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Follow(JoinEventDTO join)
        {
            try
            {
                var check = await this._context.JoinEvent.Where(x => x.PostId.Equals(join.PostId) && x.MemberId.Equals(join.MemberId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Status = true;
                    check.IsFollow = true;
                    await this._context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    var joinEV = new JoinEvent();
                    joinEV.PostId = join.PostId;
                    joinEV.MemberId = join.MemberId;
                    joinEV.Status= join.Status;
                    joinEV.IsFollow = true;

                    await this._context.JoinEvent.AddAsync(joinEV);
                    await this._context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Join(JoinEventDTO join)
        {
            try
            {
                var check = await this._context.JoinEvent.Where(x => x.PostId.Equals(join.PostId) && x.MemberId.Equals(join.MemberId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Status = true;
                    check.IsFollow = true;

                    var post = await this._context.Post.Where(x => x.PostId.Equals(join.PostId)).FirstOrDefaultAsync();
                    post.PostNumberJoin += 1;

                    await this._context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    var joinEV = new JoinEvent();
                    joinEV.PostId = join.PostId;
                    joinEV.MemberId = join.MemberId;
                    joinEV.Status = true;
                    joinEV.IsFollow = true;
                    joinEV.DateTime = DateTime.Now;

                    await this._context.JoinEvent.AddAsync(joinEV);
                    await this._context.SaveChangesAsync();

                    var post = await this._context.Post.Where(x=>x.PostId.Equals(join.PostId)).FirstOrDefaultAsync();
                    post.PostNumberJoin += 1;

                    await this._context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UnFollow(JoinEventDTO join)
        {
            try
            {
                var check = await this._context.JoinEvent.Where(x => x.PostId.Equals(join.PostId) && x.MemberId.Equals(join.MemberId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.IsFollow = false;
                    await this._context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
