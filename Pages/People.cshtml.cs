using azure_web_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace azure_web_app.Pages
{
    public class PeopleModel : PageModel
    {
        private readonly MyDbContext _context;

        public PeopleModel(MyDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            
        }
    }
}
