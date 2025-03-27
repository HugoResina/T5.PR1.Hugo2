using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T5PPR1Hugo2.Data;
using T5PPR1Hugo2.Model;
using T5PR1Hugo2.Model;

namespace T5PR1Hugo2.Pages.ConsumsAigua
{
    public class EditModel : PageModel
    {
		private readonly ApplicationDbContext _context;
		public EditModel(ApplicationDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Consum Consum { get; set; }
		public async Task<IActionResult> OnGetAsync(int? itemid)
		{
			if (itemid == null || _context.Consums == null)
			{
				return NotFound();
			}
			var consum = await _context.Consums.FirstOrDefaultAsync(s => s.CodiComarca == itemid);
			if (consum == null)
			{
				return NotFound();
			}
			Consum = consum;
			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			else
			{
				_context.Consums.Update(Consum);
				await _context.SaveChangesAsync();
				return RedirectToPage("./ConsumsAigua");
			}
		}
	}
}
