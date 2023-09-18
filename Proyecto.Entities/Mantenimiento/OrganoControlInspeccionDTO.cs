using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class OrganoControlInspeccionDTO
    {
        public int OrganoControlInspeccionId { get; set; }
        public string? DescOrganoControlInspeccion { get; set; }
  	    public string? CodigoOrganoControlInspeccion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
