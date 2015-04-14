using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FBF_Project
{
    /// <summary>
    /// Clase encargada de leer y almacenar los caracteres del archivo de entrada
    /// </summary>
    class INFILE
    {
  
        /// <summary>
        /// Carga el archivo de entrada y lo almacena en una lista de strings
        /// </summary>
        /// <param name="Name"> Nombre del archivo</param>
        /// <returns>Una lista de strings de las proposiciones</returns>
        public List<string> LoadFile(string Name)
        {
            List<string> listPreposition = new List<string>();
           
            ///Obtiene la direccion del escritorio del usurio que este ejecutando el programa
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            filePath += "\\" + Name + ".txt";

            ///Toma cada line del archivo y lo guarda en un arreglo.
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    String line = sr.ReadToEnd();
                    listPreposition.Add(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("El archivo no puede ser leido o nombre incorrecto");
                Console.WriteLine(e.Message);
            }

            return listPreposition;
        }

    }
}
