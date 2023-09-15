using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class UbicacionCIRDDTO
    {
        public int UbicacionCIRDId { get; set; }
        public string? DescUbicacionCIRD { get; set; }
        public string? CodigoUbicacionCIRD { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
