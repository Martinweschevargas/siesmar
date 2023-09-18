using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class InfraccionDisciplinariaGenericaDTO
    {
        public int InfraccionDisciplinariaGenericaId { get; set; }
        public string? DescInfraccionDisciplinariaGenerica { get; set; }
        public string? CodigoInfraccionDisciplinariaGenerica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
