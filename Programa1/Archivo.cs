using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa1
{
    class Archivo
    {
        private string nombre;
        private int blancoLineas;
        private int infoLineas;

        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
        public int BlancoLineas
        {
            set { blancoLineas = value; }
            get { return blancoLineas; }
        }
        public int InfoLineas
        {
            set { infoLineas = value; }
            get { return infoLineas; }
        }

        public Archivo()
        {
            nombre = "";
            infoLineas = 0;
            blancoLineas = 0;
        }

        public Archivo(string nombre, int blancoLineas, int infoLineas)
        {
            this.nombre = nombre;
            this.blancoLineas = blancoLineas;
            this.infoLineas = infoLineas;
        }

        /// <summary>
        /// Devuelve la información del archivo 
        /// </summary>
        /// <returns>Un string que contiene la información del archivo en cuestión</returns>
        override public string ToString()
        {
            return "Nombre del archivo: " + nombre + "\nCantidad de líneas en blanco: " + blancoLineas + "\nCantidad de líneas con información: " + infoLineas;
        }



    }
}
