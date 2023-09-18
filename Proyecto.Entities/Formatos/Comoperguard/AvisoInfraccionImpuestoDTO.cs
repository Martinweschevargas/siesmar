using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class AvisoInfraccionImpuestoDTO
    {

        public int? AvisoInfraccionImpuestoId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public string? HoraInfraccion { get; set; }
        public string? FechaInfraccion { get; set; }
        public string? NombreNoveInfractora { get; set; }
        public string? MatriculaNaveInfractora { get; set; }
        public int? TipoNaveId { get; set; }
        public int? PaisUbigeoId { get; set; }
        public string? PropietarioNave { get; set; }
        public string? LatitudUbicacionNave { get; set; }
        public string? LongitudUbicacionNave { get; set; }
        public string? AreaIntervencion { get; set; }
        public int? AmbitoNaveId { get; set; }
        public string? SectorExtrainstitucional { get; set; }
        public string? Tenor { get; set; }
        public string? Articulo { get; set; }
        public int? AvisosInfraccion { get; set; }
        public string? Observaciones { get; set; }

        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescTipoNave { get; set; }
        public string? NombrePais { get; set; }
        public string? DescAmbitoNave { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
