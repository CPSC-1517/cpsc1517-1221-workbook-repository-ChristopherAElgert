using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSyntaxDemo.Pages
{
    public class FormExample2Model : PageModel
    {
        public string FeedbackMessage { get; private set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var rand = new Random();
            var generatedNumbers = new List<int>();

            while(generatedNumbers.Count < 7)
            {
                var randomNumber = rand.Next(1, 51);
                if (!generatedNumbers.Contains(randomNumber))
                {
                    generatedNumbers.Add(randomNumber);
                }
            }
            //sort list
            generatedNumbers.Sort();
            FeedbackMessage = "";
            foreach (var num in generatedNumbers)
            {
                FeedbackMessage += num + " ";
            }
            

        }
    }
}
