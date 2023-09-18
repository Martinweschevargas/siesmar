using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comciberdef
{
    public partial class CapacidadComandanciaCiberdefensaDTO
    {

        public int? CapacidadComandanciaCiberdefensaId { get; set; }
        public int? AnioCapacidadCiberdefensa { get; set; }
        public decimal? CapacidadComandoControl { get; set; }
        public decimal? CapacidadOperacionesDefensa { get; set; }
        public decimal? CapacidadOperacionesExplotacion { get; set; }
        public decimal? CapacidadOperacionRespuesta { get; set; }
        public decimal? CapacidadInvestigacionDigital { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
