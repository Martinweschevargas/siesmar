using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirciten
{
    public partial class PostulanteCitenDTO
    {
        public int PostulanteCitenId { get; set; }
        public string? DNIPostulanteCiten { get; set; }
        public string? GeneroPostulanteCiten { get; set; }
        public string? FechaNacimientoPostulanteCiten { get; set; }
        public string? LugarNacimiento { get; set; }
        public string? ProcedenciaPostulanteCiten { get; set; }
        public string? TipoColegioProveniente { get; set; }
        public string? ColegioProcedencia { get; set; }
        public string? LugarColegio { get; set; }
        public string? PadresEntidadMilitar { get; set; }
        public string? ModalidadIngreso { get; set; }
        public string? TipoPreparacion { get; set; }
        public string? LugarPostulacion { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? SituacionIngreso { get; set; }

        public string? DescZonaNaval { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
