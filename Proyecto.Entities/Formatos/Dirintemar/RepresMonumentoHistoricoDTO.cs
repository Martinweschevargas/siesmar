using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirintemar
{
    public partial class RepresMonumentoHistoricoDTO
    {
        public int RepresMonumentoHistoricoId { get; set; }
        public int? TipoRepresentacionBienHistoricoId { get; set; }
        public string? DenominacionRepresMonumentoHistorico { get; set; }
        public int? TipoMaterialBienHistoricoId { get; set; }
        public string? EstadoConservacion { get; set; }
        public string? NombreEscultor { get; set; }
        public string? FechaEntregaInaguracion { get; set; }
        public string? UbicacionRepresentacion { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public int? ProvinciaUbigeoId { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public int? PaisUbigeoId { get; set; }
        public string? CustorioMonumentoHistorico { get; set; }
        public string? ReferenciaMonumentoHistorico { get; set; }
        public decimal InversionMonumentoHistorico { get; set; }
        public string? DescTipoRepresentacionBienHistorico { get; set; }
        public string? DescTipoMaterialBienHistorico { get; set; }
        public string? Distrito { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDepartamento { get; set; }
        public string? Pais { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
