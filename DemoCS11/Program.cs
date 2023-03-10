// Example 1: Raw string literals

using DemoCS11;
using System.Numerics;
using System.Text;

var Name = "Homer Simpson";
// Before C# 11
var sringMultiplesLines = 
                         @$"Hola,

                          mi nombre es ""{Name}"".
                            Esta línea está identada";

Console.WriteLine(sringMultiplesLines);

// With C# 11
var sringMultiplesLinesWithCS11 = $$"""
                                    Hola,
                                    mi nombre es "{{{Name}}}".
                                        Esta línea está identada
                                    """;
                         
Console.WriteLine(sringMultiplesLinesWithCS11);

// Example 2: Líneas en interpolación de strings

var temperature = 27;

string messaje = $"La sensación humana a la temperatura {temperature} es {temperature switch
{
    > 45 => "Muerte",
    > 35 => "Demasiado calor",
    > 25 => "Agradable",
    > -10 => "Frío",
    <= -10 => "Muerte"
}}";

Console.WriteLine(messaje);

// Example 3: Strings literal utf-8

var uft8BeforeCS11 = Encoding.UTF8.GetBytes("Hello");

var utf8WithCS11 = "Hello"u8.ToArray();

// Example 4: Patrones de listas

int[] numbers = { 1, 2, 3 };
var numbersString = ArregloAString(numbers);

var seEmparejan = numbers is [1, 2, 3];
var seEmparejan2 = numbers is [1, 2];
var seEmparejan3 = numbers is [1, 2, _];
var seEmparejan4 = numbers is [1, 2, > 2];

Console.WriteLine($"{numbersString} is [1, 2, 3]: " + seEmparejan);
Console.WriteLine($"{numbersString} is [1, 2]: " + seEmparejan2);
Console.WriteLine($"{numbersString} is [1, 2, _]: " + seEmparejan3);
Console.WriteLine($"{numbersString} is [1, 2, >2]: " + seEmparejan4);

string ArregloAString(int[] arreglo)
{
    StringBuilder sb = new StringBuilder();
    sb.Append("[");
    for (int i = 0; i < arreglo.Length; i++)
    {
        var item = arreglo[i];
        if (i + 1 == arreglo.Length)
        {
            sb.Append($"{item}");
        }
        else
        {
            sb.Append($"{item},");
        }
    }
    sb.Append("]");
    return sb.ToString();
}

// Ejemplo 5: Miembros requeridos

//var person = new Person(); //Error by required member

var person2 = new Person("Homer");

var person3 = new Person { Nombre = "Homer" };

// Ejemplo 6: Alcance file

//var utilidades = person2.UtilidadesPersona(); //Error por alcance file

var utilidades = person2.ObtenerValor();

// Ejemplo 9: Matemática genérica

int[] numerosEnteros = { 1, 2, 3 };

Complex[] numerosComplejos = { new Complex(2, 3), new Complex(4, 1) };

var resultadoNumerosEnteros = MatematicaGenerica.Sumar<int, int>(numerosEnteros);
Console.WriteLine("La suma de 1, 2 y 3 es " + resultadoNumerosEnteros);

var resultadoNumerosComplejos = MatematicaGenerica.Sumar<Complex, Complex>(numerosComplejos);
Console.WriteLine("La suma de 2+3i + 4+i es " + resultadoNumerosComplejos);
