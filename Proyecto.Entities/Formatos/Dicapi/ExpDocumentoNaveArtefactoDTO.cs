using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dicapi
{
    public partial class ExpDocumentoNaveArtefactoDTO
    {

        public int? ExpDocumentoNaveArtefactoId { get; set; }
        public int? NumeroDocumento { get; set; }
        public string? FechaIngresoSolicitud { get; set; }
        public string? CodigoDptoMaterialAcuatico { get; set; }
        public string? NombreNaveArtefacto { get; set; }
        public string? PropietarioNave { get; set; }
        public string? RazonSocial { get; set; }
        public string? CodigoClaseNave { get; set; }
        public string? MatriculaNave { get; set; }
        public string? NumericoPais { get; set; }
        public string? FechaAtencionSolicitud { get; set; }
        public string? Observacion { get; set; }
        public string? ResponsableDocumentoExpedido { get; set; }
        public string? CodigoCapitania { get; set; }

        public string? NombrePais { get; set; }
        public string? DescDptoMaterialAcuatico { get; set; }
        public string? DescClaseNave { get; set; }
        
        public string? DescCapitania { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}