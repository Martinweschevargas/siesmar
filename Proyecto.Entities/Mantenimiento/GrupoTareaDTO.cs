using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GrupoTareaDTO
    {
        public int GrupoTareaId { get; set; }
        public string? DescGrupoTarea { get; set; }
        public string? CodigoGrupoTarea { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
