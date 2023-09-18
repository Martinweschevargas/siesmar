using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ModalidadProgramaDTO
    {
        public int ModalidadProgramaId { get; set; }
        public string? DescModalidadPrograma { get; set; }
        public string? CodigoModalidadPrograma { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
