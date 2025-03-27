using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T5PPR1Hugo2.Data;
using T5PPR1Hugo2.Model;

namespace T5PPR1Hugo2.Pages.Energies
{
    public class SimulationsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public SimulationsModel(ApplicationDbContext context)
		{
			_context = context;
		}
        public List<Simulation> Simulations { get; set; }
        public async Task OnGetAsync()
        {
            if(_context.Simulations != null)
			{
				Simulations = await _context.Simulations.ToListAsync();
			}
        }
    }
}
