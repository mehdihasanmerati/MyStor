using MyStor.Core.Domain.Categories;

namespace MyStor.EndPoints.WebUI.Views.Categories
{
    public class NavigationMenuViewModel
    {
        public List<Category> Categories { get; set; }
        public string CurrentCategory { get; set; }
    }
}
