using System.Net.WebSockets;
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
            if (!Consums.Any())
            {
                List<Consum> consums = WriteConsums();
                foreach (var i in consums)
                {
                    _context.Consums.Add(i);
                }
                await _context.SaveChangesAsync();
            }

        }
        public static List<Consum> WriteConsums()
        {
            string path = "Fitxers/consum_aigua_cat_per_comarques.csv";
            List<Consum> consums = new List<Consum>();

            using (var reader = new StreamReader(path))
            {
                
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    
                    
                    var values = line.Split(',');
                    
                   
                    Consum consum = new Consum();
                    consum.AnyD = int.Parse(values[0]);
                  
                    if (values[2] != "Moianès" && values[2] != "OSONA" && values[2] != "TERRA ALTA")
                    {
                        consum.Comarca = values[3].Replace("\"", "") + values[2].Replace("\"", "");
                        consum.Poblacio = values[4];
                        consum.DomesticXarxa = double.Parse(values[5]);
                        consum.ActivitatsEconomiques = double.Parse(values[6]);
                        consum.Total = double.Parse(values[7]);
                        consum.ConsumDomesticPerCapita = double.Parse(values[8]);
                    }
                    else
                    {
                       //perdoneu la guarrada, pero es que no estic com per buscar una forma optima de tractar aixo
                        consum.Comarca = values[2].Replace("\"", "");
                        consum.Poblacio = values[3];
                        consum.DomesticXarxa = double.Parse(values[4]);
                        consum.ActivitatsEconomiques = double.Parse(values[5]);
                        consum.Total = double.Parse(values[6]);
                        consum.ConsumDomesticPerCapita = double.Parse(values[7]);
                    }
                   

                    consums.Add(consum);

                }
            }
            return consums;

        }
    }
}