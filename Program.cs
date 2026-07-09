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

Console.WriteLine();
Console.WriteLine("--- Constrains class, struct y new() ---");

// 1. where T : class  → la caché puede devolver null cuando no encuentra
// el constrain class es para referencias como Clases y strings 
CacheDeReferencia<Jugador> cache = new CacheDeReferencia<Jugador>();
Jugador? resultado = cache.Obtener();
Console.WriteLine($"La caché arranca con : {(resultado is null ? "null (vacía)" : "hay algo")}");


// 2. where T : struct  → solo acepta tipos por valor
Console.WriteLine($"¿42 tiene valor? {TieneValor(42)}"); 
Console.WriteLine($"¿true tiene valor? {TieneValor(true)}");

bool TieneValor<T> (T dato) where T : struct
{
    return true;
}

// 3. where T : new()  → la fábrica puede hacer new T() por su cuenta
Fabrica<Enemigo> fabricaDeEnemigos = new Fabrica<Enemigo>();
Enemigo enemigoNuevo = fabricaDeEnemigos.Crear();
Console.WriteLine($"Enemigo recién fabricado: {enemigoNuevo.Nombre} con {enemigoNuevo.Vida} de vida");

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

///////////////////////////////////////////////////////////////////////////////////////
// Definiciones de class, struct y new() acá

//1. where T : class  → T tiene que ser un tipo por referencia
class CacheDeReferencia<T> where T : class
{
    private T? guardado;

    public T? Obtener() => guardado; // Puede devolver null porque T es una referencia
    public void Guardar( T valor ) => guardado = valor;
}

//3.  where T : new()  → T tiene que tener constructor sin parámetros
class Fabrica<T> where T : new()
{
    public T Crear() => new T();
}


// Definiciones de tipos

class Jugador
{
    public string Nombre { get; init; } = "";

}

class Enemigo
{
    public string Nombre { get; set; } = "Slime";
    public int Vida { get; set; } = 20;
}
///////////////////////////////////////////////////////////////////////////////////////