using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class IncidenteOcurridoDTO
    {
        public int IncidenteOcurridoId { get; set; }
        public string? DescIncidenteOcurrido { get; set; }
        public string? AspectoEvaluarIncidenteOcurrido { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
