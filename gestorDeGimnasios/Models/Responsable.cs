﻿namespace gestorDeGimnasios.Models
{
    public class Responsable : Usuario
    {
        private int ?idResponsable;
        private string ?telefono;
        private string ?nombre;


        public int ?IdResponsable { get { return this.idResponsable; } set { this.idResponsable = value; } }
        public string ?Telefono { get { return this.telefono; } set { this.telefono = value; } }
        public string ?Nombre { get { return this.nombre; } set {this.nombre = value; } }



    }
}
