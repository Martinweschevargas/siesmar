using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SistemaMunicionDTO
    {
        public int SistemaMunicionId { get; set; }
        public string? CodigoSistemaMunicion { get; set; }
        public string? DescSistemaMunicion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
