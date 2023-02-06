using System;
using System.Collections.Generic;

namespace EstructurasDatos.Colas
{
    public class Nodo<T>
    {
        public T Dato;
        public Nodo<T> Siguiente;
    }

    public class Cola<T> where T : IComparable
    {
        //Nodo<T> ultimo ... Añadido para agilizar la inserción sin tener que recorrer toda la cola
        //Nodo<T> primero ... es el elemento que se usará para recorrer la cola sacando elementos en orden adecuado
        public Nodo<T> primero, ultimo; 
        private bool vacia = true;

        public Cola()
        {
            vacia = true;
            primero = ultimo = null;
        }

        public Cola(T dato)
        {
            Insertar(dato);
        }

        public Cola(List<T> datos)
        {
            InsertarMultiple(datos);
        }

        virtual public Cola<T> Insertar(T dato)
        {
            var nod = new Nodo<T>();
            nod.Dato = dato;
            nod.Siguiente = null; 
            if (vacia)
            {
                vacia = false;
                primero = ultimo = nod;
            }
            else
            {
                ultimo.Siguiente = nod;
                ultimo = ultimo.Siguiente;
            }
            return this;
        }

        virtual public Cola<T> InsertarMultiple(List<T> datos)
        {
            foreach (T dato in datos)
                Insertar(dato);
            return this;
        }
        
        virtual public T Sacar()
        {
            if (EstaVacia())
                return default;
            var primeroTmp = primero;
            if (primero.Siguiente != null)
                primero = primero.Siguiente;
            else
            {
                primero = ultimo = null;
                vacia = true;
            }
            return primeroTmp.Dato;
        }

        public override string ToString()
        {
            if (EstaVacia())
                return "";
            var str = "";
            var nodoTmp = primero;
            while (nodoTmp != null) 
            {
                str += nodoTmp.Dato + ",";
                nodoTmp = nodoTmp.Siguiente;
            }
            return str.Remove(str.Length - 1);
        }

        public bool EstaVacia()
        {
            return vacia;
        }
    }
}
