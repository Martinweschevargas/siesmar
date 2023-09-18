using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class InstitucionEducativaDTO
    {
        public int InstitucionEducativaId { get; set; }
        public string? DescInstitucionEducativa { get; set; }
        public string? CodigoInstitucionEducativa { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
