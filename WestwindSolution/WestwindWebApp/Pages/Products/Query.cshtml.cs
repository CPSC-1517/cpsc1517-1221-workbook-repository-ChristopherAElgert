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
        #region setup constructor DI
        private readonly CategoryServices _categoryServices;
        
        public QueryModel(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        #endregion

        #region Property to populate Category select element and track its selected value
        public List<Category> CategoryList { get; private set; }

        [BindProperty]
        public int? SelectedCategoryId { get; set; }

        public SelectList CategorySelectList { get; private set; }
        #endregion

        public string FeedBackMessage { get; private set; }

        public void OnGet(int? currentSelectedCategoryId)
        {
            
            //Fetch from the system (CategoryServices) a list of Category
            CategoryList = _categoryServices.List();
            CategorySelectList = new SelectList(_categoryServices.List(), "Id", "CategoryName", SelectedCategoryId);

            if (currentSelectedCategoryId.HasValue && currentSelectedCategoryId.Value > 0)
            {
                SelectedCategoryId = currentSelectedCategoryId;
            }
        }

        public IActionResult OnPostSearchByCategory()
        {
            FeedBackMessage = "Clicked on Category Search";
            return RedirectToPage(new {currentSelectedCategoryId = SelectedCategoryId});
        }

        public IActionResult OnPostSearchByProductName()
        {
            FeedBackMessage = "Clicked on Name Search";
            return RedirectToPage(new { currentSelectedCategoryId = SelectedCategoryId });
        }

        public IActionResult OnPostClearForm()
        {
            FeedBackMessage = "Clicked on Clear";
            return RedirectToPage(new { currentSelectedCategoryId = 0});
        }
    }
}
