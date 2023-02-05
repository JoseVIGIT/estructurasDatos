using EstructurasDatos.Pilas;
using System;
using System.Collections.Generic;

namespace EstructurasDatos.Colas
{
    public class Cola<T> where T : IComparable
    {
        public T Dato;
        public Cola<T> Siguiente;
        private bool vacia = true;

        public Cola()
        {
            vacia = true;
        }

        public Cola(T dato)
        {
            vacia = false;
            Dato = dato;
        }

        virtual public Cola<T> Insertar(T dato)
        {
            if (vacia)
            {
                Dato = dato;
                vacia = false;
            }
            else
            {
                if (Siguiente != null)
                    Siguiente.Insertar(dato);
                else
                    Siguiente = new Cola<T>(dato);
            }
            return this;
        }

        virtual public Cola<T> InsertarMultiple(List<T> datos)
        {
            Cola<T> tmp = this;
            foreach (T dato in datos)
                tmp = tmp.Insertar(dato);
            return tmp;
        }
        
        virtual public Cola<T> Sacar(out T retCola)
        {
            retCola = this.Dato;
            return this.Siguiente;
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
