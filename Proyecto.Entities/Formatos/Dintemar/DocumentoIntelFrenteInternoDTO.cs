using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dintemar
{
    public partial class DocumentoIntelFrenteInternoDTO
    {
        public int DocumentoInteligenciaFrenteInternoId { get; set; }
        public int? MesId { get; set; }
        public int? AnioDocumentoFrenteInterno { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public int? NotaInformacionProducidoFI { get; set; }
        public int? NotaInteligenciaFI { get; set; }
        public int? ApreciacionInteligenciaFI { get; set; }
        public int? ResumenMensualInteligenciaFI { get; set; }
        public int? EstudioInteligenciaFI { get; set; }
        public int? BoletinInformacionFI { get; set; }
        public int? OtrosEspecificarFI { get; set; }


        public string? DescMes { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescZonaNaval { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
