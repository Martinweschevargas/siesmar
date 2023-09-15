using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ModalidadBienAdquirirDTO
    {
        public int ModalidadBienAdquirirId { get; set; }
        public string? DescModalidadBienAdquirir { get; set; }
        public string? CodigoModalidadBienAdquirir { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
