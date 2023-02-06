using System;
using System.Collections.Generic;

using EstructurasDatos.Colas;
using EstructurasDatos.Pilas;
using EstructurasDatos.Listas;
using EstructurasDatos.Arboles;

/// <summary>
/// Demo de estructuras de control clásicas implementadas desde cero
/// No se pretende utilizar las existentes en System.Collections.Generic (queue, stack, list)
/// No se pretende implementar una funcionalidad completa de las estructuras ni un control completo de causísticas
/// La idea es implementar la funcionalidad básica de este tipo de estructuras
/// para comprender el funcionamiento interno de estos elementos
/// </summary>
public class Programa
{
    public static void testCola()
    {
        char dato = 'A';
        List<char> datos = new List<char>{ 'B', 'C', 'D' };
        Cola<char> cola = new Cola<char>(datos).Insertar(dato);
        Console.WriteLine("Insertado     : {0},{1}", String.Join(",", datos.ToArray()), dato);
        Console.WriteLine("Cola inicial  : {0}", cola);

        while (!cola.EstaVacia())
        {
            dato = cola.Sacar();
            Console.WriteLine("   Elemento sacado {0} - quedan {1}", dato, cola);
        }
        Console.WriteLine("   Estruct. vacia {0}", cola.EstaVacia());
        Console.WriteLine();
    }

    public static void testPila()
    {
        int dato = 1;
        List<int> datos = new List<int> { 2, 3, 4};
        Pila<int> pila = new Pila<int>(datos).Insertar(dato);
        Console.WriteLine("Insertado     : {0},{1}", String.Join(",", datos.ToArray()), dato);
        Console.WriteLine("Pila inicial  : {0}", pila);

        while (!pila.EstaVacia())
        {
            dato = pila.Sacar();
            Console.WriteLine("   Elemento sacado {0} - quedan {1}", dato, pila);
        }
        dato = pila.Sacar();
        Console.WriteLine("   Estruct. vacia {0}", pila.EstaVacia());
        Console.WriteLine();
    }

    public static void testLista()
    {
        string dato = "ACD";
        List<string> datos = new List<string> { "BCD", "CCD", "DCD" };
        Lista<string> lista = new Lista<string>(datos).Insertar(dato);
        Console.WriteLine("Insertado     : {0},{1}", String.Join(",", datos.ToArray()), dato);
        Console.WriteLine("Lista inicial : {0}", lista);

        Console.WriteLine("   Min: {0} , Max: {1}", lista.Min(), lista.Max());
        string valEliminar = "", valBuscado = "", valBusRes = "";
        bool encontrado = false;
        valBuscado = "CCD"; encontrado = lista.Buscar(valBuscado, out valBusRes);
        Console.WriteLine("   Elemento buscado {0} - {1,-5} - {2}", valBuscado, encontrado, lista);
        valBuscado = "XCD"; encontrado = lista.Buscar(valBuscado, out valBusRes);
        Console.WriteLine("   Elemento buscado {0} - {1,-5} - {2}", valBuscado, encontrado, lista);
        valEliminar = "DCD"; lista.Eliminar(valEliminar); Console.WriteLine("   Elemento sacado  {0} - {1}", valEliminar, lista);
        valEliminar = "BCD"; lista.Eliminar(valEliminar); Console.WriteLine("   Elemento sacado  {0} - {1}", valEliminar, lista);
        valEliminar = "ACD"; lista.Eliminar(valEliminar); Console.WriteLine("   Elemento sacado  {0} - {1}", valEliminar, lista);
        valEliminar = "CCD"; lista.Eliminar(valEliminar); Console.WriteLine("   Elemento sacado  {0} - {1}", valEliminar, lista);
        Console.WriteLine();
    }

    public static void testArbol()
    {
        int dato = 1;
        int valBuscado = 5;
        int valEliminar = 5;
        List<int> datos = new List<int> { 5, 3, 4, 2, 8, 9, 6, 7 };
        ArbolBinario<int> arbol = new ArbolBinario<int>().InsertarMultiple(datos);
        arbol = arbol.Insertar(dato);
        Console.WriteLine("Insertado     : {0},{1}", String.Join(",", datos.ToArray()), dato);
        Console.WriteLine("Arbol inicial : {0}", arbol);

        Console.WriteLine("   Min: {0} , Max: {1}", arbol.Min().Dato, arbol.Max().Dato);
        var nodoBuscado = arbol.BuscarNodo(valBuscado);
        Console.WriteLine("   Elemento buscado {0} - {1}", valBuscado, (nodoBuscado != null) ? nodoBuscado.Dato + " - Encontrado" : "No encontrado");
        arbol = arbol.Eliminar(valEliminar);
        Console.WriteLine("   Elemento elimina {0} - {1}", valEliminar,arbol);
        valBuscado = valEliminar; 
        nodoBuscado = arbol.BuscarNodo(valBuscado);
        Console.WriteLine("   Elemento buscado {0} - {1}", valBuscado, (nodoBuscado != null) ? nodoBuscado.Dato + " - Encontrado" : "No encontrado");
        Console.WriteLine();
    }

    public static void Main()
    {
        testCola();
        testPila();
        testLista();
        testArbol();
    }
}

