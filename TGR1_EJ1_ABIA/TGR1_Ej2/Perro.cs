using System.Diagnostics;
namespace TGR1_Ej2
{
    class Perro{
        public string color;
        public float altura;
        public float peso;
        public Bolsa bolsa;
        public Perro(string color, float altura, float peso, Bolsa bolsa){
            this.color = color;
            this.altura = altura;
            this.peso = peso;
            this.bolsa = bolsa;
        }

        public void comerBola(Bolsa bolsa){
            if (bolsa.contarBolas(bolsa.bolas) == 0){
                Console.WriteLine("No hay bolas en la bolsa.");
            }
            bolsa.bolas = Bolsa.retirarBola(bolsa.bolas);
        }

        public void MostrarAtributos(){
            Console.WriteLine("Color: " + color + "\tAltura: " + altura + "\tPeso: " + peso + "\tBolsa: " + bolsa.bolas);
        }
    }
}