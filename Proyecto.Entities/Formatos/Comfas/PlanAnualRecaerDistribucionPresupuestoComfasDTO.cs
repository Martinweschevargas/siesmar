using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class PlanAnualRecaerDistribucionPresupuestoComfasDTO
    {

        public int? PlanAnualRecaerDistribucionPresupuestoId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? TotalAsignadoDependencia { get; set; }
        public decimal? ServicioSimac { get; set; }
        public decimal? ServicioIndustriaPrivada { get; set; }
        public decimal? AdquisicionRepuestos { get; set; }
        public decimal? Equipos { get; set; }
        public decimal? PorcentajeAvanceEjecucion { get; set; }



        public string? DescUnidadNaval { get; set; }

 
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
 

    }
}
