using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CondicionLaboralCivilDTO
    {
        public int CondicionLaboralCivilId { get; set; }
        public string? DescCondicionLaboralCivil { get; set; }
        public string? CodigoCondicionLaboralCivil { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
