using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AlistamientoMaterialRequerido3NDTO
    {
        public int AlistamientoMaterialRequerido3NId { get; set; }
        public string? Subclasificacionn { get; set; }
        public decimal? Ponderado3Nivel { get; set; }
        public string? CodigoAlistamientoMaterialRequerido3N { get; set; }
        public string? CodigoAlistamientoMaterialRequerido2N { get; set; }
        public string? Subclasificacion { get; set; }



        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
