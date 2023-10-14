//generamos la api de persona
//importamos los using necesarios
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;


public class PersonaController : ControllerBase{

        public Persona[] personas = new Persona []{

            new Persona{Id=1, Nombre="Juan", Apellido="Perez", Edad=20, Profesion="Estudiante", Direccion="Calle 1"},
            new Persona{Id=2, Nombre="Maria", Apellido="Gomez", Edad=25, Profesion="Ingeniero", Direccion="Calle 2"},
            new Persona{Id=3, Nombre="Pedro", Apellido="Garcia", Edad=30, Profesion="Abogado", Direccion="Calle 3"},
            new Persona{Id=4, Nombre="Luis", Apellido="Rodriguez", Edad=35, Profesion="Médico", Direccion="Calle 4"},
            new Persona{Id=5, Nombre="Ana", Apellido="Lopez", Edad=40, Profesion="Analísta", Direccion="Calle 5"},
            new Persona{Id=6, Nombre="Roberto", Apellido="Bravo", Edad=45, Profesion="Mecánico", Direccion="Calle 6"},
            new Persona{Id=7, Nombre="Paola", Apellido="Camaggi", Edad=41, Profesion="Actriz", Direccion="Calle 7"},
            new Persona{Id=8, Nombre="Viví", Apellido="Arismendi", Edad=35, Profesion="Bailarina", Direccion="Calle 8"},
            new Persona{Id=9, Nombre="Nicolás", Apellido="Van Shouwen", Edad=22, Profesion="Estudiante", Direccion="Calle 9"},
            new Persona{Id=10, Nombre="Matías", Apellido="Briceño", Edad=51, Profesion="Ingeniero Comercial", Direccion="Calle 10"}


        };

    //creamos nuestro metodo get
    [HttpGet]
    //entregamos la ruta correspondiente a la api recordando
    //que se deben pensar como un RECURSO no como un LINK
    [Route("Persona")]
    public IActionResult ListarPersonas(){
 
        //creamos elemento de control para recorrer el arreglo
        if(personas != null){

            //recorremos el arreglo de personas
            for(int i = 0; i < personas.Length; i++){

                //imprimimos en consola cada persona
                Console.WriteLine(personas[i]);
            }

            //imprimimos el status code 200 que es correcto
            return StatusCode(200, personas);
            
        }else{

            //imprimimos en consola que no hay personas
            Console.WriteLine("No hay personas");
            return StatusCode(404);

        }


    }

    [HttpGet]
    [Route("Persona/{id}")]

    public IActionResult ListarPersonaId(int id){


        //creamos elemento de control para recorrer el arreglo
        if (id > 0 && id <= personas.Length){

            //imprimimos en consola que se encontro la persona
            Console.WriteLine("Se encontro la persona");

            //imprimimos el status code 200 que es correcto
            return StatusCode(200, personas[id-1]);


        }else{

            //imprimimos en consola que no se encontro la persona
            Console.WriteLine("Persona No encontrada");
            return StatusCode(404);

        }

    }

    
    [HttpPost]
    [Route("Persona")]
    public IActionResult CrearPersona([FromBody] Persona persona){


        //generamos un elemento de control para el ingreso de nueva persona
        if(personas != null){

            //imprimimos en consola que se creo la persona
            Console.WriteLine("Se creo la persona");
            return StatusCode(201, personas);
            
            }else{

                //imprimimos en consola que no se creo la persona
                Console.WriteLine("No se pudo crear la persona");
                return StatusCode(404);
                
                }

    }

    [HttpPut]
    [Route("Persona/{id}")]

    public IActionResult EditarPersona(int id, [FromBody] Persona persona){


        //creamos elemento de control para recorrer el arreglo

        if (id > 0 && id <= personas.Length){

            //procedemos a la edicion de la persona
            personas[id-1].Nombre = persona.Nombre;
            personas[id-1].Apellido = persona.Apellido;
            personas[id-1].Edad = persona.Edad;
            personas[id-1].Profesion = persona.Profesion;
            personas[id-1].Direccion = persona.Direccion;
            
            //imprimimos el status code 200 que es correcto
            return StatusCode(200, personas[id-1]);

        }else if(id==0){

            //imprimimos en consola que no se encontro la persona
            Console.WriteLine("Persona No encontrada");
            return StatusCode(404);


        }else{

            //imprimimos que no se pudo editar la persona
            Console.WriteLine("No se pudo editar la persona");
            return StatusCode(400);

        }



    }

    [HttpDelete]
    [Route("Persona/{id}")]

    public IActionResult BorrarPersona(int id){

        //creamos elemento de control para recorrer el arreglo
        if (id > 0 && id <= personas.Length){

            //procedemos a la eliminacion de la persona
            personas[id-1] = null;
            
            //imprimimos el status code 200 que es correcto
            return StatusCode(200, personas);
            
         
            }else{

                //imprimimos en consola que no se encontro la persona
                Console.WriteLine("Persona No encontrada");
                return StatusCode(404);
                
                }

    }




}