using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class FormacionAcademicaDTO
    {
        public int FormacionAcademicaId { get; set; }
        public string? DescFormacionAcademica { get; set; }
        public string? CodigoFormacionAcademica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
