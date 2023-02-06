using System;
using System.Collections.Generic;

namespace EstructurasDatos.Pilas
{
    public class Pila<T> where T : IComparable
    {
        public T Dato;
        public Pila<T> Anterior;
        private bool vacia = true;

        public Pila()
        {
            vacia = true;
        }

        public Pila(T dato)
        {
            vacia = false;
            Dato = dato;
        }

        virtual public Pila<T> Insertar(T dato)
        {
            if (vacia)
            {
                Dato = dato;
                vacia = false;
                return this;
            }
            else
            {
                var nuevo = new Pila<T>(dato);
                nuevo.Anterior = this;
                return nuevo;
            }
        }

        virtual public Pila<T> InsertarMultiple(List<T> datos)
        {
            Pila<T> tmp = this;
            foreach (T dato in datos)
                tmp = tmp.Insertar(dato);
            return tmp;
        }

        virtual public Pila<T> Sacar(out T retCola)
        {
            if (EstaVacia())
            {
                retCola = default;
                return null;
            }
            retCola = this.Dato;
            if (this.Anterior == null)
            {
                this.vacia = true;
                return this;
            }
            return this.Anterior;
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
                tmp = tmp.Anterior;
            }

            return str.Remove(str.Length - 1);
        }

        public bool EstaVacia()
        {
            return vacia;
        }
    }
}
