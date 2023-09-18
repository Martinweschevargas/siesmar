using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dicapi
{
    public partial class ExpDocumentoPersonalAcuaticoDTO
    {

        public int? ExpDocumentoPersonalAcuaticoId { get; set; }
        public int? NumeroDocumento { get; set; }
        public string? FechaIngresoSolicitud { get; set; }
        public string? CodigoDptoPersonalAcuatico { get; set; }
        public int? DocumentoExpedido { get; set; }
        public string? ExpedidoA { get; set; }
        public string? NombreApellidoAcuatico { get; set; }
        public string? CodigoTipoPersonalAcuatico { get; set; }
        public string? CodigoTipoActividadEmpresa { get; set; }
        public string? FechaAtencionSolicitud { get; set; }
        public string? DescDptoPersonalAcuatico { get; set; }
        public string? DescTipoPersonalAcuatico { get; set; }
        public string? DescTipoActividadEmpresa { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}