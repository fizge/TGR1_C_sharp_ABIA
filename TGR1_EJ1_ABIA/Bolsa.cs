class Bolsa{
    public string bolas;
    public Bolsa(string bolas){
        this.bolas = bolas;
    }
    public static string retirarBola(string bolas){
        string[] coleccion = bolas.Split(' '); 
        if (coleccion.Length == 0){
            return bolas; 
        }
        Random random = new Random();
        int indice = random.Next(coleccion.Length); 
        return string.Join(" ", coleccion.Where((palabra, i) => i != indice));
    }
}