using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T5PPR1Hugo2.Data;
using T5PPR1Hugo2.Model;
using T5PR1Hugo2.Model;

namespace T5PR1Hugo2.Pages.ConsumsAigua
{
    public class ConsumsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ConsumsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Consum> Consums { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Simulations != null)
            {
                Consums = await _context.Consums.ToListAsync();
            }
        }
    }
}