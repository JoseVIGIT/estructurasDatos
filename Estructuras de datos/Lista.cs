using System;
using System.Collections.Generic;

namespace EstructurasDatos.Listas
{
    public class Lista<T> where T : IComparable
    {
        public T Dato;
        public Lista<T> Anterior, Siguiente;
        private bool vacia = true;

        public Lista()
        {
            vacia = true;
        }

        public Lista(T dato)
        {
            Dato = dato;
            vacia = false;
        }

        virtual public Lista<T> Insertar(T dato)
        {
            if (vacia)
            {
                Dato = dato;
                vacia = false;
            }
            else
            {
                if (Siguiente != null)
                {
                    Siguiente.Insertar(dato);
                }
                else
                {
                    Siguiente = new Lista<T>(dato);
                    Siguiente.Anterior = this;
                }
            }
            return this;
        }

        virtual public Lista<T> InsertarMultiple(List<T> datos)
        {
            Lista<T> tmp = this;
            foreach (T dato in datos)
                tmp = tmp.Insertar(dato);
            return tmp;
        }

        virtual public Lista<T> Buscar(T dato)
        {
            if (EstaVacia())
                return this;
            var tmp = this;
            while (tmp != null && !tmp.Dato.Equals(dato))
            {
                tmp = tmp.Siguiente;
            }
            return tmp;
        }

        virtual public Lista<T> Eliminar(T dato)
        {
            var tmp = Buscar(dato);
            if (tmp != null)
            {
                if (tmp.Siguiente == null && tmp.Anterior == null)
                {
                    Dato = default;
                    vacia = true;
                }
                else
                {
                    tmp.Anterior.Siguiente = tmp.Siguiente;
                    tmp.Siguiente.Anterior = tmp.Anterior;
                }
            }
            return this;
        }

        public Lista<T> Min()
        {
            var min = this;
            var tmp = this;
            while (tmp != null)
            {
                if (min.Dato.CompareTo(tmp.Dato) > 0)
                    min = tmp;
                tmp = tmp.Siguiente;
            }
            return (min);
        }

        public Lista<T> Max()
        {
            var min = this;
            var tmp = this;
            while (tmp != null)
            {
                if (min.Dato.CompareTo(tmp.Dato) < 0)
                    min = tmp;
                tmp= tmp.Siguiente;
            }
            return (min);
        }

        public override string ToString()
        {
            var tmp = this;
            var str = "";
            if (tmp.EstaVacia())
            {
                return "";
            }
            while (tmp != null)
            {
                str += tmp.Dato + ",";
                tmp = tmp.Siguiente;
            }
            return str.Remove(str.Length - 1);
        }

        public bool EstaVacia()
        {
            return vacia;
        }
    }
}
