using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperpac
{
    public partial class NumeroUnidadFuerzaNavalDTO
    {

        public int? NumeroUnidadFuerzaNavalId { get; set; }
        public string? CodigoComandanciaDependencia { get; set; }
        public string? CodigoUnidadBelica { get; set; }
        public string? CodigoEstadoOperativo { get; set; }
        public int? CargaId { get; set; }
        public string? DescComandanciaDependencia { get; set; }
        public string? DescUnidadBelica { get; set; }
        public string? DescEstadoOperativo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
