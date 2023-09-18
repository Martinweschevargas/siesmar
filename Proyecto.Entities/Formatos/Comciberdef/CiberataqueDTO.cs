using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comciberdef
{
    public partial class CiberataqueDTO
    {

        public int? CiberataqueId { get; set; }
        public int? IdentificadorCiberataque { get; set; }
        public string? CodigoAccionAnteCiberataque { get; set; }
        public string? FechaCiberataques { get; set; }
        public string? CodigoTipoCiberataque { get; set; }
        public string? CodigoSeveridadCiberataque { get; set; }

        public string? DescAccionAnteCiberataque { get; set; }
        public string? DescTipoCiberataque { get; set; }
        public string? DescSeveridadCiberataque { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaFin { get; set; }
        public string? CantidadCiberataques { get; set; }
        public string? PorcentajeCiberataque { get; set; }

    }
}
