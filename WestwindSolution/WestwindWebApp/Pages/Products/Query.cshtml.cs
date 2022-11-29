using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

#region namespaces for BLL and Entities
using WestwindSystem.BLL;
using WestwindSystem.Entities;
#endregion

namespace WestwindWebApp.Pages.Products
{
    public class QueryModel : PageModel
    {
        #region Setup constructor DI for BLL
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;

        public QueryModel(CategoryServices categoryServices, ProductServices productServices)
        {
            _categoryServices = categoryServices;
            _productServices = productServices;

            // Fetch from the system (CategoryServices) a list of Category
            CategoryList = _categoryServices.List();
            CategorySelectionList = new SelectList(_categoryServices.List(), "Id", "CategoryName");

        }
        #endregion

        #region Properties to populate Category select element and track is selected value
        public List<Category> CategoryList { get; private set; }
        [BindProperty()]
        public int SelectedCategoryId { get; set; }

        public SelectList CategorySelectionList { get; private set; }
        #endregion

        [BindProperty]
        public string? QueryProductName { get; set; }

        [TempData]
        public string? FeedbackMessage { get; set; }

        public List<Product>? QueryResultList { get; private set; }

        public void OnGet()
        {            

        }

        public void OnPostSearchByCategory()
        {
            FeedbackMessage = "You click on Search By Category";
            QueryResultList = _productServices.FindProductsByCategoryId(SelectedCategoryId);
            //return RedirectToPage(new { currentSelectedCategoryId = SelectedCategoryId });
        }

        public void OnPostSearchByProductName()
        {
            FeedbackMessage = "You click on Search By Product Name";
            QueryResultList = _productServices.FindProductsByProductName(QueryProductName);

            //return RedirectToPage();
        }

        public IActionResult OnPostClearForm()
        {
            FeedbackMessage = "You click on Clear button";
            //SelectedCategoryId = 0;
            //QueryProductName = null;
            return RedirectToPage();
        }
    }
}
