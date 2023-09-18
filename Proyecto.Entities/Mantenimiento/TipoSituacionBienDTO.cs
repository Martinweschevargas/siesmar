using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoSituacionBienDTO
    {
        public int TipoSituacionBienId { get; set; }
        public string? DescTipoSituacionBien { get; set; }
        public string? CodigoTipoSituacionBien { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
