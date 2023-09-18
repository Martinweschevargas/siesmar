using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class InstitucionEducativaSuperiorDTO
    {
        public int InstitucionEducativaSuperiorId { get; set; }
        public string? DescInstitucionEducativaSuperior { get; set; }
        public string? CodigoInstitucionEducativaSuperior { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
