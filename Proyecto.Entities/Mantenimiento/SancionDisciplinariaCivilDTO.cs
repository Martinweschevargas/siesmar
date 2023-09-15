using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SancionDisciplinariaCivilDTO
    {
        public int SancionDisciplinariaCivilId { get; set; }
        public string? DescSancionDisciplinariaCivil { get; set; }
        public string? CodigoSancionDisciplinariaCivil { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
