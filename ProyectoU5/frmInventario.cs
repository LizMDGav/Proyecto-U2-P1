using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoU5
{
    public partial class frmInventario : Form
    {
        private List<Inventario> inventarios;
        public frmInventario()
        {

            InitializeComponent();
            inventarios = new InventarioDAO().getAll();
            if(inventarios == null) {
            
                MessageBox.Show("Error de conexión.");
                this.Close();
                return;
            }
            else if (inventarios != null)
            {
                dgvInventarios.DataSource = inventarios;
            }

            dgvInventarios.Font = new Font("Microsoft Sans Serif", 12);
            //Desactivar la adición, eliminación y edición de el gridview
            dgvInventarios.AllowUserToAddRows = false;
            dgvInventarios.AllowUserToDeleteRows = false;
            dgvInventarios.EditMode = DataGridViewEditMode.EditProgrammatically;
            //Activar la selección por fila en lugar de columna
            dgvInventarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Desactivar los encabezados de fila si no son necesarios.
            dgvInventarios.RowHeadersVisible = false;
            // Ajustar el ancho de las columnas para que llenen el espacio disponible.
            dgvInventarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvInventarios.Columns["NombreCorto"].HeaderText = "Nombre";
            dgvInventarios.Columns["FechaAdquision"].HeaderText = "Fecha de adquision";
            dgvInventarios.Columns["TipoAdquision"].HeaderText = "Tipo de adquision";
        }

        public void actualizarDGV()
        {
            inventarios = new InventarioDAO().getAll();
            dgvInventarios.DataSource = inventarios;
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.ShowDialog();
            actualizarDGV();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvInventarios.SelectedRows[0];
            int ID = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
            frmEditar editar = new frmEditar(ID);
            editar.ShowDialog();
            actualizarDGV();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvInventarios.SelectedRows[0];
            int Id= int.Parse(filaSeleccionada.Cells[0].Value.ToString());
            string message = "¿Está seguro/a que desea eliminar el inventario número " + Id + "?";
            string caption = "Eliminacion de inventario";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int modificacion = new InventarioDAO().DeleteInventario(Id);
                if (modificacion>0)
                {
                    actualizarDGV();
                    MessageBox.Show("Eliminado exitosamente.");
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la operación.");
                }
                
            }
        }
    }
}
