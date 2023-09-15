using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class ConsumoMensualCombustibleNavegacionComfasDTO
    {

        public int? ConsumoMensualCombustibleNavegacionId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? MesId { get; set; }
        public int? TotalMensual { get; set; }
        public int? TotalAnual { get; set; }



        public string? DescUnidadNaval { get; set; }
        public string? DescMes { get; set; }





        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
