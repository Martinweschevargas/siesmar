using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class RegistroServidorDTO
    {

        public int? RegistroServidorId { get; set; }
        public string? CodigoIBPServidor { get; set; }
        public int? ModeloBienServicioSubcampoId { get; set; }
        public int? ModeloBienServicioDenominacionId { get; set; }
        public int? MarcaId { get; set; }
        public string? CapacidadMemoriaRam { get; set; }
        public string? CapacidadDiscoDuro { get; set; }
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