//Declaramos el nuevo controlador
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using PrimeraApi;

public class ElTiempo:ControllerBase
{   
    //declaramos las propiedades

    DateOnly fecha { get; set; }
    double temp { get; set; }
    string sumario { get; set; }

    //declaramos el array de string


     public static readonly string[] Tiempo = new[]
    {
        "Muy Frio", "Caluroso", "Despejado", "Agradable", "Lluvioso", "Nublado", "Tormentoso", "Ventoso", "Humedo", "Seco"
    };

     private readonly ILogger<ElTiempo> _logger;

    public ElTiempo(ILogger<ElTiempo> logger)
    {
        _logger = logger;
    }

    //declaramo el metodo get
    [HttpGet(Name = "GetTiempo")]
    public IEnumerable<ElTiempos> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new ElTiempos
        {
            fecha = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            temp = Random.Shared.Next((int)20.1 , (int)55.8),
            sumario = Tiempo[Random.Shared.Next(Tiempo.Length)]
        })
        .ToArray();
    }




}