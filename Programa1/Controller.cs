using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Programa1
{
    class Controller
    {
        private int total = 0;
        private int totalBlancas = 0;
        private int totalConInfo = 0;
        public int Total
        {
            set { total = value; }
            get { return total; }
        }
        public int TotalBlancas
        {
            set { totalBlancas = value; }
            get { return totalBlancas; }
        }
        public int TotalConInfo
        {
            set { totalConInfo = value; }
            get { return totalConInfo; }
        }

        /// <summary>
        /// CalcularInformación
        /// Calcula la información correspondiente a cada archivo ingresado y devuelve un arreglo con todos los archivos
        /// </summary>
        /// <param name="sCadena"></param>
        /// <returns>Regresa un arreglo de tipo Archivo</returns>
        public Archivo[] CalcularInformacion(string sCadena)
        {
            StreamReader entrada = null;
            bool bAbierto;
            string[] sArrArchivos = sCadena.Split(' ');
            List<Archivo> aArrArchivos = new List<Archivo>();
            foreach (string archivo in sArrArchivos)
            {
                bAbierto = false;
                try
                {
                    entrada = File.OpenText(archivo);
                    bAbierto = true;
                    total++;
                }
                catch (Exception)
                {
                    Console.WriteLine("El archivo " + archivo + " no se pudo encontrar.");  
                }

                if (bAbierto)
                {
                    int blank = File.ReadLines(archivo).Count(line => string.IsNullOrWhiteSpace(line));
                    int totallineas = File.ReadLines(archivo).Count();
                    int info = totallineas - blank;
                    totalBlancas += blank;
                    totalConInfo += info;
                    Archivo file = new Archivo(archivo, blank, info);
                    aArrArchivos.Add(file);
                }
            }
            return aArrArchivos.ToArray();
        }

        /// <summary>
        /// SortArchivos
        /// Dado el arreglo original de objetos tipo Archivo, los ordena según el número de líneas con información
        /// </summary>
        /// <param name="aArrArchivos"></param>
        /// <returns>Regresa el arreglo de archivos ya ordenado de tipo Archivo</returns>
        public Archivo [] SortArchivos(Archivo[] aArrArchivos)
        {
            Array.Sort(aArrArchivos, delegate (Archivo x, Archivo y) { return x.InfoLineas.CompareTo(y.InfoLineas); });
            return aArrArchivos;
        }


        /// <summary>
        /// ImprimirTotales
        /// Imprime en consola la información respectiva de cada archivo en el arreglo
        /// </summary>
        /// <param name="aArrArchivos"></param>
        public void ImprimirTotales(Archivo [] aArrArchivos)
        {
            foreach (Archivo file in aArrArchivos)
            {
                Console.WriteLine(file.ToString() + "\n----------------------------------------");
            }
            Console.WriteLine("TOTALES\nCantidad total de archivos: " + total + "\nCantidad total de líneas en blanco: " + totalBlancas + "\nCantidad total de líneas con información: " + totalConInfo);
        }



    }
}
