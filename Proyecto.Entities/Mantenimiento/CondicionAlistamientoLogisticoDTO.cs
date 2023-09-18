using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CondicionAlistamientoLogisticoDTO
    {
        public int CondicionAlistamientoLogisticoId { get; set; }
        public string? DescCondicionAlistamientoLogistico { get; set; }
        public string? CodigoCondicionAlistamientoLogistico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
