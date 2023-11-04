using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonasMant.Models;

namespace PersonasMant.Controllers;

public class PersonasController : Controller{

    private readonly IHttpClientFactory _clientFactory;

    public PersonasController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }


    public async Task<IActionResult> BuscaPersona()
    {
        
        var client = _clientFactory.CreateClient("PersonasAPI");
        var response = await client.GetAsync("http://localhost:5217/Persona");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var personas = JsonConvert.DeserializeObject<List<Persona>>(jsonString);
            return View(personas);
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, errorContent);
        }

    }

    //creamos el método que nos traerá una persona por su id
    public async Task<IActionResult> BuscaId(int id)
    {
        var client = _clientFactory.CreateClient("PersonasAPI");
        var response = await client.GetAsync($"http://localhost:5217/Persona/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var persona = JsonConvert.DeserializeObject<Persona>(jsonString);
            return View(persona);
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, errorContent);
        }

    }

    //creamos el método que nos permitirá crear una nueva persona
    public IActionResult CreaPersona()
    {

        return View();
        
    }

    [HttpPost]
    public async Task<IActionResult> NuevaPersona(Persona persona)
    {

            var client = _clientFactory.CreateClient("PersonasAPI");
            var json = JsonConvert.SerializeObject(persona);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5217/Persona", content);

            if (response.IsSuccessStatusCode)
            {
                //retornamos un mensaje de confirmación
                return RedirectToAction("CreaPersona");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, errorContent);
            
            }

    }

    public IActionResult EditarPersona(int id){

        return View();
    }

    //creamos el metodo que nos permitirá editar una persona
    public async Task<IActionResult> EditaPersona(int id)
    {
        var client = _clientFactory.CreateClient("PersonasAPI");
        var response = await client.GetAsync($"http://localhost:5217/Persona/{id}");

        if (response.IsSuccessStatusCode)
        {
            //traemos los datos del formulario
           /* var NombPersona = Request.Form["NombrePersona"];
            var ApePat = Request.Form["ApellidoPat"];
            var ApeMat = Request.Form["ApellidoMat"];
            string EdadPers = Request.Form["EdadPersona"];
            int Edad = int.Parse(EdadPers);

            string FechaNa = Request.Form["FechaNac"];
            DateTime FechaNac = DateTime.Parse(FechaNa);

            var Genero = Request.Form["GeneroPersona"];
            
           // var persona = new Persona { NombrePersona = Request.Form["NombrePersona"], ApellidoPat = Request.Form["ApellidoPat"], ApellidoMat = Request.Form["ApellidoMat"], EdadPersona = Request.Form["EdadPersona"], FechaNac = FechaNac, GeneroPersona = Genero};
            
            var json = JsonConvert.SerializeObject(persona);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var respuesta = await client.PutAsync($"http://localhost:5217/Persona/{id}", content);*/

            return RedirectToAction("BuscaPersona");
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, errorContent);
        }


    }

    
    //creamos el método que nos permitirá eliminar una persona
    public async Task<IActionResult> EliminaPersona(int id)
    {
        var client = _clientFactory.CreateClient("PersonasAPI");
        var response = await client.DeleteAsync($"http://localhost:5217/Persona/{id}");

        if (response.IsSuccessStatusCode)
        {
            //retornamos un mensaje de confirmación
            return RedirectToAction("BuscaPersona");
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, errorContent);
        }

    }


}
        

