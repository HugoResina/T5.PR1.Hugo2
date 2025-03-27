using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T5PPR1Hugo2.Data;
using T5PPR1Hugo2.Model;
using T5PR1Hugo2.Model;

namespace T5PR1Hugo2.Pages.IndicadorsEnergetics
{

	public class IndicadorsEnergeticsModel : PageModel
	{
        private readonly ApplicationDbContext _context;
        public IndicadorsEnergeticsModel(ApplicationDbContext context)
		{
			_context = context;
		}
		public List<Indicador> Indicadors { get; set; }
		public async Task OnGetAsync()
		{
			if (_context.Indicadors != null)
			{
				Indicadors = await _context.Indicadors.ToListAsync();
			}
			if (!Indicadors.Any())
			{
                List<Indicador> indicadors = WriteIndicadors();
                foreach (var i in indicadors)
                {
                    _context.Indicadors.Add(i);
                }
                await _context.SaveChangesAsync();
			}

		}
        public static List<Indicador> WriteIndicadors()
        {
           string path = "Fitxers/indicadors_energetics_cat.csv";
            List<Indicador> indicadors = new List<Indicador>();

            using (var reader = new StreamReader(path))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                   

                    var values = line.Split(',');
                    Indicador indicador = new Indicador();
                    indicador.AnyDt = int.Parse(values[0].Split('/')[1]);
                    indicador.ProduccioNeta = double.Parse(values[10]);
                    indicador.ConsumGasolina = double.Parse(values[39]);
                    indicador.DemandaElectrica = double.Parse(values[14]);
                    indicador.ProduccioDisponible = double.Parse(values[11]);

                    indicadors.Add(indicador);
                }
            }
            return indicadors;

        }
    }
	

}
