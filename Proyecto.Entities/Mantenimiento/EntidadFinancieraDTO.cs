using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EntidadFinancieraDTO
    {
        public int EntidadFinancieraId { get; set; }
        public string? DescEntidadFinanciera { get; set; }
        public string? CodigoEntidadFinanciera { get; set; }
        public int EntidadFinancieraGrupoId { get; set; }
        public string? DescEntidadFinancieraGrupo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
