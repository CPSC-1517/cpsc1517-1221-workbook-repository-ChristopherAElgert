using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WestwindWebApp.Pages
{
    public class FormControlDemoUsingTagHelpersModel : PageModel
    {
        [TempData]
        public string FeedbackMessage { get; set; } = string.Empty;

        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public string Gender { get; set; } = string.Empty;

        [BindProperty]
        public string Department { get; set; } = string.Empty;

        [BindProperty] 
        public string Comments { get; set; } = string.Empty;

        [BindProperty]
        public bool Subscribe { get; set; }

        public string[] GenderOptions { get; } = {"Male", "Female", "Unspecified" };

        public SelectListItem[] DepartmentListItems =  
        { 
            new SelectListItem { Value = "DMIT", Text = "Digital Media and IT"},
            new SelectListItem { Value = "BAIST", Text = "Bachelor of Applied Information Systems Technolog"},
            new SelectListItem { Value = "CNT", Text = "Computer Network Technology"},
            new SelectListItem { Value = "CET", Text = "Computer Engineering Technology"},

        };

        public void OnGet()
        {
        }

        public void OnPost()
        {
            FeedbackMessage = $"Username = {Username}, Age = {Age}, Gender = {Gender}, Department = {Department}, Comments = {Comments}, Subscribe = {Subscribe}";
        }
    }
}
