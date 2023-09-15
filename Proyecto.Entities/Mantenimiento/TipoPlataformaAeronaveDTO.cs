using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoPlataformaAeronaveDTO
    {
        public int TipoPlataformaAeronaveId { get; set; }
        public string? DescTipoPlataformaAeronave { get; set; }
        public string? CodigoTipoPlataformaAeronave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
