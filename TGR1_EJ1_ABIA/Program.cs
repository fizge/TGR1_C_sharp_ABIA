using TGR1_Ej1;
using TGR1_Ej2;
public class Program
{
    public static void Main(string[] args){
        int eleccion = 0;
        Console.WriteLine("Introduzca el ejercicio del TGR 1 que quiera introducir (1 o 2):");
        while (eleccion != 1 && eleccion != 2){
            eleccion = Convert.ToInt32(Console.ReadLine());

        if (eleccion == 1){
            Ej1(args);
        }
        else{
            Ej2(args);
        }
        }
    }
    
    
    
    public static void Ej1(string[] args)
    {
        Menu_Ej1.MostrarMenu(args);
    }

    public static void Ej2(string[] args)
    {
        Menu_Ej2.MostrarMenu(args);
    }
}
