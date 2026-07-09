// Código que se ejecuta
Espada frostmourne = new Espada {Nombre = "Frostmourne", Poder = 150};
Espada anduril = new Espada { Nombre = "Anduril", Poder = 120 };

Espada mejorEspada = ObtenerMasFuerte(frostmourne, anduril);

Console.WriteLine($"La espada con más poder es: {mejorEspada.Nombre}");

// Método genérico (esto no compila si no se hace el constrain, lol)
T ObtenerMasFuerte<T>(T primero, T segundo) where T: IConPoder 
{
    if(primero.Poder >= segundo.Poder)
        return primero;
    return segundo;
}
// Definiciones
interface IConPoder
{
    int Poder { get; }
}


class Espada : IConPoder
{
    public string Nombre { get; init; } = "";
    public int Poder { get; init; }
}
