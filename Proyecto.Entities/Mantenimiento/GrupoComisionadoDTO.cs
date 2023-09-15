using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GrupoComisionadoDTO
    {
        public int GrupoComisionadoId { get; set; }
        public string? DescGrupoComisionado { get; set; }
        public string? CodigoGrupoComisionado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
