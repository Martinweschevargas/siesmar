
﻿using System.ComponentModel.DataAnnotations.Schema;



namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class NivelDependenciaDTO
    {
        public int NivelDependenciaId { get; set; }
        public string? CodigoNivelDependencia { get; set; }
        public string? DescNivelDependencia { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
