using Microsoft.AspNetCore.Mvc;
using MyStor.Core.Contracts.Categories;
using MyStor.EndPoints.WebUI.Views.Categories;

namespace MyStor.EndPoints.WebUI.Components
{
    public class NavigationMenuViewComponent: ViewComponent
    {
        private readonly CategoryRepository categoryRepository;

        public NavigationMenuViewComponent(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var model = new NavigationMenuViewModel
            {
                Categories = categoryRepository.GetAll()
            };
            if (RouteData?.Values.ContainsKey("category") == true)
            {
                model.CurrentCategory = RouteData.Values["category"].ToString();
            }
            return View(model);
        }
    }
}
