using BCMS.DTO;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface ICategory
    {
        Task<List<Category>> GetList();
        Task<Category> GetById(string id);
        Task<Category> GetByName(string name);
        Task<Category> Insert(CategoryDTO newCategory);
        Task<Category> Update(CategoryDTO updateCategory);
        Task<Category> DeleteById(string id);
    }
}
