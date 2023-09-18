using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MotivoTerminoCursoDTO
    {
        public int MotivoTerminoCursoId { get; set; }
        public string?DescMotivoTerminoCurso { get; set; }
        public string?CodigoMotivoTerminoCurso { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
