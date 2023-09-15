using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Disamar
{
    public partial class RegistroEgresoHospitalarioDTO
    {

        public int? RegistroEgresoHospitalarioId { get; set; }
        public string? CodigoEntidadMilitar { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoEstablecimientoSaludMGP { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? CodigoUPS { get; set; }
        public string? ResponsableRegistro { get; set; }
        public int? NSACIP { get; set; }
        public string? DNIResponsableSalud { get; set; }
        public int? HistoriaClinica { get; set; }
        public string? DNIPaciente { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? DistritoPaciente { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? SituacionPaciente { get; set; }
        public string? CondicionPaciente { get; set; }
        public string? OrigenPaciente { get; set; }
        public int? EdadPaciente { get; set; }
        public string? TipoEdad { get; set; }
        public string? SexoPaciente { get; set; }
        public string? DiagnosticoMotivoAtencion1 { get; set; }
        public string? TipoDX1 { get; set; }
        public string? CIE10_1 { get; set; }
        public string? DiagnosticoMotivoAtencion2 { get; set; }
        public string? TipoDX2 { get; set; }

        public string? CIE10_2 { get; set; }
        public string? DiagnosticoMotivoAtencion3 { get; set; }
        public string? TipoDX3 { get; set; }
        public string? CIE10_3 { get; set; }
        public string? DiagnosticoMotivoAtencion4 { get; set; }
        public string? TipoDX4 { get; set; }
        public string? CIE10_4 { get; set; }
        public string? DiagnosticoMotivoAtencion5 { get; set; }
        public string? TipoDX5 { get; set; }
        public string? CIE10_5 { get; set; }
        public string? DiagnosticoMotivoAtencion6 { get; set; }
        public string? TipoDX6 { get; set; }
        public string? CIE10_6 { get; set; }
        public string? CodigoCondicionEgresoHospitalizacion { get; set; }
        public string? FechaIngreso { get; set; }
        public string? HoraIngreso { get; set; }
        public string? FechaEgreso { get; set; }
        public string? HoraEgreso { get; set; }
        public string? EspecialidadMedicoTratanteIngreso { get; set; }
        public string? NombreMedicoIngreso { get; set; }
        public string? DiagnosticoIngreso { get; set; }
        public string? EspecialidadMedicoTratanteEgreso { get; set; }
        public string? NombreMedicoEgreso { get; set; }



        public string? DescEntidadMilitar { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescEstablecimientoSalud { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDitrito { get; set; }
        public string? DescEspecialidadMedicaNoMedica { get; set; }
        public string? DescUnidadDependencia { get; set; }
        public string? DescDistritroPaciente { get; set; }
        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescGrado { get; set; }
        public string? DescCondicionEgresoHospitalizacion { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
