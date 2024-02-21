using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class InventarioDAO
    {
        public int UpdateInventario(Inventario inventario)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (INSERT)
                    String select = @"UPDATE Inventario SET NombreCorto=@NombreCorto, Descripcion=@Descripcion, 
                    Serie=@Serie, Color=@Color, FechaAdquision=@FechaAdquision,
                    TipoAdquision=@TipoAdquision, Observaciones=@Observaciones, AREAS_id=@AREAS_id WHERE id=@id;";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    sentencia.Parameters.AddWithValue("@id", inventario.Id);
                    sentencia.Parameters.AddWithValue("@NombreCorto", inventario.NombreCorto);
                    sentencia.Parameters.AddWithValue("@Descripcion", inventario.Descripcion);
                    sentencia.Parameters.AddWithValue("@Serie", inventario.Serie);
                    sentencia.Parameters.AddWithValue("@Color", inventario.Color);
                    sentencia.Parameters.AddWithValue("@FechaAdquision", inventario.FechaAdquision);
                    sentencia.Parameters.AddWithValue("@TipoAdquision", inventario.TipoAdquision);
                    sentencia.Parameters.AddWithValue("@Observaciones", inventario.Observaciones);
                    sentencia.Parameters.AddWithValue("@AREAS_id", inventario.Areas_id);
                    //Ejercutar el comando 
                    int filasAfectadas = Convert.ToInt32(sentencia.ExecuteNonQuery());
                    return filasAfectadas;
                }
                catch (Exception e)
                {
                    return 0;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                //Devolvemos un cero indicando que no se insertó nada
                return 0;
            }
        }

        public bool InsertInventario(Inventario inventario)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (INSERT)
                    String select = @"INSERT INTO Inventario(NombreCorto, Descripcion, Serie, Color, FechaAdquision, 
                    TipoAdquision, Observaciones, AREAS_id) VALUES
                    (@NombreCorto, @Descripcion,  @Serie, @Color, @FechaAdquision, @TipoAdquision, @Observaciones, @AREAS_id);";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    sentencia.Parameters.AddWithValue("@NombreCorto", inventario.NombreCorto);
                    sentencia.Parameters.AddWithValue("@Descripcion", inventario.Descripcion);
                    sentencia.Parameters.AddWithValue("@Serie", inventario.Serie);
                    sentencia.Parameters.AddWithValue("@Color", inventario.Color);
                    sentencia.Parameters.AddWithValue("@FechaAdquision", inventario.FechaAdquision);
                    sentencia.Parameters.AddWithValue("@TipoAdquision", inventario.TipoAdquision);
                    sentencia.Parameters.AddWithValue("@Observaciones", inventario.Observaciones);
                    sentencia.Parameters.AddWithValue("@AREAS_id", inventario.Areas_id);
                    //Ejercutar el comando 
                    sentencia.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                //Devolvemos un cero indicando que no se insertó nada
                return false;
                
            }
           
        }


        public int DeleteInventario(int ID)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (INSERT)
                    String select = @"DELETE FROM Inventario WHERE id=@id";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    sentencia.Parameters.AddWithValue("@id", ID);
                    //Ejercutar el comando 
                    int filasAfectadas = Convert.ToInt32(sentencia.ExecuteNonQuery());
                    return filasAfectadas;
                }
                catch (Exception e)
                {
                    return 0;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                //Devolvemos un cero indicando que no se insertó nada
                return 0;
            }
        }


        public Inventario getInventario(int ID)
        {
            Inventario inventory = null;
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (SELECT)
                    String select = @"SELECT * FROM Inventario WHERE id=@ID";
                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);
                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@ID", ID);
                    sentencia.Connection = Conexion.conexion;

                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia);

                    //Llenar el datatable
                    da.Fill(dt);
                    //Revisar si hubo resultados
                    if (dt.Rows.Count > 0)
                    {
                        DataRow fila = dt.Rows[0];
                        inventory = new Inventario()
                        {


                            Id = Convert.ToInt32(fila["ID"]),
                            NombreCorto = fila["NombreCorto"].ToString(),
                            Descripcion = fila["Descripcion"].ToString(),
                            Serie = fila["Serie"].ToString(),
                            Color = fila["Color"].ToString(),
                            FechaAdquision = fila["FechaAdquision"].ToString(),
                            TipoAdquision = fila["TipoAdquision"].ToString(),
                            Observaciones = fila["Observaciones"].ToString(),
                            Areas_id = Convert.ToInt32(fila["AREAS_id"])
                        };

                    }
                    return inventory;
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

        public List<Inventario> getAll()
        {
            List<Inventario> inventarios = new List<Inventario>();
			//Conectarme
			if (Conexion.Conectar())
			{
				try
				{
					//Crear la sentencia a ejecutar (SELECT)
					String select = @"SELECT * FROM Inventario";
					//Definir un datatable para que sea llenado
					DataTable dt = new DataTable();
					//Crear el dataadapter
					MySqlCommand sentencia = new MySqlCommand(select);
					sentencia.Connection = Conexion.conexion;

					MySqlDataAdapter da = new MySqlDataAdapter(sentencia);

					//Llenar el datatable
					da.Fill(dt);
					//Revisar si hubo resultados
					for (int i=0; i<dt.Rows.Count; i++)
					{
						DataRow fila = dt.Rows[i];
						inventarios.Add(new Inventario()
						{
							Id = Convert.ToInt32(fila["ID"]),
							NombreCorto = fila["NombreCorto"].ToString(),
							Descripcion = fila["Descripcion"].ToString(),
							Serie = fila["Serie"].ToString(),
							Color = fila["Color"].ToString(),
							FechaAdquision = fila["FechaAdquision"].ToString(),
							TipoAdquision = fila["TipoAdquision"].ToString(),
							Observaciones = fila["Observaciones"].ToString(),
							Areas_id = Convert.ToInt32(fila["AREAS_id"])
						});

					}
					return inventarios;
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
