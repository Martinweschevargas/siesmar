using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diperadmon
{
    public partial class PersonalMilitarRetiroBajaDTO
    {
        public int PersonalMilitarRetiroBajaId { get; set; }
        public string? DNIPMilitarRetBaja { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? SexoPMilitarRetBaja { get; set; }
        public string? CodigoEspecialidadGenericaPersonal { get; set; }
        public string? CodigoMotivoBajaPersonal { get; set; }
        public string? FechaIngresoInsPMilitarRetBaja { get; set; }
        public string? FechaRetiroPMilitarRetBaja { get; set; }
        public int? CargaId { get; set; }
        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? DescMotivoBajaPersonal { get; set; }
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
