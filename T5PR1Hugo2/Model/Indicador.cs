using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T5PR1Hugo2.Model
{
	public class Indicador
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int? AnyDt { get; set; }
		public double? ProduccioNeta { get; set; }
		public double? ConsumGasolina { get; set; }
		public double? DemandaElectrica { get; set; }
		public double? ProduccioDisponible { get; set; }


	}
}
