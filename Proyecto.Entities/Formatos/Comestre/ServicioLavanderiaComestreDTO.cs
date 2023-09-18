using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comestre
{
    public partial class ServicioLavanderiaComestreDTO
    {

        public int? ServicioLavanderiaComestreId { get; set; }
        public string? FechaIngreso { get; set; }
        public string? FechaRecojo { get; set; }
        public int? CIP { get; set; }
        public int? GradoPersonalMilitarId { get; set; }
        public int? EspecialidadGenericaPersonalId { get; set; }
        public string? SexoPersonal { get; set; }
        public int? DependenciaId { get; set; }
        public int? NumeroPrenda { get; set; }
        public int? ServicioLavanderiaId { get; set; }


        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? DescDependencia{ get; set; }
        public string? DescServicioLavanderia { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
    }
}