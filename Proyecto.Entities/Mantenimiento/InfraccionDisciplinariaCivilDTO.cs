using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class InfraccionDisciplinariaCivilDTO
    {
        public int InfraccionDisciplinariaCivilId { get; set; }
        public string? DescInfraccionDisciplinariaCivil { get; set; }
        public string? CodigoInfraccionDisciplinariaCivil { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
