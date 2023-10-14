namespace SegundaApi;

public class Eltpo
{

    public DateOnly Fecha { get; set; }

    public int TempC { get; set; }

    public int TempF => 32 + (int)(TempC / 0.5556);

    public string? Resumen { get; set; }


}
