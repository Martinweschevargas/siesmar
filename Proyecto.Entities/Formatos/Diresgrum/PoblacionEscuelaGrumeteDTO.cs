using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diresgrum
{
    public partial class PoblacionEscuelaGrumeteDTO
    {

        public int? PoblacionEscuelaGrumeteId { get; set; }
        public int? DNIGrumete { get; set; }
        public string? SexoGrumete { get; set; }
        public int? LugarNacimiento { get; set; }
        public string? FechaNacimiento { get; set; }
        public int? LugarDomicilio { get; set; }
        public int? LugarFormacionServicioMilitarId { get; set; }
        public int? ZonaNavalId { get; set; }
        public string? FechaPresentacionGrumete { get; set; }
        public int? NumeroContingenciaGrumete { get; set; }
        public int? GradoEstudioAlcanzadoId { get; set; }
        public int? GradoEstudioEspecifId { get; set; }
        public int? EspecialidadGrumeteId { get; set; }
        public int? CertificacionCETPROId { get; set; }
        public decimal? CalificacionCETPRO { get; set; }
        public decimal? PromedioFormacionFisdepaica1ra { get; set; }
        public decimal? PromedioRendimientoAcademico1ra { get; set; }
        public decimal? PromedioConducta1ra { get; set; }
        public decimal? PromedioCaracterMilitar1ra { get; set; }
        public decimal? PromedioFormacionFisica2da { get; set; }
        public decimal? PromedioRendimientoFinal2da { get; set; }
        public decimal? PromedioConducta2da { get; set; }
        public decimal? PromedioCaracterMilitar2da { get; set; }
        public string? ResultadoTerminoEjercicio { get; set; }


        public string? DescLugarFormacionServicioMilitar { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescEstudioAlcanzado { get; set; }
        public string? DescGradoEstudioEspecif { get; set; }
        public string? DescEspecialidadGrumete { get; set; }
        public string? DescCertificacionCETPRO { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
