using System.Diagnostics;

class Perro{
    string color;
    float altura;
    float peso;
    public Bolsa bolsa;
    public Perro(string color, float altura, float peso, Bolsa bolsa){
        this.color = color;
        this.altura = altura;
        this.peso = peso;
        this.bolsa = bolsa;
    }

    public void comerBola(Bolsa bolsa){
        bolsa.bolas = Bolsa.retirarBola(bolsa.bolas);
    }

    public void MostrarAtributos(){
        Console.WriteLine("Color: " + color + "\tAltura: " + altura + "\tPeso: " + peso + "\tBolsa: " + bolsa.bolas);
    }
}