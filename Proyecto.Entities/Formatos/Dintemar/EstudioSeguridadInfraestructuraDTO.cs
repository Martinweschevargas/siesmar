using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dintemar
{
    public partial class EstudioSeguridadInfraestructuraDTO
    {
        public int EstudioSeguridadInfraestructuraId { get; set; }
        public int? MesId { get; set; }
        public int? AnioEstudio { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public int? EstudioSeguridadInfraestructura { get; set; }
        public int? PorcentajeAvanceEstudio { get; set; }


        public string? DescMes { get; set; }
        public string? DescZonaNaval { get; set; }
        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
