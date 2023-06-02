using BCMS.DTO;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BCMS.Services
{
    public class CategoryService : ICategory
    {
        private readonly BCMSContext _context;
        public CategoryService(BCMSContext context)
        {
            _context = context;
        }
        public Task<Category> DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetByName(string name)
        {
            try
            {
                var category = await this._context.Category.Where(x=>x.CategoryName.Contains(name)).FirstOrDefaultAsync();
                if (category == null)
                {
                    return null;
                }
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Category>> GetList()
        {
            try
            {
                var category = await this._context.Category.ToListAsync();
                if(category == null)
                {
                    return null;
                }return category;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Category> Insert(CategoryDTO newCategory)
        {
            try
            {
                Category cate = new Category();
                cate.CategoryId = "Cate"+ Guid.NewGuid().ToString().Substring(0,6);
                cate.CategoryName = newCategory.CategoryName;
                cate.Description = newCategory.Description;
                await this._context.Category.AddAsync(cate);
                await this._context.SaveChangesAsync();

                return cate;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Category> Update(CategoryDTO updateCategory)
        {
            throw new NotImplementedException();
        }
    }
}
