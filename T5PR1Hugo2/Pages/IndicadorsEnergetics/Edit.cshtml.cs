using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T5PPR1Hugo2.Data;
using T5PPR1Hugo2.Model;
using T5PR1Hugo2.Model;

namespace T5PR1Hugo2.Pages.IndicadorsEnergetics
{
    public class EditModel : PageModel
    {
		private readonly ApplicationDbContext _context;
		public EditModel(ApplicationDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Indicador Indicador { get; set; }
		public async Task<IActionResult> OnGetAsync(int? itemid)
		{
			if (itemid == null || _context.Indicadors == null)
			{
				return NotFound();
			}
			var indicador = await _context.Indicadors.FirstOrDefaultAsync(s => s.Id == itemid);
			if (indicador == null)
			{
				return NotFound();
			}
			Indicador = indicador;
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
				_context.Indicadors.Update(Indicador);
				await _context.SaveChangesAsync();
				return RedirectToPage("/IndicadorsEnergetics/IndicadorsEnergetics");
			}
		}
	}
}
