using System;

namespace EstructurasDatos.Arboles
{
	public class ArbolBinario<T> where T : IComparable
	{
		public T Dato { get; set; }
		public ArbolBinario<T> Izquierda, Derecha;

		public ArbolBinario(T dato)
		{
			Dato = dato;
		}

		virtual public void InsertarEnArbol(T dato)
		{
			if (Dato.CompareTo(dato) > 0)
			{
				if (Izquierda == null)
					Izquierda = new ArbolBinario<T>(dato);
				else
					Izquierda.InsertarEnArbol(dato);
			}
			else
				if (Derecha == null)
				Derecha = new ArbolBinario<T>(dato);
			else
				Derecha.InsertarEnArbol(dato);
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

		public string RecorrerArbol()
		{
			var str = RecorrerArb();
			return str.Remove(str.Length - 1);
		}

		public T Min()
		{
			return (Izquierda == null) ? Dato : (Izquierda.Min());
		}

		public T Max()
		{
			return (Derecha == null) ? Dato : (Derecha.Max());
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
