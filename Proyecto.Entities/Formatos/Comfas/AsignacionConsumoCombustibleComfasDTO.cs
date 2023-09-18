using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class AsignacionConsumoCombustibleComfasDTO
    {

        public int? AsignacionConsumoCombustibleId { get; set; }
        public int? AnioAsignacion { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? CapacidadMaximaAlmacen { get; set; }
        public int? Asignado { get; set; }
        public int? ConsumoTotalAnualPuerto { get; set; }
        public int? ConsumoTotalAnualNavegacion { get; set; }



        public string? DescUnidadNaval { get; set; }
 




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
