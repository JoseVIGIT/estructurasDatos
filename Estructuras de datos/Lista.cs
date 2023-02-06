using EstructurasDatos.Colas;
using System;
using System.Collections.Generic;

namespace EstructurasDatos.Listas
{
    public class Nodo<T>
    {
        public T Dato;
        public Nodo<T> Anterior, Siguiente;
    }

    public class Lista<T> where T : IComparable
    {
        public Nodo<T> primero, ultimo;
        private bool vacia = true;

        public Lista()
        {
            vacia = true;
            primero = ultimo = null;
        }

        public Lista(T dato)
        {
            Insertar(dato);
        }

        public Lista(List<T> datos)
        {
            InsertarMultiple(datos);
        }

        virtual public Lista<T> Insertar(T dato)
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
                nod.Anterior = ultimo;
                ultimo.Siguiente = nod;
                ultimo = ultimo.Siguiente;
            }
            return this;
        }

        virtual public Lista<T> InsertarMultiple(List<T> datos)
        {
            foreach (T dato in datos)
                Insertar(dato);
            return this;
        }

        virtual public bool Buscar(T dato, out T resultado)
        {
            if (EstaVacia())
            {
                resultado = default;
                return false;
            }
            var nodoTmp = primero;
            while (nodoTmp != null && !nodoTmp.Dato.Equals(dato))
            {
                nodoTmp = nodoTmp.Siguiente;
            }
            if (nodoTmp == null)
            {
                resultado = default;
                return false;
            }
            resultado = nodoTmp.Dato;
            return true;
        }
        
        virtual public T Eliminar(T dato)
        {
            if (EstaVacia())
                return default;
            
            var nodoTmp = primero;
            while (nodoTmp != null && !nodoTmp.Dato.Equals(dato))
            {
                nodoTmp = nodoTmp.Siguiente;
            }
            if (nodoTmp == null)
                return default;
            else
            {
                if (nodoTmp.Anterior == null && nodoTmp.Siguiente == null)
                {
                    primero = ultimo = null;
                    vacia = true;
                }
                else
                {
                    if (nodoTmp.Anterior != null && nodoTmp.Siguiente != null)
                    {
                        nodoTmp.Anterior.Siguiente = nodoTmp.Siguiente;
                        nodoTmp.Siguiente.Anterior = nodoTmp.Anterior;
                    }
                    else
                    {
                        if (nodoTmp.Anterior == null)
                        {
                            nodoTmp.Siguiente.Anterior = null;
                            primero = nodoTmp.Siguiente;
                        }
                        else
                            nodoTmp.Anterior.Siguiente = null;
                    }
                }
            }
            return nodoTmp.Dato;
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

        virtual public T Min()
        {
            var min = primero;
            var tmp = primero;
            while (tmp != null)
            {
                if (min.Dato.CompareTo(tmp.Dato) > 0)
                    min = tmp;
                tmp = tmp.Siguiente;
            }
            return (min.Dato);
        }

        virtual public T Max()
        {
            var min = primero;
            var tmp = primero;
            while (tmp != null)
            {
                if (min.Dato.CompareTo(tmp.Dato) < 0)
                    min = tmp;
                tmp = tmp.Siguiente;
            }
            return (min.Dato);
        }

    }
}