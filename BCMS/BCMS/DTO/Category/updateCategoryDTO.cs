using System.ComponentModel.DataAnnotations;

namespace BCMS.DTO.Category
{
    public class updateCategoryDTO
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
