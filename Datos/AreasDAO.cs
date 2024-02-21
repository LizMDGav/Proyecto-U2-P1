using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
	public class AreasDAO
	{
		public List<Areas> getAll()
		{
			List<Areas> areas = new List<Areas>();
			//Conectarme
			if (Conexion.Conectar())
			{
				try
				{
					//Crear la sentencia a ejecutar (SELECT)
					String select = @"SELECT * FROM AREAS";
					//Definir un datatable para que sea llenado
					DataTable dt = new DataTable();
					//Crear el dataadapter
					MySqlCommand sentencia = new MySqlCommand(select);
					sentencia.Connection = Conexion.conexion;

					MySqlDataAdapter da = new MySqlDataAdapter(sentencia);

					//Llenar el datatable
					da.Fill(dt);
					//Revisar si hubo resultados
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						DataRow fila = dt.Rows[i];
						areas.Add(new Areas()
						{
							Id = Convert.ToInt32(fila["id"]),
							Nombre = fila["Nombre"].ToString(),
							Ubicacion = fila["Ubicacion"].ToString(),
						});

					}
					return areas;
				}
				finally
				{
					Conexion.Desconectar();
				}
			}
			else
			{
				return null;
			}
		}
	}
}
