using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CondicionEgresoHospitalizacionDTO
    {
        public int CondicionEgresoHospitalizacionId { get; set; }
        public string? DescCondicionEgresoHospitalizacion { get; set; }
        public string? CodigoCondicionEgresoHospitalizacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
