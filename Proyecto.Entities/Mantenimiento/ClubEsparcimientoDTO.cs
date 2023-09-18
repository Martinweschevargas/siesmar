using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClubEsparcimientoDTO
    {
        public int ClubEsparcimientoId { get; set; }
        public string? DescClubEsparcimiento { get; set; }
        public string? CodigoClubEsparcimiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
