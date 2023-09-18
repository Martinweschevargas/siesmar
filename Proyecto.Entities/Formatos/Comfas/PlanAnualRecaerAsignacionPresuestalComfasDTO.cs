using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class PlanAnualRecaerAsignacionPresuestalComfasDTO
    {

        public int? PlanAnualRecaerAsignacionPresuestalId { get; set; }
        public decimal? AsignadoProgramaAnual { get; set; }
        public decimal? Bienes { get; set; }
        public decimal? Servicios { get; set; }
        public decimal? AsignadoAnual { get; set; }
        public decimal? GastosBienes { get; set; }
        public decimal? GastosServicios { get; set; }



        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
