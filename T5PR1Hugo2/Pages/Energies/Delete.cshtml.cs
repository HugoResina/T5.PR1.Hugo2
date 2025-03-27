using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T5PPR1Hugo2.Data;
using T5PPR1Hugo2.Model;


namespace T5PR1Hugo2.Pages.Energies
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context)
		{
			_context = context;
		}
        [BindProperty]
        public Simulation Simulation { get; set; }
        public async Task<IActionResult> OnGetAsync(int? itemid)
        {
            if(itemid == null)
            {
                return NotFound();
            }
            var simulation = await _context.Simulations.FirstOrDefaultAsync(s => s.Id == itemid);
            if(simulation == null)
			{
				return NotFound();
			}
            Simulation = simulation;
			return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? itemid)
		{
			if(itemid == null)
			{
				return NotFound();
			}
			var simulation = await _context.Simulations.FindAsync(itemid);
			if(simulation != null)
			{
				_context.Simulations.Remove(simulation);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("./Simulations");
		}
    }
}
