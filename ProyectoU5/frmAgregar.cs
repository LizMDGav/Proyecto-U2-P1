using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoU5
{
	public partial class frmAgregar : Form
    {
        List<Areas> areas = new List<Areas>();

        public frmAgregar()
        {
            InitializeComponent();
            areas = new AreasDAO().getAll();
            cmbArea.DataSource = areas;
            cmbArea.DisplayMember = "Nombre";
            cmbArea.ValueMember = "Id";
            cmbArea.SelectedIndex = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
                Inventario inventario = new Inventario();

                inventario.NombreCorto=txtNombre.Text;
                inventario.Descripcion=txtDescripcion.Text;
                inventario.Serie=txtSerie.Text;
                inventario.Color=txtColor.Text;
                inventario.FechaAdquision=dtFechaAdquision.Text;
                inventario.TipoAdquision=txtTipoAdquision.Text;
                inventario.Observaciones=txtObservaciones.Text;
                inventario.Areas_id = Convert.ToInt32(cmbArea.SelectedValue);


                bool modificacion = new InventarioDAO().InsertInventario(inventario);
                if (modificacion)
                {
                    MessageBox.Show("El registro se agrego con éxito.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error durante la operación.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

		private void btnCancelar_Click(object sender, EventArgs e)
		{
            this.Close();
		}

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }
    }
}
