using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CanalDenunciaDTO
    {
        public int CanalDenunciaId { get; set; }
        public string? DescCanalDenuncia { get; set; }
        public string? CodigoCanalDenuncia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
