using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Disamar
{
    public partial class RegistroAtencionCentroQuirurgicoDTO
    {

        public int? RegistroAtencionCentroQuirurgicoId { get; set; }
        public string? CodigoEntidadMilitar { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoEstablecimientoSaludMGP { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? SalaOperacion { get; set; }
        public string? NombreMedicoIntervencion { get; set; }
        public int? NSACIPMedicoIntervencion { get; set; }
        public int? CMPMedicoIntervencion { get; set; }
        public string? EspecialidadMedico { get; set; }
        public int? NumeroIntervencion { get; set; }
        public int? HistoriaClinica { get; set; }
        public string? DNIPaciente { get; set; }
        public string? CodigoUnidadDependencia { get; set; }
        public string? DistritoPaciente { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? SituacionPaciente { get; set; }
        public string? CondicionPaciente { get; set; }
        public int? EdadPaciente { get; set; }
        public string? TipoEdad { get; set; }
        public string? SexoPaciente { get; set; }
        public string? CodigoOrigenPacienteIntervenido { get; set; }
        public string? DiagnosticoMotivoAtencion1 { get; set; }
        public string? TipoDX1 { get; set; }
        public string? CIE10_1 { get; set; }
        public string? DiagnosticoMotivoAtencion2 { get; set; }
        public string? TipoDX2 { get; set; }
        public string? CIE10_2 { get; set; }
        public string? DiagnosticoMotivoAtencion3 { get; set; }
        public string? TipoDX3 { get; set; }
        public string? CIE10_3 { get; set; }
        public string? IntervencionQuirurgicaEfectuada { get; set; }
        public string? CodigoIntervencionEfectuada { get; set; }
        public string? IntervencionQuirurgicaAdicional { get; set; }
        public string? CodigoIntervencionAdicional { get; set; }
        public string? FechaHoraInicio { get; set; }
        public string? FechaHoraFin { get; set; }
        public string? TipoIntervencion { get; set; }
        public string? EstadoPaciente { get; set; }
        public string? CodigoDestinoPaciente { get; set; } 


        public string? DescEntidadMilitar { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescEstablecimientoSalud { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDitrito { get; set; }
        public string? DescUnidadDependencia { get; set; }
        public string? DescDistritroPaciente { get; set; }
        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescGrado { get; set; }
        public string? DescOrigenPacienteIntervenido { get; set; }
        public string? DescDestinoPaciente { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
