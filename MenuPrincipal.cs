using TGR1_Ej1;
using TGR1_Ej2;

class MenuPrincipal
    {
        public static void EjecutarPrograma()
        {
            int eleccion = 0;
            Console.WriteLine("Introduzca el ejercicio del TGR 1 que quiera introducir (1 o 2):");
            while (eleccion != 1 && eleccion != 2){
                eleccion = Convert.ToInt32(Console.ReadLine());

            if (eleccion == 1){
                Menu_Ej1.MostrarMenu();
                }
            else{
                Menu_Ej2.MostrarMenu();
                }
            }
        }
    }