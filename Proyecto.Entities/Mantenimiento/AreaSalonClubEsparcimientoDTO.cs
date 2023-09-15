using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AreaSalonClubEsparcimientoDTO
    {
        public int AreaSalonClubEsparcimientoId { get; set; }
        public string? DescAreaSalonClubEsparcimiento { get; set; }
        public string? CodigoAreaSalonClubEsparcimiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
