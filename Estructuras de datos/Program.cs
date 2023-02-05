using System;

using EstructurasDatos.Colas;
using EstructurasDatos.Pilas;
using EstructurasDatos.Listas;
using EstructurasDatos.Arboles;
using System.Collections.Generic;

public class Programa
{
    public static void testCola()
    {
        char dato = 'E';
        List<char> datos = new List<char>{ 'A', 'B', 'C', 'D' };
        Cola<char> cola = new Cola<char>().InsertarMultiple(datos);
        cola = cola.Insertar(dato);
        Console.WriteLine("Insertado     : {0},{1}", String.Join(",", datos.ToArray()), dato);
        Console.WriteLine("Cola inicial  : {0}", cola);
        while (cola != null)
        {
            cola = cola.Sacar(out dato);
            Console.WriteLine("   Elemento sacado {0} - quedan {1}", dato, cola);
        }
        Console.WriteLine();
    }

    public static void testPila()
    {
        int dato = 5;
        List<int> datos = new List<int> { 1, 2, 3, 4};
        Pila<int> pila = new Pila<int>().InsertarMultiple(datos);
        pila = pila.Insertar(dato);
        Console.WriteLine("Insertado     : {0},{1}", String.Join(",", datos.ToArray()), dato);
        Console.WriteLine("Pila inicial  : {0}", pila);
        while (pila != null)
        {
            pila = pila.Sacar(out dato);
            Console.WriteLine("   Elemento sacado {0} - quedan {1}", dato, pila);
        }
        Console.WriteLine();
    }

    public static void testLista()
    {
        string dato = "ACD";
        List<string> datos = new List<string> { "BCD", "CCD", "DCD", "ECD" };
        Lista<string> lista = new Lista<string>().InsertarMultiple(datos);
        lista = lista.Insertar(dato);
        Console.WriteLine("Insertado     : {0},{1}", String.Join(",", datos.ToArray()), dato);
        Console.WriteLine("Lista inicial : {0}", lista);

        string valBuscado = "CCD";
        string valEliminar = "CCD";
        var nodoBuscado = lista.Buscar(valBuscado);
        Console.WriteLine("   Elemento buscado {0} ==> {1}", valBuscado, (nodoBuscado != null) ? nodoBuscado.Dato + " - Encontrado" : "No encontrado");
        lista = lista.Eliminar(valEliminar);
        Console.Write("   Elemento elimina {0} ==> ", valEliminar); Console.WriteLine(lista);
        valBuscado = valEliminar;
        nodoBuscado = lista.Buscar(valBuscado);
        Console.WriteLine("   Elemento buscado {0} ==> {1}", valBuscado, (nodoBuscado != null) ? nodoBuscado.Dato + " - Encontrado" : "No encontrado");
        Console.WriteLine();
    }

    public static void testArbol()
    {
        #region arbol T = int
        ArbolBinario<int> arbol = new ArbolBinario<int>(5);
        #region Añadir datos al arbol
        arbol.InsertarEnArbol(3);
        arbol.InsertarEnArbol(4);
        arbol.InsertarEnArbol(2);
        arbol.InsertarEnArbol(1);

        arbol.InsertarEnArbol(8);
        arbol.InsertarEnArbol(9);
        arbol.InsertarEnArbol(6);
        arbol.InsertarEnArbol(7);
        #endregion
        Console.WriteLine("Insertado     : 5,3,4,2,1,8,9,6,7,");
        Console.WriteLine("Arbol inicial : {0}", arbol.RecorrerArbol());
        Console.WriteLine("   Min: {0} , Max: {1}", arbol.Min().Dato, arbol.Max().Dato);
        int valBuscado = 5;
        int valEliminar = 5;
        var nodoBuscado = arbol.BuscarNodo(valBuscado);
        Console.WriteLine("   Elemento buscado {0} ==> {1}", valBuscado, (nodoBuscado != null) ? nodoBuscado.Dato + " - Encontrado" : "No encontrado");
        arbol = arbol.Eliminar(valEliminar);
        Console.Write("   Elemento elimina {0} ==> ", valEliminar); Console.WriteLine(arbol.RecorrerArbol());
        valBuscado = valEliminar;
        nodoBuscado = arbol.BuscarNodo(valBuscado);
        Console.WriteLine("   Elemento buscado {0} ==> {1}", valBuscado, (nodoBuscado != null) ? nodoBuscado.Dato + " - Encontrado" : "No encontrado");
        #endregion
        Console.WriteLine();
    }

    public static void Main()
    {
        testCola();
        testPila();
        testLista();
        /*
        testArbol();
        */
    }
}

