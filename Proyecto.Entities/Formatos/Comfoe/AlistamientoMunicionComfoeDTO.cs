﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfoe
{
    public partial class AlistamientoMunicionComfoeDTO
    {

        public int AlistamientoMunicionComfoeId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoMunicion { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? DescSistemaMunicion { get; set; }
        public string? DescSubsistemaMunicion { get; set; }
        public string? Equipo { get; set; }
        public string? Municion { get; set; }
        public string? Existente { get; set; }
        public int? Necesaria { get; set; }
        public int? CoeficientePonderacion { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
