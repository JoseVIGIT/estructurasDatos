using System;
using System.Collections.Generic;

namespace EstructurasDatos.Arboles
{
	public class ArbolBinario<T> where T : IComparable
	{
		public T Dato { get; set; }
		public ArbolBinario<T> Padre, Izquierda, Derecha;
		private bool vacia = true;

		public ArbolBinario ()
		{
            vacia = true;
		}
		
		public ArbolBinario(T dato)
		{
			Dato = dato;
			vacia = false;
		}

		virtual public ArbolBinario<T> BuscarNodo (T nodo)
		{
			ArbolBinario<T> nodoRet = null;
			switch (nodo.CompareTo(Dato))
			{
				case 0:
					nodoRet=this;
					break;
				case -1:
					if (Izquierda != null)
                        nodoRet=(Izquierda.BuscarNodo(nodo));
					break;
				case 1:
					if (Derecha != null)
                        nodoRet = (Derecha.BuscarNodo(nodo));
					break;
            }
			return nodoRet;

        }

		virtual public ArbolBinario<T> Insertar(T dato)
		{
			if (vacia)
			{
				Dato = dato;
				vacia = false;
			}
			else
			{
				if (Dato.CompareTo(dato) > 0)
				{
					if (Izquierda == null)
					{
						Izquierda = new ArbolBinario<T>(dato);
						Izquierda.Padre = this;
					}
					else
						Izquierda.Insertar(dato);
				}
				else
				{
					if (Derecha == null)
					{
						Derecha = new ArbolBinario<T>(dato);
						Derecha.Padre = this;
					}
					else
						Derecha.Insertar(dato);
				}
			}
			return this;
		}

        virtual public ArbolBinario<T> InsertarMultiple(List<T> datos)
        {
            ArbolBinario<T> tmp = this;
            foreach (T dato in datos)
                tmp = tmp.Insertar(dato);
            return tmp;
        }

        virtual public ArbolBinario<T> Eliminar (T dato)
		{
			ArbolBinario<T> retNodo = BuscarNodo(dato);
			if (retNodo == null)
				return this;

			if (retNodo.Derecha == null && retNodo.Izquierda == null)
			{

				if (retNodo.Padre == null)
				{
					retNodo = null;
					return null;
				}

                if (retNodo.Padre.Dato.CompareTo(retNodo.Dato) > 0)
					retNodo.Padre.Izquierda = null;
				else
                    retNodo.Padre.Derecha = null;
                retNodo = null;
				return this;
			}

			if (retNodo.Derecha != null && retNodo.Izquierda != null)
			{
				var datoNuevo = retNodo.Izquierda.Max().Dato;
				retNodo.Dato = datoNuevo;
				_= retNodo.Izquierda.Eliminar(datoNuevo);
				return this;
			}

			if (retNodo.Derecha != null)
			{
				if (retNodo.Padre == null)
				{
					retNodo = retNodo.Derecha;
					retNodo.Padre = null;
					return retNodo;
				}
				else
				{
					if (retNodo.Padre.Dato.CompareTo(retNodo.Dato) > 0)
						retNodo.Padre.Izquierda = retNodo.Derecha;
					else
						retNodo.Padre.Derecha = retNodo.Derecha;
					retNodo = null;
				}
				return this;
			}
			if (retNodo.Padre == null)
			{
				retNodo = retNodo.Izquierda;
                retNodo.Padre = null;
                return retNodo;
            }
			else
			{
				retNodo.Padre.Izquierda = retNodo.Izquierda;
				retNodo = null;
			}
            return this;
        }

		private string RecorrerArb()
		{
			var str = "";
			if (Izquierda != null)
				str = Izquierda.RecorrerArb();
			str += Dato + ",";
			if (Derecha != null)
				str += Derecha.RecorrerArb();
			return str;
		}

		public ArbolBinario<T> Min()
		{
			return (Izquierda == null) ? this : (Izquierda.Min());
		}

		public ArbolBinario<T> Max()
		{
			return (Derecha == null) ? this : (Derecha.Max());
		}

        public override string ToString()
        {
            var str = RecorrerArb();
            return str.Remove(str.Length - 1);
        }
    }

	public class ArbolBinarioAVL<T> : ArbolBinario<T> where T : IComparable
    {
        public ArbolBinarioAVL(T dato) : base(dato) { }

		public void Balancear()
		{ 
			//TODO: Balancear arbol durante la inserción. ¿Modificae Binario
		}
    }
}
