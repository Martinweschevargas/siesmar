using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Centac
{
    public partial class EntrenamientoInstruccionDTO
    {

        public int? EntrenamientoInstruccionId { get; set; }
        public string? FechaEntrenamiento { get; set; }
        public string? CodigoDependencia { get; set; }
        public int? DuracionHoras { get; set; }
        public int? NumeroParticipantes { get; set; }
        public int? CargaId { get; set; }

        public string? NombreDependencia { get; set; }
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
