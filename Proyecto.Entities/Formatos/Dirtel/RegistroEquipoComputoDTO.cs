using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class RegistroEquipoComputoDTO
    {

        public int? RegistroEquipoComputoId { get; set; }
        public string? CodigoIBPComputo { get; set; }
        public int? TipoComputadoraId { get; set; }
        public int? MarcaId { get; set; }
        public int? ModeloBienServicioSubcampoId { get; set; }
        public int? ModeloBienServicioDenominacionId { get; set; }
        public string? AnioAdquisicionComputo { get; set; }
        public string? EstadoOperatividadComputo { get; set; }
        public int? DependenciaId { get; set; }
        public int? DepartamentoUbigeoId { get; set; }

        public string? DescTipoComputadora { get; set; }
        public string? DescMarca { get; set; }
        public string? DescModeloBienServicioSubcampo { get; set; }
        public string? DescModeloBienServicioDenominacion { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescDepartamento { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}