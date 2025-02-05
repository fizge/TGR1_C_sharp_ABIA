public class Program
{
    public static void Main(string[] args)
    {
        string ruta = null;
        Dictionary<string, float> notas = new Dictionary<string, float>();

        //EJEMPLO DE RUTA
        //C:\\Users\\fizga\\Desktop\\ABIA\\TGR1_ABIA_GuillermoBlancoNunez_FizGarridoEscudero\\TGR1_EJ1_ABIA\\Alumnos.csv
        Menu.MostrarMenu(ref notas, ref ruta);
    }
}
