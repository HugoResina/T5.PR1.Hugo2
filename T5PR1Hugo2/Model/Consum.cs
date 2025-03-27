using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace T5PR1Hugo2.Model
{
	public class Consum
	{
		
		public int? AnyD { get; set; }
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CodiComarca { get; set; }
		public string? Comarca { get; set; }
		public string? Poblacio { get; set; }
		public double? DomesticXarxa { get; set; }
		public double? ActivitatsEconomiques { get; set; }
		public double? Total { get; set; }
		public double? ConsumDomesticPerCapita { get; set; }

	}
}
