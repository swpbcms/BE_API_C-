using BCMS.DTO.BirdType;
using BCMS.Models;

namespace BCMS.Interface
{
    public interface IBirdType
    {
        Task<List<BirdType>> GetAll();
        Task<BirdType> create(BirdTypeCreateDTO dto);
        Task<BirdType> update(BirdTypeUpdateDTO dto);
        Task<BirdType> delete(string id);
        Task<BirdType> getbyId(string id);
    }
}
