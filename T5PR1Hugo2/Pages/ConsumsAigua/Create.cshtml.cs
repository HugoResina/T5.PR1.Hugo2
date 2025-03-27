using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T5PPR1Hugo2.Data;
using T5PPR1Hugo2.Model;
using T5PR1Hugo2.Model;

namespace T5PR1Hugo2.Pages.ConsumsAigua

{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Consum consum { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid || _context.Consums == null || consum == null)
            {
                return Page();
            }
            else
            {

                _context.Consums.Add(consum);
                await _context.SaveChangesAsync();
                return RedirectToPage("/ConsumsAigua/ConsumsAigua");
            }
        }
    }
}
