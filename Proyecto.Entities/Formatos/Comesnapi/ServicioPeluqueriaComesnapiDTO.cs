using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comesnapi
{
    public partial class ServicioPeluqueriaComesnapiDTO
    {

        public int? ServicioPeluqueriaComesnapiId { get; set; }
        public string? Fecha { get; set; }
        public string? CIPPersonal { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoEspecialidadGenericaPersonal { get; set; }
        public string? CodigoDependencia { get; set; } 
        public int? CargaId { get; set; } 

        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? NombreDependencia { get; set; } 
 
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
