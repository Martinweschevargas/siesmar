using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Centac
{
    public partial class UsoSalaConferenciaDTO
    {

        public int? UsoSalaConferenciaId { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? FechaUsoSala { get; set; }
        public string? TipoConferencia { get; set; }
        public int? NumeroParticipante { get; set; }
        public int? CargaId { get; set; }
        public string? NombreDependencia { get; set; }
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
