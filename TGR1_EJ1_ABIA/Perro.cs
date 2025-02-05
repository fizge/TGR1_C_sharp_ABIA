using System.Diagnostics;

class Perro{
    string color;
    int altura;
    float peso;
    Bolsa bolsa;
    public Perro(string color, int altura, float peso, Bolsa bolsa){
        this.color = color;
        this.altura = altura;
        this.peso = peso;
        this.bolsa = bolsa;
    }

    public void comerBola(Bolsa bolsa){
        this.bolsa.bolas = Bolsa.retirarBola(bolsa.bolas);
    }
}