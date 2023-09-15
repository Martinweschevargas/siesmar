using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirciten
{
    public partial class EstudiantesPreCitenDTO
    {
        public int EstudiantePreCitenId { get; set; }
        public string? DNIEstudiantePreCiten { get; set; }
        public string? GeneroEstudiantePreCiten { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? LugarDomicilio { get; set; }
        public string? TipoColegioProcedencia { get; set; }
        public string? ColegioProcedencia { get; set; }
        public string? LugarColegio { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
