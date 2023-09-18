using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Disamar
{
    public partial class RegistroAtencionConsultaExternaDTO
    {

        public int? RegistroAtencionConsultaExternaId { get; set; }
        public string? CodigoEntidadMilitar { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoEstablecimientoSaludMGP { get; set; }
        public string? FechaRegistro { get; set; }

        public string? DistritoUbigeo { get; set; }
        public string? CodigoUPSMedicaNoMedica { get; set; }
        public string? ResponsableAtencionMedica { get; set; }
        public int? NSACIP { get; set; }
        public int? NumeroCMP { get; set; }
        public string? Turno { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraTermino { get; set; }
        public int? HistoriaClinica { get; set; }
        public string? DNIPaciente { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? DistritoPaciente { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? SituacionPaciente { get; set; }
        public string? CondicionPaciente { get; set; }
        public int? EdadPaciente { get; set; }
        public string? TipoEdad { get; set; }
        public string? SexoPaciente { get; set; }
        public string? AlEstablecimiento { get; set; }
        public string? AlServicio { get; set; }
        public string? CodigoDiagnosticoMotivoAtencion1 { get; set; }
        public string? TipoDX1 { get; set; }
        public string? Lab1 { get; set; }
        public string? CodigoCIE10_1 { get; set; }
        public string? CodigoDiagnosticoMotivoAtencion2 { get; set; }
        public string? TipoDX2 { get; set; }
        public string? Lab2 { get; set; }
        public string? CodigoCIE10_2 { get; set; }
        public string? CodigoDiagnosticoMotivoAtencion3 { get; set; }
        public string? TipoDX3 { get; set; }
        public string? Lab3 { get; set; }
        public string? CodigoCIE10_3 { get; set; }
        public string? CodigoDiagnosticoMotivoAtencion4 { get; set; }
        public string? TipoDX4 { get; set; }
        public string? Lab4 { get; set; }
        public string? CodigoCIE10_4 { get; set; }
        public string? CodigoDiagnosticoMotivoAtencion5 { get; set; }
        public string? TipoDX5 { get; set; }
        public string? Lab5 { get; set; }
        public string? CodigoCIE10_5 { get; set; }
        public string? CodigoDiagnosticoMotivoAtencion6 { get; set; }
        public string? TipoDX6 { get; set; }
        public string? Lab6 { get; set; }
        public string? CodigoCIE10_6 { get; set; }
        public string? Interconsulta { get; set; }
        public string? CodigoUPSEspecialidadInterconsulta { get; set; }
        public int? CargaId { get; set; }


        public string? DescEntidadMilitar { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescEstablecimientoSalud { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDitrito { get; set; }
        public string? DescEspecialidadMedicaNoMedica { get; set; }
        public string? DescUnidadDependencia { get; set; }
        public string? DescDitritoPaciente { get; set; }
        public string? DescDistritroPaciente { get; set; }
        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescGrado { get; set; }



        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }

    }
}
