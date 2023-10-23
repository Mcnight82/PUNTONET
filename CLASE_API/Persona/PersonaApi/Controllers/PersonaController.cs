using Oracle.ManagedDataAccess.Client;
using Microsoft.AspNetCore.Mvc;

//definimos un controlador
[ApiController]
//creamos el recurso "Persona" global
[Route("Persona")]

//extendemos de la clase ControllerBase
public class PersonaController: ControllerBase{
    
    //generamos variable de conexion global
    private readonly String stringConector;

    //creamos el constructor de la api con método centralizado de conexion
    public PersonaController(IConfiguration config){

        //creamos una variable que contiene el string de conexion a la base de datos ORACLE
        stringConector = config.GetConnectionString("OracleConnection");

    }

    //creamos la ruta httpGet
    [HttpGet]
    //creamos el método respectivo
    public IActionResult Listar(){

        //Creamos un bloque try-catch para el manejo de posibles excepciones 
       try{

        //usamos la conexion recien creada
        using (OracleConnection conector = new OracleConnection(stringConector)){

            //abrimos la conexion a la bd
            conector.Open();

            //creamos el comando que contiene la sentencia SQL deseada
            using (OracleCommand comando = new OracleCommand("SELECT * FROM PERSONA", conector)){

            //disponemos la ejecución del comando
            using (OracleDataReader lector = comando.ExecuteReader()){

                //creamos la lista correspondiente
                List<Persona> personal = new List<Persona>();

                //generamos un elemento de repetición
                while (lector.Read()){

                    personal.Add(new Persona{

                        IdPersona = lector.GetInt32(0),
                        NombrePersona = lector.GetString(1),
                        ApellidoPat = lector.GetString(2),
                        ApellidoMat = lector.GetString(3),
                        EdadPersona = lector.GetInt32(4),
                        FechaNac = lector.GetDateTime(5),
                        GeneroPersona = lector.GetString(6)

                    });


                }

                    return StatusCode(200, personal);
                   


            }
            

            }

            conector.Close();

        }

    

    }catch(Exception ex){

            return StatusCode(500, "No se pudo conectar por: "+ex);

    }



    }



    //creamos la ruta httpGet
    [HttpGet("{id}")]
    //creamos el método respectivo
    public IActionResult ListarIndividual(int id){

        //Creamos un bloque try-catch para el manejo de posibles excepciones 
       try{

        //usamos la conexion recien creada
        using (OracleConnection conector = new OracleConnection(stringConector)){

            //abrimos la conexion a la bd
            conector.Open();

            //creamos el comando que contiene la sentencia SQL deseada
            using (OracleCommand comando = new OracleCommand("SELECT * FROM PERSONA WHERE ID = :id", conector)){
            
            comando.Parameters.Add(new OracleParameter("id",id));    

            //disponemos la ejecución del comando
            using (OracleDataReader lector = comando.ExecuteReader()){

              //generamos un elemento de control

              if(lector.Read()){

                var personal = new Persona{

                    IdPersona = lector.GetInt32(0),
                    NombrePersona = lector.GetString(1),
                    ApellidoPat = lector.GetString(2),
                    ApellidoMat = lector.GetString(3),
                    EdadPersona = lector.GetInt32(4),
                    FechaNac = lector.GetDateTime(5),
                    GeneroPersona = lector.GetString(6)

                };

                return StatusCode(200, personal);

              }else{
                
                return StatusCode(404, "no se encontro el registro");
                
                }
  

            }
            

            }

            conector.Close();

        }

    

    }catch(Exception ex){

            return StatusCode(500, "No se pudo conectar por: "+ex);

    }



    }



}