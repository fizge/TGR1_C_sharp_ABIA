// Guillermo Blanco Nuñez y Fiz Garrido Escudero GRUPO JUEVES
using System.Globalization;

namespace TGR1_Ej1
{
    /// <summary>
    /// Clase que contiene funciones auxiliares para gestionar notas.
    /// </summary>
    public class Funciones
    {
        /// <summary>
        /// Carga los datos de un fichero .csv en un diccionario de notas.
        /// </summary>
        /// <param name="ruta">Ruta del fichero .csv.</param>
        /// <param name="notas">Diccionario donde se almacenarán las notas.</param>
        public static void CargarDatos(ref string ruta, Dictionary<string, float> notas)
        {
            Console.WriteLine("\nCargando los datos de un fichero .csv ...");
            Console.WriteLine("Introduce la ruta absoluta del fichero:");
            ruta = Console.ReadLine();

            if (!File.Exists(ruta))
            {
                Console.WriteLine("Error: El archivo no se encuentra en la ruta especificada (prueba con dobles barras ).");
                ruta = null;
                return;
            }

            if (!ruta.EndsWith(".csv"))
            {
                Console.WriteLine("Error: El archivo debe tener una extensión .csv.");
                ruta = null;
                return;
            }

            try
            {
                string[] lineas = File.ReadAllLines(ruta);

                if (lineas.Length == 0)
                {
                    Console.WriteLine("Error: El archivo está vacío.");
                    return;
                }

                foreach (string linea in lineas)
                {
                    if (linea.Length == 0)
                    {

                    }
                    else
                    {
                        string[] valores = linea.Split(';');
                        if (valores.Length != 2)
                        {
                            Console.WriteLine("\n\nERROR: La estructura del archivo no es válida.");
                            notas.Clear();
                            return;
                        }

                        string nombre = valores[0];
                        string notaValida = valores[1];
                
                        if (notaValida.Contains(","))
                        {
                            notaValida = notaValida.Replace(",", ".");
                        }
                
                        if (float.TryParse(notaValida, CultureInfo.InvariantCulture, out float notaFloat))
                        {
                            notas[nombre] = notaFloat;
                            Console.WriteLine("Nombre: " + nombre + "  |   Nota: " + notaFloat);
                        }
                        else
                        {
                            Console.WriteLine("Error: Existen nota/s no válida/s en el archivo.");
                            notas.Clear();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: No se pudo leer el archivo. " + ex.Message);
            }
        }

        /// <summary>
        /// Calcula y muestra la nota media.
        /// </summary>
        /// <param name="notas">Diccionario de notas.</param>
        public static void NotaMedia(Dictionary<string, float> notas)
        {
            if (notas.Count == 0)
            {
                Console.WriteLine("Error: No hay notas disponibles.");
                return;
            }

            float total = 0;
            foreach (float nota in notas.Values)
            {
                total += nota;
            }
            float media = total / notas.Count;
            Console.WriteLine("La nota media es: " + media);
        }

        /// <summary>
        /// Encuentra y muestra la nota máxima.
        /// </summary>
        /// <param name="notas">Diccionario de notas.</param>
        public static void NotaMax(Dictionary<string, float> notas)
        {
            if (notas.Count == 0)
            {
                Console.WriteLine("Error: No hay notas disponibles.");
                return;
            }

            float max = float.MinValue;
            string nombreMax = "";
            foreach (var entry in notas)
            {
                if (entry.Value > max)
                {
                    max = entry.Value;
                    nombreMax = entry.Key;
                }
            }
            Console.WriteLine("La nota máxima es: " + max + ", obtenida por " + nombreMax);
        }

        /// <summary>
        /// Encuentra y muestra la nota mínima.
        /// </summary>
        /// <param name="notas">Diccionario de notas.</param>
        public static void NotaMin(Dictionary<string, float> notas)
        {
            if (notas.Count == 0)
            {
                Console.WriteLine("Error: No hay notas disponibles.");
                return;
            }

            float min = float.MaxValue;
            string nombreMin = "";
            foreach (var entry in notas)
            {
                if (entry.Value < min)
                {
                    min = entry.Value;
                    nombreMin = entry.Key;
                }
            }
            Console.WriteLine("La nota mínima es: " + min + ", obtenida por " + nombreMin);
        }

        /// <summary>
        /// Añade una nueva nota al diccionario.
        /// </summary>
        /// <param name="notas">Diccionario de notas.</param>
        public static void AnadirNota(Dictionary<string, float> notas)
        {   
            if (notas.Count == 0)
            {
                Console.WriteLine("No se ha cargado ningún fichero o ha habido un error.");
                return;
            }
            try
            {
                Console.WriteLine("Introduce el nombre del alumno:");
                string nuevoNombre = Console.ReadLine();
                Console.WriteLine("Introduce la nota del alumno:");
                string nuevaNota = Console.ReadLine();

                if (nuevaNota.Contains(","))
                    {
                        nuevaNota = nuevaNota.Replace(",", ".");
                    }
            
                if (float.TryParse(nuevaNota, CultureInfo.InvariantCulture, out float nuevaNotaFloat))
                    {
                    }
                    else
                    {
                        Console.WriteLine("Error: El formato de la nueva nota no es válido. Vuelva a intentarlo.");
                        AnadirNota(notas);
                        return;
                    }
                
                if (nuevaNotaFloat > 10 || nuevaNotaFloat < 0)
                {
                    Console.WriteLine("Error: La nota debe estar entre 0 y 10. Vuelva intentarlo.");
                    AnadirNota(notas);
                    return;
                }
                notas[nuevoNombre] = nuevaNotaFloat;
                Console.WriteLine("Nombre: " + nuevoNombre + "  |   Nota: " + nuevaNotaFloat);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: No se pudo añadir la nota. " + ex.Message);
            }
        }

        /// <summary>
        /// Guarda las notas en un fichero .csv.
        /// </summary>
        /// <param name="ruta">Ruta del fichero .csv.</param>
        /// <param name="notas">Diccionario de notas.</param>
        public static void GuardarNotas(string ruta, Dictionary<string, float> notas)
        {
            if (notas.Count == 0 || ruta == null)
            {
                Console.WriteLine("No se ha cargado ningún fichero o ha habido un error.");
                return;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(ruta, false))
                {
                    foreach (var entry in notas)
                    {
                        sw.WriteLine(entry.Key + ";" + entry.Value);
                    }
                }
                Console.WriteLine("Notas guardadas correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: No se pudo guardar el archivo. " + ex.Message);
            }
        }
    }
}