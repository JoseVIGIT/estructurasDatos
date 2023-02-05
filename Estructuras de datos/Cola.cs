using System;

namespace EstructurasDatos.Colas
{
    public class Cola<T> where T : IComparable
    {
        public T Dato;
        public Cola<T> Siguiente;

        public Cola(T dato)
        {
            Dato = dato;
        }

        virtual public void Insertar(T dato)
        {
            if (Siguiente != null)
            {
                Siguiente.Insertar(dato);
            } 
            else
                Siguiente = new Cola<T>(dato);
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
