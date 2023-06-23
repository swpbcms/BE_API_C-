using BCMS.DTO.Category;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface ICategory
    {
        Task<List<Category>> GetList();
        Task<Category> GetById(string id);
        Task<List<Category>> GetByName(string name);
        Task<Category> Insert(CategoryDTO newCategory);
        Task<Category> Update(updateCategoryDTO updateCategory);
    }
}
