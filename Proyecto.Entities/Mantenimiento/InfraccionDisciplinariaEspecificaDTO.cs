using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class InfraccionDisciplinariaEspecificaDTO
    {
        public int InfraccionDisciplinariaEspecificaId { get; set; }
        public string? DescInfraccionDisciplinariaEspecifica { get; set; }
        public string? CodigoInfraccionDisciplinariaEspecifica { get; set; }
        public int InfraccionDisciplinariaGenericaId { get; set; }
        public string? DescInfraccionDisciplinariaGenerica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
