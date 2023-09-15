using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SectorExtraInstitucionalDTO
    {
        public int SectorExtraInstitucionalId { get; set; }
        public string? DescSectorExtraInstitucional { get; set; }
        public string? CodigoSectorExtraInstitucional { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
