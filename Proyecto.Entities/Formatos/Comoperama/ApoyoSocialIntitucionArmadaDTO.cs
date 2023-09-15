using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperama
{
    public partial class ApoyoSocialIntitucionArmadaDTO
    {

        public int? ApoyoSocialIntitucionArmadaId { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? CodigoTipoActividadDenominacion { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public int? NumeroBeneficiados { get; set; }
        public string? CodigoTipoAccionCivica { get; set; }
        public int? CargaId { get; set; }

        public string? DescZonaNaval { get; set; }
        public string? DescTipoActividadDenominacion { get; set; }
        public string? DescTipoAccionCivica { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDepartamento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
