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
        string ruta = null;
        Dictionary<string, float> notas = new Dictionary<string, float>();

        //EJEMPLO DE RUTA
        //C:\\Users\\fizga\\Desktop\\ABIA\\TGR1_ABIA_GuillermoBlancoNunez_FizGarridoEscudero\\TGR1_EJ1_ABIA\\Alumnos.csv
        Menu_Ej1.MostrarMenu(ref notas, ref ruta);
    }

    public static void Ej2(string[] args)
    {
        Menu_Ej2.MostrarMenu(args);
    }
}
