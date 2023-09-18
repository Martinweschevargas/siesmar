using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diabaste
{
    public partial class ConsumoRacionUnidadDependenciaDTO
    {

        public int? ConsumoRacionUnidadDependenciaId { get; set; }
        public int? Anio { get; set; }
        public string? NumeroMes { get; set; }
        public string? CodigoAreaDiperadmon { get; set; }
        public string? CodigoTipoRacion { get; set; }
        public int? NumeroRacionRequerida { get; set; }
        public int? NumeroRacionConsumida { get; set; }
        public int? NumeroPersonalSuperior { get; set; }
        public int? NumeroPersonaSubalterno { get; set; }
        public int? NumeroPersonalMineria { get; set; }
        public int? NumeroPersonalCadete { get; set; }
        public int? CargaId { get; set; }
        public string? DescMes { get; set; }
        public string? DescAreaDiperadmon { get; set; }
        public string? DescTipoRacion { get; set; }
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}