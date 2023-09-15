using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DptoPersonalAcuaticoDTO
    {
        public int DptoPersonalAcuaticoId { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
