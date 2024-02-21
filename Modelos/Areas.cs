﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
	public class Areas
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Ubicacion { get; set; }

		public Areas()
		{
			Id = 0;
			Nombre = "";
			Ubicacion = "";
		}
		public Areas(int id, string nombre, string ubicacion)
		{
			Id = id;
			Nombre = nombre;
			Ubicacion = ubicacion;
		}
	}
}
