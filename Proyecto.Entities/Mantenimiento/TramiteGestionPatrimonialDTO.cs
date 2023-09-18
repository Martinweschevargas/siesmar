using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TramiteGestionPatrimonialDTO
    {
        public int TramiteGestionPatrimonialId { get; set; }
        public string? DescTramiteGestionPatrimonial { get; set; }
        public string? CodigoTramiteGestionPatrimonial { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
