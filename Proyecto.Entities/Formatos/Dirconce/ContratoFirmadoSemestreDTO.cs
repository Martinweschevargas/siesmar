using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirconce
{
    public partial class ContratoFirmadoSemestreDTO
    {

        public int? ContratoFirmadoSemestreId { get; set; }
        public int? NumeroContratoFirmado { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
