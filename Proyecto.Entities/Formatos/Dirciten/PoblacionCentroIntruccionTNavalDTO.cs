using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirciten
{
    public partial class PoblacionCentroIntruccionTNavalDTO
    {
        public int PoblacionCentroIntruccionTNavalId { get; set; }
        public string? DNIIntruccionTNaval { get; set; }
        public string? GeneroIntruccionTNaval { get; set; }
        public string? FechaNacimientoIntruccionTNaval { get; set; }
        public string? LugarNacimiento { get; set; }
        public string? LugarDomicilio { get; set; }
        public string? FechaIngresoIntruccionTNaval { get; set; }
        public string? AnoAcademico { get; set; }
        public string? SemestreAcademico { get; set; }
        public int? IndiceRendimientoIRAS { get; set; }
        public int? NotaCaracterMilitar { get; set; }
        public int? NotaFormacionFisica { get; set; }
        public int? NotaConductaIntruccionTNaval { get; set; }
        public string? ResultadoTerminoTrimestre { get; set; }
        public string? CodigoCausalBaja { get; set; }

        public string? DescCausalBaja { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
