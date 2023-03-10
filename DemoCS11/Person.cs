using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DemoCS11
{
    internal class Person
    {
        public Person()
        {

        }

        [SetsRequiredMembers]
        public Person(string nombre)
        {
            Nombre = nombre;
        }

        public required string? Nombre { get; init; }

        public int ObtenerValor()
        {
            var utilidades = new UtilidadesPersona();
            return utilidades.ObtenerValor;
        }

        [MiAtributo<string>(nameof(miParametro2), "Homer")]
        public void MetodoConParametros(string miParametro2)
        {

        }

        [MiAtributo<int>(nameof(miParametro2), 42)]
        public void MetodoConParametros2(string miParametro2)
        {

        }
    }

    // Ejemplo 6: Alcance file
    file class UtilidadesPersona
    {
        public int ObtenerValor => 42;
    }

    // Ejemplo 8: Alcance aumentado de nameof

    file class MiAtributo<T> : Attribute
    {
        public MiAtributo(string parametro, T valorGenerico)
        {
            Parametro = parametro;
            ValorGenerico = valorGenerico;
        }

        public string Parametro { get; }
        public T ValorGenerico { get; }
    }

    public class MatematicaGenerica
    {
        public static TResult Sumar<T, TResult>(IEnumerable<T> valores)
        where T : INumberBase<T>
        where TResult : INumberBase<TResult>
        {
            TResult resultado = TResult.Zero;

            foreach (var valor in valores)
            {
                resultado += TResult.CreateChecked(valor);
            }

            return resultado;
        }
    }
}
