using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Laboratorio Programa 1
/// Este programa calcula el número de archivos y el número de líneas en blanco y con información dentro de estos
/// Autor: Carlos Serret Heredia        Matrícula: A01281072
/// </summary>

namespace Programa1
{
    class Program
    {
        static void Main(string[] args)
        {
            string archivos = "";
            Console.WriteLine("Introduzca los nombres de los archivos en una sola linea, separados por un espacio.");
            //se leen los archivos a procesar 
            archivos = Console.ReadLine();
            Controller controlador = new Controller();
            //se calcula la información de cada archivo
            Archivo [] sArrArchivos = controlador.CalcularInformacion(archivos);
            //se ordenan los archivos del arreglo según la cantidad de líneas con información
            controlador.SortArchivos(sArrArchivos);
            //Se imprimen los números finales de cada archivo en el orden adecuado
            controlador.ImprimirTotales(sArrArchivos);
            Console.ReadLine();
        }
    }
}
