using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class RegistroHardwareSoftwareSIDTO
    {

        public int? RegistroHardwareSoftwareSIId { get; set; }
        public string? CodigoIBPHardwareSoftwareSI { get; set; }
        public string? CodigoModeloBienServicioSubcampo { get; set; }
        public string? CodigoModeloBienServicioDenominacion { get; set; }
        public string? CodigoMarca { get; set; }
        public string? AnioAdquisicionHardwareSoftwareSI { get; set; }
        public string? CodigoDependencia { get; set; }


        public string? DescModeloBienServicioSubcampo { get; set; }
        public string? DescModeloBienServicioDenominacion { get; set; }
        public string? DescMarca { get; set; }
        public string? DescDependencia { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}