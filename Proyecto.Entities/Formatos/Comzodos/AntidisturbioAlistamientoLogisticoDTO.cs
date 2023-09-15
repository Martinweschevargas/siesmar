using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzodos
{
    public partial class AntidisturbioAlistamientoLogisticoDTO
    {

        public int? AntidisturbioAlistamientoLogisticoId { get; set; }
        public string? CodigoDescripcionMaterial { get; set; }
        public int? MaterialRequerido { get; set; }
        public int? MaterialAsignado { get; set; }
        public string? CodigoCondicionAlistamientoLogistico { get; set; }
        public string? ObservacionAlistamientoLogistico { get; set; }


        public string? Clasificacion { get; set; }
        public string? DescCondicionAlistamientoLogistico { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}