using System;

namespace consola_1{

    class Consola1{
        static void Main(string[] args){
        
            //ciclo FOR

            for (int i = 0; i < 10; i++){
                Console.WriteLine("Me gustan las clases de este profe: "+ i);
            }

        }

    }

}

           /* //en este paso se evalua el primer operando y si es 
            //falso no se evalua el segundo
            //por lo que el resultado es falso
            bool boleano_A = false | metodoPaso();
            Console.WriteLine(boleano_A);



            //en este paso se evalua el primer operando y si es 
            //verdadero se evalua el segundo 
            //y si ambos son verdaderos el resultado es verdadero
            bool boleano_B = true & metodoPaso();
            Console.WriteLine(boleano_B);*/

            /*//este código devolverá verdadero dado que el primer 
            //operando es verdadero
            bool boleano_A = false && metodoPaso();
            Console.WriteLine(boleano_A);*/

            /* bool  metodoPaso(){

                Console.WriteLine("El segundo operando se evalua");
                return true;
            }*/

                /* //Esto debería devolver falso dado que el primer operando es falso
        Console.WriteLine(true ^ true); 

        //Esto debería devolver verdadero dado que el primer operando es verdadero
        Console.WriteLine(true ^ false);

        //Esto debería devolver verdadero dado que el primer operando es verdadero
        Console.WriteLine(false ^ true);

        //Esto debería devolver falso dado que el primer operando es falso
        Console.WriteLine(false ^ false);*/

        /*bool metodoPaso1(){
           
            Console.WriteLine("El segundo operando se evalua");
            return true;
        }

        //en este paso se evalua el primer operando y si es verdadero
        //no se evalua el segundo resultando en verdadero 
        bool a = true || metodoPaso1();
        Console.WriteLine(a);

        //en este paso se evalua el primer operando y si es falso
        // si se evalua el segundo resultando en verdadero en este caso
        bool b = false || metodoPaso1();
        Console.WriteLine(b);*/

        /*
                int diaSemana = 6;

        switch (diaSemana){

            case 1: 
            Console.WriteLine("Lunes");
            break;

            case 2:
            Console.WriteLine("Martes");
            break;

            case 3:
            Console.WriteLine("Miercoles");
            break;

            case 4:
            Console.WriteLine("Jueves");
            break;

            case 5:
            Console.WriteLine("Viernes");
            break;

            default:
            Console.WriteLine("Es fin de semana");
            break;
        }

        */