using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T5PPR1Hugo2.Data;
using T5PPR1Hugo2.Model;
using T5PR1Hugo2.Model;

namespace T5PR1Hugo2.Pages.IndicadorsEnergetics
{
    public class DeleteModel : PageModel
    {
		private readonly ApplicationDbContext _context;
		public DeleteModel(ApplicationDbContext context)
		{
			_context = context;
		}
		[BindProperty]
		public Indicador Indicador { get; set; }
		public async Task<IActionResult> OnGetAsync(int? itemid)
		{
			if (itemid == null)
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

		public async Task<IActionResult> OnPostAsync(int? itemid)
		{
			if (itemid == null)
			{
				return NotFound();
			}
			var indicador = await _context.Indicadors.FindAsync(itemid);
			if (indicador != null)
			{
				_context.Indicadors.Remove(indicador);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("/IndicadorsEnergetics/IndicadorsEnergetics");
		}
	}
}
