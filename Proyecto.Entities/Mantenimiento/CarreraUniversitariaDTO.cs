using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CarreraUniversitariaDTO
    {
        public int CarreraUniversitariaId { get; set; }
        public string? DescCarreraUniversitaria { get; set; }
        public string? CodigoCarreraUniversitaria { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
