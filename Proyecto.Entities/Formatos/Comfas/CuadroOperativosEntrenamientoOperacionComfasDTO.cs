using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class CuadroOperativosEntrenamientoOperacionComfasDTO
    {

        public int? CuadroOperativoEntrenamientoOperacionId { get; set; }
        public string? Fecha { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraTermino { get; set; }
        public string? Evento { get; set; }
        public string? OCEConductorControl { get; set; }
        public string? UnidadAeronaveParticipante { get; set; }
        public string? Area { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
