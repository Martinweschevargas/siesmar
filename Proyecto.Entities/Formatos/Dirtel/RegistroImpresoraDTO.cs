using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class RegistroImpresoraDTO
    {

        public int? RegistroImpresoraId { get; set; }
        public string? CodigoIBPImpresora { get; set; }
        public int? ModeloBienServicioSubcampoId { get; set; }
        public int? ModeloBienServicioDenominacionId { get; set; }
        public string? ColorImpresion { get; set; }
        public int? MarcaId { get; set; }
        public string? AnioAdquisicionServidor { get; set; }
        public string? EstadoOperatividadServidor { get; set; }
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