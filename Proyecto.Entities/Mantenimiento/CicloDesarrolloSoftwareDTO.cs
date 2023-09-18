using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CicloDesarrolloSoftwareDTO
    {
        public int CicloDesarrolloSoftwareId { get; set; }
        public string? DescCicloDesarrolloSoftware { get; set; }
        public string? CodigoCicloDesarrolloSoftware { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
