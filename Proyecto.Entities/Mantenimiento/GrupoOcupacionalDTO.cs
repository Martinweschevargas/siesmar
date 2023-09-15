using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GrupoOcupacionalDTO
    {
        public int GrupoOcupacionalId { get; set; }
        public string? DescGrupoOcupacional { get; set; }
        public string? CodigoGrupoOcupacional { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
