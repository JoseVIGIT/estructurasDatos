using EstructurasDatos.Pilas;
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
            Anterior = null;
            Siguiente = null;
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
                tmp.Anterior.Siguiente = tmp.Siguiente;
                tmp.Siguiente.Anterior = tmp.Anterior;
            }
            return this;
        }

        public override string ToString()
        {
            var tmp = this;
            var str = "";
            while (tmp != null)
            {
                str += tmp.Dato + ",";
                tmp = tmp.Siguiente;
            }
            return str.Remove(str.Length - 1);
        }
    }
}
