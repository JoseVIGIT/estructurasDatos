using System;
using System.Collections.Generic;

namespace EstructurasDatos.Pilas
{
    public class Nodo<T>
    {
        public T Dato;
        public Nodo<T> Anterior;
    }

    public class Pila<T> where T : IComparable
    {
        public Nodo<T> nodo;
        private bool vacia = true;

        public Pila()
        {
            vacia = true;
            nodo = null;
        }

        public Pila(T dato)
        {
            Insertar(dato);
        }

        public Pila(List<T> datos)
        {
            InsertarMultiple(datos);
        }

        virtual public Pila<T> Insertar(T dato)
        {
            var nod = new Nodo<T>();
            nod.Dato = dato;
            nod.Anterior = null;
            if (vacia)
            {
                vacia = false;
                nodo = nod;
            }
            else
            {
                nod.Anterior = nodo;
                nodo = nod;
            }
            return this;
        }

        virtual public Pila<T> InsertarMultiple(List<T> datos)
        {
            foreach (T dato in datos)
                Insertar(dato);
            return this;
        }

        virtual public T Sacar()
        {
            if (EstaVacia())
                return default;
            var nodoTmp = nodo;
            if (nodo.Anterior != null)
                nodo = nodo.Anterior;
            else
            {
                nodo = null;
                vacia = true;
            }
            return nodoTmp.Dato;
        }

        public override string ToString()
        {
            if (EstaVacia())
                return "";
            var str = "";
            var nodoTmp = nodo;
            while (nodoTmp != null)
            {
                str += nodoTmp.Dato + ",";
                nodoTmp = nodoTmp.Anterior;
            }

            return str.Remove(str.Length - 1);
        }

        public bool EstaVacia()
        {
            return vacia;
        }
    }
}
