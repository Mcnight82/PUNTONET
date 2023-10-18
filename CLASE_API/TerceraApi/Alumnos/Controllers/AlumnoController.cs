using Microsoft.AspNetCore.Mvc;

[ApiController]
public class Alumno : ControllerBase{

    public Alumnos[] DatosAlumnos = new Alumnos[]{

        new Alumnos {Id=1, Nombre = "Pepito",ApellidoPaterno = "Perez", ApellidoMaterno="Manriquez", Edad = 17, Genero="M", Nota1=5.6f, Nota2=3.2f, Nota3=3.1f, Promedio=6.3f},
        new Alumnos {Id=2, Nombre = "Juanito",ApellidoPaterno = "Polanco", ApellidoMaterno="Moreno", Edad = 16, Genero="M", Nota1=5.4f, Nota2=1.2f, Nota3=2.1f, Promedio=5.3f},
        new Alumnos {Id=3, Nombre = "Miguelito",ApellidoPaterno = "Papirot", ApellidoMaterno="Millar", Edad = 20, Genero="M", Nota1=5.4f, Nota2=1.2f, Nota3=2.1f, Promedio=3.3f},
        new Alumnos {Id=4, Nombre = "Dieguito",ApellidoPaterno = "Pascal", ApellidoMaterno="Mancilla", Edad = 18, Genero="M", Nota1=5.3f, Nota2=5.2f, Nota3=2.1f, Promedio=3.3f},
        new Alumnos {Id=5, Nombre = "Marcianeke",ApellidoPaterno = "Poveda", ApellidoMaterno="Pereira", Edad = 17, Genero="M", Nota1=5.1f, Nota2=6.2f, Nota3=1.1f, Promedio=2.3f},

        };

        [HttpGet]
        [Route("Alumno")]

        public IActionResult Listar(){

            try{

                if (DatosAlumnos != null){

                    for(int a=0; a < DatosAlumnos.Length; a++){

                        Console.WriteLine(DatosAlumnos[a]);

                        }
                        return StatusCode(200, DatosAlumnos);

                    }else{

                        return StatusCode(404, "No se encontraron los datos");

                }

            }catch(Exception){

                return StatusCode(401, "No se encontraron los datos");


            }

        }
        
        [HttpGet]
        [Route("Alumno/{id}")]

        public IActionResult ListarAlumno(int id){

            try{

                if(id > 0 && id <=DatosAlumnos.Length){

                    return StatusCode(200,DatosAlumnos[id-1]);


                }else{

                    return StatusCode(401,"No se ha encontrado el alumno");
                }

            }catch(Exception ex){

                return StatusCode(500, "Error interno por :"+ex);

            }

        }

      [HttpPost]
      [Route("Alumno")]

      public IActionResult Guarda([FromBody] Alumnos alumnos){

        try{

           // new Alumnos {Id=6, Nombre = "Pailita",ApellidoPaterno = "Peste", ApellidoMaterno="Porton", Edad = 14, Genero="M", Nota1=5.0f, Nota2=3.2f, Nota3=1.7f, Promedio=2.6f};

            return StatusCode(200, DatosAlumnos);

        }catch(Exception ex){

            return StatusCode(400, "No se pudo crear la persona por: "+ex);

        }


      } 

     [HttpPatch]
     [Route ("Alumno/{id}")]

     public IActionResult EditarAlumno(int id, [FromBody] Alumnos alumnos){

        try{

            if(id >0 && id == alumnos.Id){

                DatosAlumnos[id-1].Nombre=alumnos.Nombre;
                DatosAlumnos[id-1].ApellidoPaterno=alumnos.ApellidoPaterno;
                DatosAlumnos[id-1].ApellidoMaterno=alumnos.ApellidoMaterno;
                DatosAlumnos[id-1].Edad=alumnos.Edad;
                DatosAlumnos[id-1].Genero=alumnos.Genero;
                DatosAlumnos[id-1].Nota1 = alumnos.Nota1;
                DatosAlumnos[id-1].Nota2 = alumnos.Nota2;
                DatosAlumnos[id-1].Nota3 = alumnos.Nota3;
                DatosAlumnos[id-1].Promedio = alumnos.Promedio;

                return StatusCode(200, DatosAlumnos[id-1]);

            }else{

                return StatusCode(404, "Prueba otra vez...");

            }

        }catch(Exception ex){

            return StatusCode(500, "Error en el servidor por: "+ex);

        }

     }  

    [HttpDelete]
    [Route("Alumno/{id}")]

    public IActionResult ElimniarAlumno(int id){

        try{

            if(id >0 && id <= DatosAlumnos.Length){

                DatosAlumnos[id-1] = null;

                return StatusCode(200, "Se ha eliminado el registro , YEAH");

            }else{

                return StatusCode(401, "No se pudo borrar el registro pq no existe");

            }


        }catch(Exception ex){

            return StatusCode(500, "No se pudo borrar por: "+ex);

        }

    } 





        
    }

