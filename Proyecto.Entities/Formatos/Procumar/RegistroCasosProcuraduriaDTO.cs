using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Procumar
{
    public partial class RegistroCasosProcuraduriaDTO
    {
        public int RegistroCasosProcuraduriaId { get; set; }
        public int? AnioDemanda { get; set; }
        public string? MesDemanda { get; set; }
        public string? CodigoAreaProcumar { get; set; }
        public string? NombreAbogado { get; set; }
        public string? NroExpediente { get; set; }
        public string? NroCodInterno { get; set; }
        public string? NombreDemandante { get; set; }
        public string? NombreDemandado { get; set; }
        public string? CodigoGradoPersonal { get; set; }
        public string? CodigoEspecialidadPersonal { get; set; }
        public string? CodigoMateriaProcumar { get; set; }
        public string? Petitorio { get; set; }
        public string? CodigoDistritoJudicial { get; set; }
        public string? CodigoInstanciaJudicial { get; set; }
        public string? CodigoCasoExcepcional { get; set; }
        public string? UltimoActuado { get; set; }
        public string? CodigoEstadoProceso { get; set; }
        public string? SentenciaEjecutoria { get; set; }
        public int? AnioTerminoProceso { get; set; }
        public string? MonedaId { get; set; }
        public decimal MontoPretencion { get; set; }
        public string? DescGradoPersonal { get; set; }
        public string? DescEspecialidadPersonal { get; set; }
        public string? DescMateriaProcumar { get; set; }
        public string? DescDistritoJudicial { get; set; }
        public string? DescInstanciaJudicial { get; set; }
        public string? DescCasoExcepcional { get; set; }
        public string? DescEstadoProceso { get; set; }
        public string? DescMoneda { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
