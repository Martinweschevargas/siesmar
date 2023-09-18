using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class LugarFormacionServicioMilitarDTO
    {
        public int LugarFormacionServicioMilitarId { get; set; }
        public string? DescLugarFormacionServicioMilitar { get; set; }
        public string? CodigoLugarFormacionServicioMilitar { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
