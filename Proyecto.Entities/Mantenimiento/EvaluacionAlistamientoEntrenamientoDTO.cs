using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EvaluacionAlistamientoEntrenamientoDTO
    {
        public int EvaluacionAlistamientoEntrenamientoId { get; set; }
        public string? NivelEntrenamiento { get; set; }
        public int CodigoCapacidadOperativa { get; set; }
        public string? TipoCapacidadOperativa { get; set; }
        public string? CodigoEjercicio { get; set; }
        public string? Calificativo { get; set; }
        public string? FechaPeriodoEvaluacionEjercicio { get; set; }
        public string? FechaRealizacionEjercicio { get; set; }
        public string? TiempoVigencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
