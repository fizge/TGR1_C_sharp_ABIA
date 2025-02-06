// Guillermo Blanco Nuñez y Fiz Garrido Escudero GRUPO JUEVES
namespace TGR1_Ej2
{
    /// <summary>
    /// Representa un perro con atributos de color, altura, peso y una bolsa de bolas.
    /// </summary>
    class Perro
    {
        public string color;
        public float altura;
        public float peso;
        public Bolsa bolsa;

        /// <summary>
        /// Constructor de la clase Perro.
        /// </summary>
        /// <param name="color">Color del perro.</param>
        /// <param name="altura">Altura del perro.</param>
        /// <param name="peso">Peso del perro.</param>
        /// <param name="bolsa">Bolsa de bolas del perro.</param>
        public Perro(string color, float altura, float peso, Bolsa bolsa)
        {
            this.color = color;
            this.altura = altura;
            this.peso = peso;
            this.bolsa = bolsa;
        }

        /// <summary>
        /// Método para que el perro coma una bola de su bolsa.
        /// </summary>
        /// <param name="bolsa">Bolsa de la cual se retirará una bola.</param>
        public void comerBola(Bolsa bolsa)
        {
            if (bolsa.ContarBolas(bolsa.bolas) == 0)
            {
                Console.WriteLine("No hay bolas en la bolsa.");
                return;
            }
            bolsa.bolas = Bolsa.RetirarBola(bolsa.bolas);
        }

        /// <summary>
        /// Muestra los atributos del perro.
        /// </summary>
        public void MostrarAtributos()
        {
            Console.WriteLine("Color: " + color + "\tAltura: " + altura + "\tPeso: " + peso + "\tBolsa: " + bolsa.bolas);
        }
    }
}