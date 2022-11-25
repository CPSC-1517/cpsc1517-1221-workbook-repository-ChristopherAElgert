using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region namespaces for BLL and Entities
using WestwindSystem.BLL;
using WestwindSystem.Entities;
#endregion

namespace WestwindWebApp.Pages.Products
{
    public class ProductCrudModel : PageModel
    {
        #region internal fields
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;

        #endregion

        #region data properties for page
        [BindProperty(SupportsGet = true)]
        public int? EditProductId { get; set; }

        #endregion

        #region constructor with depdendencies

        #endregion

        #region page handlers
        public void OnGet()
        {
        }

        #endregion
    }
}