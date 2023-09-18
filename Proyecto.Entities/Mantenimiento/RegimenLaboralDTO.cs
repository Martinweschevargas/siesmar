using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class RegimenLaboralDTO
    {
        public int RegimenLaboralId { get; set; }
        public string? DescRegimenLaboral { get; set; }
        public string? CodigoRegimenLaboral { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
