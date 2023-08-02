using BCMS.DTO.BirdType;
using BCMS.Interface;
using BCMS.Models;

namespace BCMS.Services
{
    public class BirdTypeService : IBirdType
    {
        private readonly BCMSContext _context;
        public BirdTypeService(BCMSContext context)
        {
            _context = context;
        }
        public Task<BirdType> create(BirdTypeCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<BirdType> delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BirdType>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BirdType> getbyId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BirdType> update(BirdTypeUpdateDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
