namespace Library;

public static class CalculadoraBono
{
    //Se crea esta clase para cumplir con el SRP de la clase Vendedor
    public static int calcularBono(int numeroVentas)
    {
        int bono = numeroVentas * 100;
        return bono;
    }
}