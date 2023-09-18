using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AlistamientoMaterialRequerido2NDTO
    {
        public int AlistamientoMaterialRequerido2NId { get; set; }
        public string? Subclasificacion { get; set; }
        public decimal? Ponderado2Nivel { get; set; }
        public string? Equipo { get; set; }
        public string? CodigoAlistamientoMaterialRequerido2N { get; set; }

        public string? CodigoAlistamientoMaterialRequerido1N { get; set; }
        public string? CapacidadIntrinseca { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
