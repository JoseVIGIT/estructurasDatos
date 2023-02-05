using System;

namespace EstructurasDatos.Listas
{
    public class Lista<T> where T : IComparable
    {
        public T Dato;
        public Lista<T> Anterior, Siguiente;

        public Lista(T dato)
        {
            Dato = dato;
            Anterior = null;
            Siguiente = null;
        }

        virtual public void Insertar(T dato)
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
