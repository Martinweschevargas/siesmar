using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dintemar
{
    public partial class CambiosCombinacionSeguridadDTO
    {
        public int CambiosCombinacionSeguridadId { get; set; }
        public int? MesId { get; set; }
        public int? AnioCambioCombinacion { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public int? CambiosCombinacionSeguridad { get; set; }
        public int? PorcentajeAvanceCambio { get; set; }

        public string? DescMes { get; set; }
        public string? DescZonaNaval { get; set; }
        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
