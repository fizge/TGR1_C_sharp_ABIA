using System.Globalization;
class MenuAlumnos
{
    static void Main(string[] args)
    {
        string opcion;
        Dictionary<string, float> notas = new Dictionary<string, float>();
        string ruta = null;

        while (true)  // Bucle que mantiene el programa en el menú hasta que elija cerrar
        {
            Console.Clear();  // Limpiar pantalla en cada ciclo
            Menu();  // Mostrar menú
            opcion = Console.ReadLine();  // Leer opción
            //C:\\Users\\fizga\\Desktop\\ABIA\\TGR1_ABIA_GuillermoBlancoNunez_FizGarridoEscudero\\Alumnos.csv

            switch (opcion)
            {
                case "1":
                    CargarDatos(ref ruta, notas);
                    break;
                case "2":
                    NotaMedia(notas);
                    break;
                case "3":
                    NotaMax(notas);
                    break;
                case "4":
                    NotaMin(notas);
                    break;
                case "5":
                    AñadirNota(notas);
                    break;
                case "6":
                    GuardarNotas(ruta, notas);
                    break;
                case "7":
                    Console.WriteLine("Cerrando...");
                    return;  // Sale del programa
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }

            // Puedes agregar un mensaje para que el usuario vea el resultado y luego regrese al menú
            Console.WriteLine("\nPresiona Enter para volver al menú...");
            Console.ReadLine();  // Pausa para que el usuario vea el resultado antes de volver al menú
        }
    }

    // Método para mostrar el menú
    static void Menu()
    {
        Console.WriteLine("\n\n ¿Qué acción desea realizar?");
        Console.WriteLine("1. Cargar los datos de un fichero");
        Console.WriteLine("2. Obtener la nota media");
        Console.WriteLine("3. Obtener la nota máxima");
        Console.WriteLine("4. Obtener la nota mínima");
        Console.WriteLine("5. Añadir una nueva nota");
        Console.WriteLine("6. Guardar");
        Console.WriteLine("7. Cerrar");
        Console.Write("\n--> ");
    }

    static void CargarDatos(ref string ruta, Dictionary<string, float> notas) // empleamos ref para ACTUALIZAR LA RUTA
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
        
                //Evitamos diferencias en la lectura de decimales entre eeuu y europa
                if (float.TryParse(notaValida, NumberStyles.Any, CultureInfo.InvariantCulture, out float notaFloat))
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
        catch (Exception ex)
        {
            Console.WriteLine("Error: No se pudo leer el archivo. " + ex.Message);
        }
    }

    static void NotaMedia(Dictionary<string, float> notas)
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

    static void NotaMax(Dictionary<string, float> notas)
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

    static void NotaMin(Dictionary<string, float> notas)
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

    static void AñadirNota(Dictionary<string, float> notas)
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
            float nuevaNota = float.Parse(Console.ReadLine());
            if (nuevaNota > 10 || nuevaNota < 0)
            {
                Console.WriteLine("Error: La nota debe estar entre 0 y 10.");
                return;
            }
            notas[nuevoNombre] = nuevaNota;
            Console.WriteLine("Nombre: " + nuevoNombre + "    |   Nota: " + nuevaNota);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: No se pudo añadir la nota. " + ex.Message);
        }
    }

    static void GuardarNotas(string ruta, Dictionary<string, float> notas)
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
