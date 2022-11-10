﻿namespace ProyectoFinal.Models {
    public class Publicacion {

        public int Id { get; set; }
        public string Titulo { get; set; } = String.Empty;
        public string SubTitulo { get; set; } = String.Empty;
        public string Creador { get; set; } = String.Empty;
        public string Cuerpo { get; set; } = String.Empty;
        public DateTime Creacion { get; set; } = DateTime.Now;
        public string Imagen { get; set; } = String.Empty;

    }
}
