namespace TGR1_Ej2
{
    /// <summary>
    /// Clase que maneja el menú para el ejercicio 2.
    /// </summary>
    public class Menu_Ej2
    {
        static int n;

        /// <summary>
        /// Muestra el menú y maneja la lógica de clonar perros.
        /// </summary>
        public static void MostrarMenu()
        {
            Console.WriteLine("¿Cuántas veces quieres clonar al perro?");
            bool isValidNumber = false;
            while (isValidNumber == false)
            {
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n < 0)
                    {
                        Console.WriteLine("Número no válido, introduzca otro.");
                    }
                    else
                    {
                        isValidNumber = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Número no válido, introduzca otro.");
                }
            }
            Bolsa bolsa = new Bolsa("azul roja verde");
            Perro perroOrig = new Perro("Rojo", 20f, 1.8f, bolsa);
            perroOrig.MostrarAtributos();

            for (int i = 0; i < n; i++)
            {
                Bolsa bolsaClon = new Bolsa("azul roja verde");
                Perro perroClon = new Perro("Rojo", 20f, 1.8f, bolsaClon);
                perroClon.comerBola(perroClon.bolsa);
                perroClon.MostrarAtributos();
            }
        }
    }
}

