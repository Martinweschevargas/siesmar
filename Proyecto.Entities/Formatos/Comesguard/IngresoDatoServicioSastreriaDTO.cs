using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comesguard
{
    public partial class IngresoDatoServicioSastreriaDTO
    {

        public int? IngresoDatoServicioSastreriaId { get; set; }
        public string? FechaIngreso { get; set; }
        public string? FechaRecojo { get; set; }
        public string? CIP { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? CodigoEspecialidadGenericaPersonal { get; set; }
        public string? Sexo { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoTipoServicioSastreria { get; set; }
        public int? CantidadPrendas { get; set; } 

        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescServicioSastreria { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
