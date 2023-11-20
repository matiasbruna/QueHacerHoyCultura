﻿namespace QueHacerHoyCultura.Entidades
{
    public class Provincia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public List<Localidad> Localidad { get; set; } = new List<Localidad>();
    }
}
