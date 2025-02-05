public class Menu_Ej2
{
    static int n = -1;
    public static void MostrarMenu(string[] args)
    {
       Console.WriteLine("¿Cuántas veces quieres clonar al perro?");
        while (n <= 0){
            n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0){
                Console.WriteLine("Número no válido, introduzca otro.");
            }
        Bolsa bolsa = new Bolsa("azul roja verde");
        Perro perrete = new Perro("Rojo", 20f, 1.8f, bolsa);
        perrete.MostrarAtributos();

        for (int i = 0; i < n; i++){
            Bolsa bolsillo = new Bolsa("azul roja verde");
            Perro perrito = new Perro("Rojo", 20f, 1.8f, bolsillo);
            perrito.comerBola(perrito.bolsa);
            perrito.MostrarAtributos();

        }
        }
    }
} 