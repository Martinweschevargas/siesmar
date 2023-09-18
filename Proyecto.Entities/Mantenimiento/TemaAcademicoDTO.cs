using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TemaAcademicoDTO
    {
        public int TemaAcademicoId { get; set; }
        public string? DescTemaAcademico { get; set; }
        public string? CodigoTemaAcademico { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
