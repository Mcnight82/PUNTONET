
public class Operaciones{

    //primera parte ... las PROPIEDADES
    //declaramos las propiedades
    public int numero1 { get; set; }

    public int numero2 { get; set; }

    public double numero3 { get; set; }

    public double numero4 { get; set; }

    //segunda parte ... EL CONSTRUCTOR
    // declarar el constructor
    public Operaciones(){

        //la idea de la recepcion de argumentos desde el constructor
        //es entregar estos datos de forma centralizada a las acciones/metodos

    }

    //tercera parte ... LOS METODOS
    //declarar los metodos
    public int Sumar(int num1, int num2){

        numero1 = num1;
        numero2 = num2;

        return numero1 + numero2;

    }

    public int Restar(int num1, int num2){

        numero1 = num1;
        numero2 = num2;

        return numero1 - numero2;

    }

    public double Multiplicar(double num1, double num2){

        numero3 = num1;
        numero4 = num2;

        return numero3 * numero4;

    }



    }


