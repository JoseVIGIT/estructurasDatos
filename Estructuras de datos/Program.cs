using System;

using EstructurasDatos.Colas;
using EstructurasDatos.Pilas;
using EstructurasDatos.Listas;
using EstructurasDatos.Arboles;

public class Programa
{
    public static void testCola()
    {
        #region cola T = char
        Cola<char> cola = new Cola<char>((char)(64 + 1));
        char dato;
        Console.Write("Insertado     : A,");
        for (int i = 2; i < 5; i++)
        {
            cola.Insertar((char)(64 + i));
            Console.Write("{0},", (char)(64 + i));
        }
        Console.WriteLine();
        Console.WriteLine("Cola inicial  : {0}", cola);
        while (cola != null)
        {
            cola = cola.Sacar(out dato);
            Console.WriteLine("   Elemento sacado {0} - quedan {1}", dato, cola);
        }
        #endregion
        Console.WriteLine();
    }

    public static void testPila()
    {
        #region pila T = int
        Pila<int> pila = new Pila<int>(1);
        int datoPila;
        Console.Write("Insertado     : 1,");
        for (int i = 2; i < 5; i++)
        {
            pila = pila.Insertar(i);
            Console.Write("{0},", i);
        }
        Console.WriteLine();
        Console.WriteLine("Pila inicial  : {0}", pila);
        while (pila != null)
        {
            pila = pila.Sacar(out datoPila);
            Console.WriteLine("   Elemento sacado {0} - quedan {1}", datoPila, pila);
        }
        #endregion
        Console.WriteLine();
    }

    public static void testLista()
    {
        #region lista T = int
        Lista<string> lista = new Lista<string>("ZCD");
        Console.Write("Insertado     : ZCD,");
        for (int i = 2; i < 6; i++)
        {
            lista.Insertar((char)(64 + i) + "CD");
            Console.Write("{0},", (char)(64+i)+"CD");
        }
        Console.WriteLine();
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
        #endregion
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
        testArbol();
    }
}

