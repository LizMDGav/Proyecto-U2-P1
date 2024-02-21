using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoU5
{
	public partial class frmEditar : Form
	{
		List<Areas> areas = new List<Areas>();
		int IDGeneral;
		public frmEditar(int ID)
		{
			InitializeComponent();
			areas = new AreasDAO().getAll();
			cmbArea.DataSource = areas;
			cmbArea.DisplayMember = "Nombre";
			cmbArea.ValueMember = "Id";
			IDGeneral = ID;
			Inventario editar = new InventarioDAO().getInventario(ID);
			txtNombre.Text = editar.NombreCorto;
			txtDescripcion.Text = editar.Descripcion;
			txtColor.Text=editar.Color;
			if (DateTime.TryParse(editar.FechaAdquision, out DateTime fecha))
			{
				// Si es una fecha válida, establecerla en el DateTimePicker
				dtFechaAdquision.Value = fecha;
			}
			txtSerie.Text = editar.Serie;
			int buscar = 0;
			for(int i=0; i<areas.Count; i++)
			{
				if (editar.Areas_id == areas[i].Id)
				{
					buscar = i;
					break;
				}
			}
			cmbArea.SelectedIndex = buscar;
			txtTipoAdquision.Text = editar.TipoAdquision;
			txtObservaciones.Text = editar.Observaciones;
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			Inventario inventario = new Inventario();

			inventario.Id = IDGeneral;
			inventario.NombreCorto = txtNombre.Text;
			inventario.Descripcion = txtDescripcion.Text;
			inventario.Serie = txtSerie.Text;
			inventario.Color = txtColor.Text;
			inventario.FechaAdquision = dtFechaAdquision.Text;
			inventario.TipoAdquision = txtTipoAdquision.Text;
			inventario.Observaciones = txtObservaciones.Text;
			inventario.Areas_id = Convert.ToInt32(cmbArea.SelectedValue);

			if (new InventarioDAO().UpdateInventario(inventario)>0)
			{
				MessageBox.Show("El registro se edito con éxito.", "Éxito",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
			else
			{
				MessageBox.Show("Ocurrió un error durante la operación.", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
