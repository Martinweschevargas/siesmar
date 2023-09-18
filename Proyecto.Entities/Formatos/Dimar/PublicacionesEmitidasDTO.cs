using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class PublicacionesEmitidasDTO
    {
        public int PublicacionEmitidaId { get; set; }
        public string? CodProducto { get; set; }
        public string? MesPublicacion { get; set; }
        public string? CodDependencia { get; set; }
        public string? CodTipoInformacion { get; set; }
        public string? SexoSegEspecialidad { get; set; }
        public int? DependenciaId { get; set; }
        public string? TipoPersonalCapaPerfDeber { get; set; }
        public int GradoPersonalMilitarId { get; set; }
        public int? EspecialidadGenericaPersonalId { get; set; }
        public string? TipoProgramaCapSegEspecialidad { get; set; }
        public int? PaisUIbigeoId { get; set; }
        public int? EntidadMilitarId { get; set; }
        public int? CodigoEscuelaId { get; set; }
        public string? MencionCursoSegEspecialidad { get; set; }
        public string? FinanciamientoSegEspecialidad { get; set; }
        public string? FechaInicioSegEspecialidad { get; set; }
        public string? FechaTerminoSegEspecialidad { get; set; }
        public string? FechaRegistroSegEspecialidad { get; set; }
        public int? HorasCapacitacionSegEspecialidad { get; set; }
        public int? CalificacionSegEspecialidad { get; set; }
        public int? MotivoTerminoCursoId { get; set; }


        public string? DescDependencia { get; set; }
        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? Pais { get; set; }
        public string? DescEntidadMilitar { get; set; }
        public string? DescCodigoEscuela { get; set; }
        public string? DescMotivoTerminoCurso { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
