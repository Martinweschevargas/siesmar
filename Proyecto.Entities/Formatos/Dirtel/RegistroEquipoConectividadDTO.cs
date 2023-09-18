using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class RegistroEquipoConectividadDTO
    {

        public int? RegistroEquipoConectividadId { get; set; }
        public int? ModeloBienServicioSubcampoId { get; set; }
        public int? ModeloBienServicioDenominacionId { get; set; }
        public int? MarcaId { get; set; }
        public string? Conectividad { get; set; }
        public string? Condicion { get; set; }
        public string? NivelCapa { get; set; }
        public string? CantidadPuerto { get; set; }
        public string? AnioAdquisicionConectividad { get; set; }
        public string? EstadoOperatividadConectividad { get; set; }
        public int? DependenciaId { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public string? CodigoIBPEquipoConectividad { get; set; }
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