using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dicapi
{
    public partial class OtorgamientoDerechoAreaAcuaticaDTO
    {

        public int? OtorgamientoDerechoAreaAcuaticaId { get; set; }
        public int? NumeroDocumento { get; set; }
        public string? FechaIngresoSolicitud { get; set; }
        public string? CodigoDptoRiberaZocaloCont { get; set; }
        public string? PropietarioNave { get; set; }
        public string? CodigoInstalacionTerrestreAcuatica { get; set; }
        public string? DistritoUbigeo { get; set; }
        public int? TiempoConcesion { get; set; }
        public string? TipoTiempo { get; set; }
        public string? FechaAtencionSolicitud { get; set; }
        public string? DescDptoRiberaZocaloCont { get; set; }
        public string? DescInstalacionTerrestreAcuatica { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}