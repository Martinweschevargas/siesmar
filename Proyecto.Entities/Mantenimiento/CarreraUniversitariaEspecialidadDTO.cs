using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CarreraUniversitariaEspecialidadDTO
    {
        public int CarreraUniversitariaEspecialidadId { get; set; }
        public string? DescCarreraUniversitariaEspecialidad { get; set; }
        public string? CodigoCarreraUniversitariaEspecialidad { get; set; }
        public string? CodigoCarreraUniversitaria { get; set; }
        public string? DescCarreraUniversitaria { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
