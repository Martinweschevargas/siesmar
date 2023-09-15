using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class RegistroEquipoSatelitalDTO
    {

        public int? RegistroEquipoSatelitalId { get; set; }
        public string? CodigoIBPEquipoSatelital { get; set; }
        public int? ModeloBienServicioSubcampoId { get; set; }
        public int? ModeloBienServicioDenominacionId { get; set; }
        public int? MarcaId { get; set; }
        public int? ModeloEquipoSatelitalId { get; set; }
        public string? AnioAdquisicionSatelital { get; set; }
        public string? EstadoOperatividadTelefonia { get; set; }
        public int? DependenciaId { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public string? DescModeloBienServicioSubcampo { get; set; }
        public string? DescModeloBienServicioDenominacion { get; set; }
        public string? DescMarca { get; set; }
        public string? DescModeloEquipoSatelital { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescDepartamento { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}