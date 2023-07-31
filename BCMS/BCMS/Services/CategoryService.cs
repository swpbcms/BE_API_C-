using BCMS.DTO.Category;
using BCMS.Interface;
using BCMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BCMS.Services
{
    public class CategoryService : ICategory
    {
        private readonly BCMSContext _context;
        public CategoryService(BCMSContext context)
        {
            _context = context;
        }

        public async Task<Category> GetById(string id)
        {
            try
            {
                var category = await this._context.Category.Where(x => x.CategoryId.Equals(id)).FirstOrDefaultAsync();
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

        public async Task<List<Category>> GetByName(string name)
        {
            try
            {
                var category = await this._context.Category.Where(x=>x.CategoryName.Contains(name)).ToListAsync();
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

        public async Task<Category> Update(updateCategoryDTO updateCategory)
        {
            try
            {
                var cate = await this._context.Category.Where(x=>x.CategoryId.Equals(updateCategory.CategoryId)).FirstOrDefaultAsync();
                if(cate == null)
                {
                    throw new Exception("invalid category id");
                }
                cate.CategoryName = updateCategory.CategoryName;
                cate.Description = updateCategory.Description;
                this._context.Category.Update(cate);
                await this._context.SaveChangesAsync();

                return cate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
