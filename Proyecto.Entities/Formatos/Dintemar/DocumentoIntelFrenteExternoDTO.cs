using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dintemar
{
    public partial class DocumentoIntelFrenteExternoDTO
    {
        public int DocumentoInteligenciaFrenteExternoId { get; set; }
        public int? MesId { get; set; }
        public int? AnioDocumentoFrenteExterno { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? NumericoPais { get; set; }
        public int? NotaInformacionProducidasFE { get; set; }
        public int? NotaInteligenciaFE { get; set; }
        public int? ApreciacionInteligenciaFE { get; set; }
        public int? ResumenMensualInteligenciaFE { get; set; }
        public int? EstudioInteligenciaFE { get; set; }
        public int? BoletinInformacionFE { get; set; }
        public int? OtrosEspecificarFE { get; set; }


        public string? DescMes { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? NombrePais { get; set; }
        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
