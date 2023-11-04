using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using VisualApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VisualApi.Controllers
{
    [Route("[controller]")]
    public class PersonaController : Controller
    {
        private readonly String StringConector;

        public PersonaController(IConfiguration config)
        {

            StringConector = config.GetConnectionString("OracleConnection"); 

        }

        // GET: api/values
        [HttpGet]
        public IActionResult ListarPersona()
        {
            try {

                using (OracleConnection conecta = new OracleConnection(StringConector)) {

                    conecta.Open();

                    using(OracleCommand comandos = new OracleCommand("SELECT * FROM PERSONA", conecta))
                    {

                        OracleDataReader lector = comandos.ExecuteReader();

                        var personal = new List<Persona>();

                        while (lector.Read())
                        {

                            personal.Add(new Persona
                            {

                                idPersona = lector.GetInt32(0),
                                NombrePersona = lector.GetString(1),
                                ApellidoPat = lector.GetString(2),
                                ApellidoMat = lector.GetString(3),
                                EdadPersona = lector.GetInt32(4),
                                FechaNac = lector.GetDateTime(5),
                                GeneroPersona = lector.GetString(6)


                            }) ; 




                        }

                        return StatusCode(200, personal);


                    }
  

                }

 

            } catch (Exception ex) {


                return StatusCode(500, "No se pudo listar las personas por: " + ex);

            }

           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult ListarIndividual(int id)
        {

            try {


                using (OracleConnection conecta = new OracleConnection(StringConector))
                {

                    conecta.Open();

                    var sentencia = "SELECT * FROM PERSONA WHERE ID = :id";

                    using (OracleCommand comando = new OracleCommand(sentencia, conecta))
                    {

                        comando.Parameters.Add(new OracleParameter("id", id));

                        OracleDataReader lector = comando.ExecuteReader();

                        if (lector.Read())
                        {

                            var personal = new Persona()
                            {

                                idPersona = lector.GetInt32(0),
                                NombrePersona = lector.GetString(1),
                                ApellidoPat = lector.GetString(2),
                                ApellidoMat = lector.GetString(3),
                                EdadPersona = lector.GetInt32(4),
                                FechaNac = lector.GetDateTime(5),
                                GeneroPersona = lector.GetString(6)

                            };

                            return StatusCode(200, personal);

                        }
                        else
                        {

                            return StatusCode(404, "Registro no encontrado");
                        }


                    }

                }


            }catch(Exception ex) {

                return StatusCode(500, "No se pudo obtener la informacion por :" + ex);


            }


        }

        // POST api/values
        [HttpPost]
        public IActionResult GuardarPersona([FromBody] Persona persona)
        {
            try {

                using (OracleConnection conector = new OracleConnection(StringConector))
                {

                    conector.Open();

                    string sentencia = "INSERT INTO PERSONA (ID,NOMBRE, APELLIDO_PAT, APELLIDO_MAT, EDAD, F_NAC, GENERO) VALUES (:idPersona, :NombrePersona, :ApellidoPat, :ApellidoMat, :EdadPersona, :FechaNac, :GeneroPersona)";

                    OracleCommand comando = new OracleCommand(sentencia, conector);


                    comando.Parameters.Add(new OracleParameter("idPersona", persona.idPersona));
                    comando.Parameters.Add(new OracleParameter("NombrePersona", persona.NombrePersona));
                    comando.Parameters.Add(new OracleParameter("ApellidoPat", persona.ApellidoPat));
                    comando.Parameters.Add(new OracleParameter("ApellidoMat", persona.ApellidoMat));
                    comando.Parameters.Add(new OracleParameter("EdadPersona", persona.EdadPersona));
                    comando.Parameters.Add(new OracleParameter("FechaNac", persona.FechaNac));
                    comando.Parameters.Add(new OracleParameter("GeneroPersona", persona.GeneroPersona));


                    comando.ExecuteNonQuery();

                    return StatusCode(201, "Persona creada correctamente");


                }

            }catch(Exception ex)

            {
                return StatusCode(500, "No se pudo guardar el registro por: " + ex);

            }


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult EditarPersona(int id, [FromBody]Persona persona)
        {

            try {


                using(OracleConnection conector = new OracleConnection(StringConector))
                {

                    conector.Open();

                    string sentencia = "UPDATE PERSONA SET NOMBRE = :NombrePersona , APELLIDO_PAT=:ApellidoPat, APELLIDO_MAT = :ApellidoMat, EDAD =:EdadPersona , F_NAC = :FechaNac, GENERO = :GeneroPersona WHERE ID = :id";

                    using (OracleCommand comando = new OracleCommand(sentencia, conector))
                    {

                        comando.Parameters.Add(new OracleParameter("NombrePersona", persona.NombrePersona));
                        comando.Parameters.Add(new OracleParameter("ApellidoPat", persona.ApellidoPat));
                        comando.Parameters.Add(new OracleParameter("ApellidoMat", persona.ApellidoMat));
                        comando.Parameters.Add(new OracleParameter("EdadPersona", persona.EdadPersona));
                        comando.Parameters.Add(new OracleParameter("FechaNac", persona.FechaNac));
                        comando.Parameters.Add(new OracleParameter("GeneroPersona", persona.GeneroPersona));
                        comando.Parameters.Add(new OracleParameter("id", id));

                        comando.ExecuteNonQuery();

                        return StatusCode(200, "Registro editado exitosamente");


                    }

                }


            }catch(Exception ex) {

                return StatusCode(500, "No se pudo editar el registro por: " + ex);

            }


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult EliminarPersona(int id)
        {
            try {

                using(OracleConnection conector = new OracleConnection(StringConector))
                {

                    conector.Open();

                    string sentencia = "DELETE FROM PERSONA WHERE ID = :id";

                    using (OracleCommand comando = new OracleCommand(sentencia, conector))
                    {

                        comando.Parameters.Add(new OracleParameter("id", id));

                        int filas = comando.ExecuteNonQuery();

                        if(filas == 0) {

                            return StatusCode(404, "Registro no encontrado!");

                        } else {

                            return StatusCode(200, $"Persona con el ID {id} eliminada correctamente");

                        }


                    }

                }

            }catch(Exception ex) {

                return StatusCode(500, "No se pudo eliminar el registro por: " + ex);

            }

        }
    }
}

