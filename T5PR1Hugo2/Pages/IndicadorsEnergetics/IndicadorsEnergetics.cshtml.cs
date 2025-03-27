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
			}

		}
        public static List<Indicador> WriteIndicadors()
        {
            //read the file indicadors_energetics_cat.csv and write the data to the database 
            //the csv returns this data:Data,PBEE_Hidroelectr,PBEE_Carbo,PBEE_GasNat,PBEE_Fuel-Oil,PBEE_CiclComb,PBEE_Nuclear,CDEEBC_ProdBruta,CDEEBC_ConsumAux,CDEEBC_ProdNeta,CDEEBC_ConsumBomb,CDEEBC_ProdDisp,CDEEBC_TotVendesXarxaCentral,CDEEBC_SaldoIntercanviElectr,CDEEBC_DemandaElectr,CDEEBC_TotalEBCMercatRegulat,CDEEBC_TotalEBCMercatLliure,FEE_Industria,FEE_Terciari,FEE_Domestic,FEE_Primari,FEE_Energetic,FEEI_ConsObrPub,FEEI_SiderFoneria,FEEI_Metalurgia,FEEI_IndusVidre,FEEI_CimentsCalGuix,FEEI_AltresMatConstr,FEEI_QuimPetroquim,FEEI_ConstrMedTrans,FEEI_RestaTransforMetal,FEEI_AlimBegudaTabac,FEEI_TextilConfecCuirCalçat,FEEI_PastaPaperCartro,FEEI_AltresIndus,DGGN_PuntFrontEnagas,DGGN_DistrAlimGNL,DGGN_ConsumGNCentrTerm,CCAC_GasolinaAuto,CCAC_GasoilA
            //only use the data for the object Indicador: AnyDt, ProduccioNeta, ConsumGasolina, DemandaElectrica, ProduccioDisponible
            string path = "Fitxers/indicadors_energetics_cat.csv";
            List<Indicador> indicadors = new List<Indicador>();

            using (var reader = new StreamReader(path))
            {
                bool isFirstLine = true; 

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (isFirstLine)
                    {
                        isFirstLine = false; 
                        continue;
                    }

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
