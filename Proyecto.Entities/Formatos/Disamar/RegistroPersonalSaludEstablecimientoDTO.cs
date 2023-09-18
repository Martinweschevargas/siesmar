using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Disamar
{
    public partial class RegistroPersonalSaludEstablecimientoDTO
    {

        public int? RegistroPersonalSaludEstablecimientoId { get; set; }
        public string? ApellidosNombresPersonalMedico { get; set; }
        public string? CIPPersonalMedico { get; set; }
        public string? DNIPersonalMedico { get; set; }
        public string? TipoPersonal { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? NombreColegioProfesional { get; set; }
        public string? NumeroColegiatura { get; set; }
        public string? Especialidad { get; set; }
        public string? CodigoEstablecimientoSaludMGP { get; set; }
        public string? CodigoCondicionLaboral { get; set; }
        public string? TipoLaborRealizar { get; set; }
        public int? CargaId { get; set; }


        public string? DescGrado { get; set; }
        public string? DescEstablecimientoSalud { get; set; }
        public string? DescCondicionLaboral { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
