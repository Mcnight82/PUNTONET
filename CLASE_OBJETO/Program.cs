using System.Security.AccessControl;

public class Principal{


    public static void Main(string[] args){
       
       //INTERACTUAR CON EL USUARIO
         //1. mostrar un mensaje al usuario
       /*  Console.WriteLine("Ingrese el primer numero: ");
        //2. capturar el dato ingresado por el usuario
        int nume1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el segundo numero: ");
        int nume2 = int.Parse(Console.ReadLine());

        //3. instanciar la clase Operaciones
        Operaciones operar = new Operaciones();

        //4. invocar los metodos de la clase Operaciones
        Console.WriteLine("El resultado de la suma es: " + operar.Sumar(nume1,nume2));


        Console.WriteLine("Ingrese un primer numero para restar: ");
        int nume3 = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese un segundo numero para restar: ");
        int nume4 = int.Parse(Console.ReadLine());  


       Console.WriteLine("El resultado de la resta es: " + operar.Restar(nume3,nume4));*/

        Operaciones operar = new Operaciones();

        Console.WriteLine("Ingrese un primer numero para multiplicar: ");
        double nume5 = double.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese un segundo numero para multiplicar: ");
        double nume6 = double.Parse(Console.ReadLine());  


       Console.WriteLine("El resultado de la resta es: " + operar.Multiplicar(nume5,nume6));




    }


}
