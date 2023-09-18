using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comesnapi
{
    public partial class ServicioSastreriaComesnapiDTO
    {

        public int? ServicioSastreriaComesnapiId { get; set; }
        public string? FechaIngreso { get; set; }
        public string? FechaRecojo { get; set; }
        public string? CIP { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoEspecialidadGenericaPersonal    { get; set; }
        public string? SexoPersonal { get; set; }
        public string? CodigoDependencia { get; set; }
        public int? NumeroPrenda { get; set; }
        public string? CodigoTipoPrenda { get; set; }
        public string? CodigoTipoServicioSastreria { get; set; } 
        public int? CargaId { get; set; } 

        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescTipoPrenda { get; set; }
        public string? DescServicioSastreria { get; set; } 
 
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
