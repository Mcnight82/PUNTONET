//creamos el controlador de la api para el modelo Eltpo
using Microsoft.AspNetCore.Mvc;

namespace SegundaApi.Controllers;

[ApiController]
[Route("[controller]")]

public class EltpoController : ControllerBase{



    private static readonly String[] resumenes = new []{

        "Helado_Juan", "Mas Caliente", "Ta helao afuera", "Fresco", "Templado", "Calido", "Agradable",
         "Caliente!", "Abochornado", "Brasero!!!"


    };

    [HttpGet("Eltpo1")]
    public IEnumerable<Eltpo> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Eltpo
        {
            Fecha = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TempC = Random.Shared.Next(-20, 55),
            Resumen = resumenes[Random.Shared.Next(resumenes.Length)]
        })
        .ToArray();
    }




}