using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GrupoOcupacionalCivilDTO
    {
        public int GrupoOcupacionalCivilId { get; set; }
        public string? DescGrupoOcupacionalCivil { get; set; }
        public string? CodigoGrupoOcupacionalCivil { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
