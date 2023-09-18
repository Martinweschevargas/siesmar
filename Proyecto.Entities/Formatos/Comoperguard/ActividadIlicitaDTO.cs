using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class ActividadIlicitaComoperguardDTO
    {

        public int? FActividadIlicitaId { get; set; }
        public string? CodigoJefaturaDistritoCapitania { get; set; }
        public string? CodigoCapitania { get; set; }
        public string? FechaIntervencion { get; set; }
        public string? CodigoActividadIlicita { get; set; }
        public string? CodigoTomaConocimiento { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public int? CascoNave { get; set; }
        public string? LatitudUbicacionNave { get; set; }
        public string? LongitudUbicacionNave { get; set; }
        public string? CodigoAmbitoNave { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? NombreNave { get; set; }
        public string? MatriculaNave { get; set; }
        public string? NumericoPais { get; set; }
        public string? CodigoTipoNave { get; set; }
        public int? NumeroIntervenidos { get; set; }
        public string? CodigoMaterialIncautado { get; set; }
        public int? CantidadMaterialIncautado { get; set; }
        public string? CodigoUnidadMedida { get; set; }
        public string? DocumentoInformacion { get; set; }
        public string? FechaDocumento { get; set; }
        public string? ObservacionIntervencion { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescActividadIlicita { get; set; }
        public string? DescTomaConocimiento { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescAmbitoNave { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDepartamento { get; set; }
        public string? NombrePais { get; set; }
        public string? DescTipoNave { get; set; }
        public string? DescMaterialIncautado { get; set; }
        public string? DescUnidadMedida { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
