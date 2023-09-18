using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comesguard
{
    public partial class IngresoDatoServicioPeluqueriaDTO
    {

        public int? IngresoDatoServicioPeluqueriaId { get; set; }
        public string? FechaServicio { get; set; }
        public string? CIP { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoEspecialidadGenericaPersonal { get; set; }
        public string? CodigoDependencia { get; set; } 

        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? DescDependencia { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
