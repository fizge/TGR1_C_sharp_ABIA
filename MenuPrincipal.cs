// Guillermo Blanco Nuñez y Fiz Garrido Escudero GRUPO JUEVES

using TGR1_Ej1;
using TGR1_Ej2;

/// <summary>
/// Clase que maneja el menú principal del programa.
/// </summary>
class MenuPrincipal
{
    /// <summary>
    /// Ejecuta el programa principal, permitiendo al usuario elegir entre los ejercicios 1 y 2.
    /// </summary>
    public static void EjecutarPrograma()
    {
        int eleccion = 0;
        while (true)
        {
            Console.WriteLine("Introduzca el ejercicio del TGR 1 que quiera ejecutar (1 o 2):");
            if (int.TryParse(Console.ReadLine(), out eleccion) && (eleccion == 1 || eleccion == 2))
            {
                break;
            }

            Console.WriteLine("Error: Entrada inválida. Por favor, ingrese 1 o 2.");
        }
        if (eleccion == 1)
        {
            Menu_Ej1.MostrarMenu();
        }
        else
        {
            Menu_Ej2.MostrarMenu();
        }
    }
    
}
