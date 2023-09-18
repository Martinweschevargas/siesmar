using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dicapi
{
    public partial class ExpNavePrevencionContaminacionDTO
    {

        public int? ExpNavePrevencionContaminacionId { get; set; }
        public int? NumeroDocumento { get; set; }
        public string? FechaIngresoSolicitud { get; set; }
        public string? CodigoDptoProteccionMedioAmbiente { get; set; }
        public int? DocumentoExpedido { get; set; }
        public string? NombreNaveArtefacto { get; set; }
        public string? CodigoClaseNave { get; set; }
        public string? CodigoInstalacionTerrestreAcuatica { get; set; }
        public string? MatriculaNave { get; set; }
        public string? PropietarioNave { get; set; }
        public string? NumericoPais { get; set; }
        public string? FechaAtencionSolicitud { get; set; }
        public string? DescDptoProteccionMedioAmbiente { get; set; }
        public string? DescClaseNave { get; set; }
        public string? DescInstalacionTerrestreAcuatica { get; set; }
        public string? NombrePais { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}