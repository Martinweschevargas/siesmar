using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EjercicioEntrenamientoComfoeDTO
    {
        public int EjercicioEntrenamientoComfoeId { get; set; }
        public string? CodigoEjercicioEntrenamientoComfoe { get; set; }
        public string? DescripcionEjercicioEntrenamiento { get; set; }
        public string? CodigoTipoCompetenciaTecnica { get; set; }
        public string? Nivel { get; set; }
        public int? VigenciaDia { get; set; }
        public string? DescTipoCompetenciaTecnica { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
