using System;

namespace EstructurasDatos.Pilas
{
    public class Pila<T> where T : IComparable
    {
        public T Dato;
        public Pila<T> Anterior;
        public Pila(T dato)
        {
            Dato = dato;
        }

        virtual public Pila<T> Insertar(T dato) 
        {
            var nuevo = new Pila<T>(dato);
            nuevo.Anterior = this;
            return nuevo;
        }

        virtual public Pila<T> Sacar(out T retCola) 
        {
            retCola = this.Dato;
            return this.Anterior;
        }

        public override string ToString() 
        {
            var tmp = this;
            var str = "";
            while (tmp != null)

            {
                str += tmp.Dato + ",";
                tmp = tmp.Anterior;
            }

            return str.Remove(str.Length - 1);
        }
    }
}
