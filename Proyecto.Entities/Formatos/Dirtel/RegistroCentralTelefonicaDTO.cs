using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class RegistroCentralTelefonicaDTO
    {

        public int? RegistroCentralTelefonicaId { get; set; }
        public string? CodigoIBPCentralTelefonica { get; set; }
        public int? ModeloBienServicioSubcampoId { get; set; }
        public int? ModeloBienServicioDenominacionId { get; set; }
        public int? MarcaId { get; set; }
        public string? TipoProtocoloTelefonia { get; set; }
        public string? TerminalSoportada { get; set; }
        public string? TerminalInstalada { get; set; }
        public string? AnioAdquisicionTelefonia { get; set; }
        public string? EstadoOperatividadTelefonia { get; set; }
        public int? DependenciaId { get; set; }
        public int? DepartamentoUbigeoId { get; set; }

        public string? DescModeloBienServicioSubcampo { get; set; }
        public string? DescModeloBienServicioDenominacion { get; set; }
        public string? DescMarca { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescDepartamento { get; set; }
        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}