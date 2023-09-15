using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diresgrum
{
    public partial class PostulanteEscuelaGrumetesDTO
    {

        public int? PostulanteEscuelaGrumeteId { get; set; }
        public int? DNIPostulanteEscuela { get; set; }
        public string? SexoPostulanteEscuela { get; set; }
        public int? LugarNacimiento { get; set; }
        public string? FechaNacimiento { get; set; }
        public int? LugarDomicilio { get; set; }
        public int? LugarPresentacionPostulante { get; set; }
        public int? ZonaNavalId { get; set; }
        public int? GradoEstudioAlcanzadoId { get; set; }
        public int? GradoEstudioEspecifId { get; set; }
        public int? NumeroContingenciaPostulante { get; set; }
        public string? ResultadoPostulacion { get; set; }


        public string? DescZonaNaval { get; set; }
        public string? DescEstudioAlcanzado { get; set; }
        public string? DescGradoEstudioEspecif { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
