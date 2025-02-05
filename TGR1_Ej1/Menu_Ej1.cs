namespace TGR1_Ej1
{
    public class Menu_Ej1
    {
        public static string ruta = null;
        public static Dictionary<string, float> notas = new Dictionary<string, float>();
        public static void MostrarMenu()
        {
            string opcion;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\n ¿Qué acción desea realizar?");
                Console.WriteLine("1. Cargar los datos de un fichero");
                Console.WriteLine("2. Obtener la nota media");
                Console.WriteLine("3. Obtener la nota máxima");
                Console.WriteLine("4. Obtener la nota mínima");
                Console.WriteLine("5. Añadir una nueva nota");
                Console.WriteLine("6. Guardar");
                Console.WriteLine("7. Cerrar");
                Console.Write("\n--> ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Funciones.CargarDatos(ref ruta, notas);
                        break;
                    case "2":
                        Funciones.NotaMedia(notas);
                        break;
                    case "3":
                        Funciones.NotaMax(notas);
                        break;
                    case "4":
                        Funciones.NotaMin(notas);
                        break;
                    case "5":
                        Funciones.AñadirNota(notas);
                        break;
                    case "6":
                        Funciones.GuardarNotas(ruta, notas);
                        break;
                    case "7":
                        Console.WriteLine("Cerrando...");
                        return; 
                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        break;
                }

                // Pausa para que el usuario vea el resultado antes de volver al menú
                Console.WriteLine("\nPresiona Enter para volver al menú...");
                Console.ReadLine();
            }
        }
    }
}