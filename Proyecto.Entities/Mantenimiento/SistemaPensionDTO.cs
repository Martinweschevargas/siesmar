using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SistemaPensionDTO
    {
        public int SistemaPensionId { get; set; }
        public string? DescSistemaPension { get; set; }
        public string? CodigoSistemaPension { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
