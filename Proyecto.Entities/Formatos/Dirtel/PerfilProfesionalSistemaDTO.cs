using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class PerfilProfesionalSistemaDTO
    {

        public int? PerfilProfesionalSistemaId { get; set; }
        public string? DNIProfesionaleSistema { get; set; }
        public string? TipoPersonalProfesional { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? NivelEspecializacionSistema { get; set; }
        public string? CodigoPerfilProfesional { get; set; }
        public int? AnioExperienciaSistema { get; set; }
        public int? TiempoServicioInstitucion { get; set; }


        public string? DescGrado { get; set; }
        public string? DescPerfilProfesional { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}