// Guillermo Blanco Nuñez y Fiz Garrido Escudero GRUPO JUEVES
namespace TGR1_Ej2
{
    /// <summary>
    /// Representa una bolsa que contiene bolas.
    /// </summary>
    class Bolsa
    {
        public string bolas;

        /// <summary>
        /// Constructor de la clase Bolsa.
        /// </summary>
        /// <param name="bolas">Cadena que representa las bolas en la bolsa.</param>
        public Bolsa(string bolas)
        {
            this.bolas = bolas;
        }

        /// <summary>
        /// Retira una bola aleatoria de la bolsa.
        /// </summary>
        /// <param name="bolas">Cadena que representa las bolas en la bolsa.</param>
        /// <returns>Cadena con una bola menos.</returns>
        public static string RetirarBola(string bolas)
        {
            string[] coleccion = bolas.Split(' ');
            if (coleccion.Length == 0)
            {
                return bolas;
            }
            Random random = new Random();
            int indice = random.Next(coleccion.Length);
            return string.Join(" ", coleccion.Where((palabra, i) => i != indice));
        }

        /// <summary>
        /// Cuenta el número de bolas en la bolsa.
        /// </summary>
        /// <param name="bolas">Cadena que representa las bolas en la bolsa.</param>
        /// <returns>Número de bolas en la bolsa.</returns>
        public int ContarBolas(string bolas)
        {
            string[] cantidad = bolas.Split(' ');
            return cantidad.Length;
        }
    }
}