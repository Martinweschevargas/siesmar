using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirintemar;

public partial class ActividadCulturalDTO
{
        public int ActividadCulturalId { get; set; }
        public string? NombreActividadCultural { get; set; }
        public int? TipoActividadCulturalId { get; set; }
        public string? FechaInicioActCultural { get; set; }
        public string? FechaTerminoActCultural { get; set; }
        public string? LugarActCultural { get; set; }
        public string? AuspiciadoresActCultural { get; set; }
        public int? NParticipantesActCultural { get; set; }
        public decimal? InversionActCultural { get; set; }
        public string? DescTipoActividadCultural { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
}
