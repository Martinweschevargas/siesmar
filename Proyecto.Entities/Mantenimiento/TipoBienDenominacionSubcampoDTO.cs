using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class TipoBienDenominacionSubcampoDTO
    {
        public int TipoBienDenominacionSubcampoId { get; set; }
        public string? DescTipoBienDenominacionSubcampo { get; set; }
        public string? CodigoTipoBienDenominacionSubcampo { get; set; }
        public int TipoBienSubcampoId { get; set; }
        public string? DescTipoBienSubcampo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
