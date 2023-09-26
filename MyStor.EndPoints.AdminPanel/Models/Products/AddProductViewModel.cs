using MyStor.Core.Domain.Categories;

namespace MyStor.EndPoints.AdminPanel.Models.Products
{
    public class AddProductViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public decimal Price { get; set; }
        public int CatagoryId { get; set; }
        public List<Category>? CategoyForDisplay { get; set; }
    }
}
