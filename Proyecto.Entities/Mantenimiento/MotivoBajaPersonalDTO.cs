using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class MotivoBajaPersonalDTO
    {
        public int MotivoBajaPersonalId { get; set; }
        public string? FlagMotivoBajaPersonal { get; set; }
        public string? DescMotivoBajaPersonal { get; set; }
        public string? CodigoMotivoBajaPersonal { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
