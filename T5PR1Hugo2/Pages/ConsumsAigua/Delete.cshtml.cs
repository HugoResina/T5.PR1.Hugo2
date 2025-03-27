using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T5PPR1Hugo2.Data;
using T5PPR1Hugo2.Model;
using T5PR1Hugo2.Model;

namespace T5PR1Hugo2.Pages.ConsumsAigua
{
    public class DeleteModel : PageModel
    {
		private readonly ApplicationDbContext _context;
		public DeleteModel(ApplicationDbContext context)
		{
			_context = context;
		}
		[BindProperty]
		public Consum Consum { get; set; }
		public async Task<IActionResult> OnGetAsync(int? itemid)
		{
			if (itemid == null)
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

		public async Task<IActionResult> OnPostAsync(int? itemid)
		{
			if (itemid == null)
			{
				return NotFound();
			}
			var consum = await _context.Consums.FindAsync(itemid);
			if (consum != null)
			{
				_context.Consums.Remove(consum);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("/ConsumsAigua/ConsumsAigua");
		}
	}
}
