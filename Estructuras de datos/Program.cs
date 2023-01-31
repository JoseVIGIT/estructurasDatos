using System;

using EstructurasDatos.Arboles;
public class Programa
{
    public static void Main()
    {
        #region arbol numérico T = int
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
        Console.WriteLine("Arbol con enteros:     {0}\n  Min: {1}\n   Max: {2}", 
            arbol.RecorrerArbol(), arbol.Min(), arbol.Max());
        #endregion

        #region arbol caracter T = char
        ArbolBinario<char> arbol2 = new ArbolBinario<char>('E');
        #region Añadir datos al arbol
        arbol2.InsertarEnArbol('C');
        arbol2.InsertarEnArbol('D');
        arbol2.InsertarEnArbol('B');
        arbol2.InsertarEnArbol('A');
        arbol2.InsertarEnArbol('H');
        arbol2.InsertarEnArbol('I');
        arbol2.InsertarEnArbol('F');
        arbol2.InsertarEnArbol('G');
        #endregion
        Console.WriteLine("Arbol con caracteres:  {0}\n   Min: {1}\n   Max: {2}", 
            arbol2.RecorrerArbol(), arbol2.Min(), arbol2.Max());
        #endregion

        #region arbol cadenas T = string
        ArbolBinario<string> arbol3 = new ArbolBinario<string>("Bueno");
        #region Añadir datos al arbol
        arbol3.InsertarEnArbol("Adios");
        arbol3.InsertarEnArbol("Calor");
        arbol3.InsertarEnArbol("Almendra");
        arbol3.InsertarEnArbol("Día");
        #endregion
        Console.WriteLine("Arbol con cadenas:     {0}\n   Min: {1}\n   Max: {2}", 
            arbol3.RecorrerArbol(), arbol3.Min(), arbol3.Max());
        #endregion

        Console.WriteLine();

        #region arbolAVL numérico T = int
        ArbolBinarioAVL<int> arbol4 = new ArbolBinarioAVL<int>(5);
        #region Añadir datos al arbol
        arbol4.InsertarEnArbol(3);
        arbol4.InsertarEnArbol(4);
        arbol4.InsertarEnArbol(2);
        arbol4.InsertarEnArbol(1);
        arbol4.InsertarEnArbol(8);
        arbol4.InsertarEnArbol(9);
        arbol4.InsertarEnArbol(6);
        arbol4.InsertarEnArbol(7);
        #endregion
        Console.WriteLine("ArbolAVL con enteros:  {0}\n   Min: {1}\n   Max: {2}", 
            arbol4.RecorrerArbol(), arbol4.Min(), arbol4.Max());
        #endregion

        Console.WriteLine();
    }
}

