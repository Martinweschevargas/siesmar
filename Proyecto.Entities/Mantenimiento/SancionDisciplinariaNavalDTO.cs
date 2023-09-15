using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SancionDisciplinariaNavalDTO
    {
        public int SancionDisciplinariaNavalId { get; set; }
        public string? DescSancionDisciplinariaNaval { get; set; }
        public string? CodigoSancionDisciplinariaNaval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
