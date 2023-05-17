using azure_web_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace azure_web_app.Pages
{
	public class PeopleModel : PageModel
	{
		private readonly MyDbContext _context;

		public List<Person> People { get; set; } = new List<Person>();

		//BindProperty will bind the values provided in the input fields to
		//the Person properties
		//name="id" will be the id, name="name" will be the name and so on
		[BindProperty]
		public Person NewPerson { get; set; }

		public PeopleModel(MyDbContext context)
		{
			_context = context;
		}

		public void OnGet()
		{
			People = _context.People.ToList();
		}

		public IActionResult OnPost()
		//IActionResult is the type in order to return to another page
		//void is not able to return to another page
		{
			_context.People.Add(NewPerson);
			_context.SaveChanges();
			//entity framework save changes

			return RedirectToPage();
			//redirect to OnGet()
		}

		public IActionResult OnPostResetList()
		{

			foreach (var person in _context.People)
			{
				_context.People.Remove(person);
			}

			_context.SaveChanges();
			return RedirectToPage();
		}

	}
}
