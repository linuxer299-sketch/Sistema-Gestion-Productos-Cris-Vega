using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GestionProductos.Logica;
namespace gestion.interfaz
{
    public partial class FormCategorias : Form
    {
        private int idCategoriaSeleccionada = 0;
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            dgvCategorias.DataSource = LogicaCategoria.ListarCategorias();

        }

        private void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria
                {
                    Nombre = txtNombreCategoria.Text,
                    Descripcion = txtDescripcionCategoria.Text
                };

                LogicaCategoria.GuardarCategoria(categoria);

                MessageBox.Show("Categoría guardada correctamente.");

                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = LogicaCategoria.ListarCategorias();

                txtNombreCategoria.Clear();
                txtDescripcionCategoria.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar");
            }

        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvCategorias.Rows[e.RowIndex];

            idCategoriaSeleccionada = Convert.ToInt32(fila.Cells["IdCategoria"].Value);
            txtNombreCategoria.Text =
                fila.Cells["Nombre"].Value?.ToString() ?? string.Empty;

            txtDescripcionCategoria.Text =
                fila.Cells["Descripcion"].Value?.ToString() ?? string.Empty;




        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            if (idCategoriaSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una categoría de la tabla.");
                return;
            }

            try
            {
                Categoria categoria = new Categoria
                {
                    IdCategoria = idCategoriaSeleccionada,
                    Nombre = txtNombreCategoria.Text,
                    Descripcion = txtDescripcionCategoria.Text
                };

                LogicaCategoria.ModificarCategoria(categoria);

                MessageBox.Show("Categoría modificada correctamente.");

                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = LogicaCategoria.ListarCategorias();

                idCategoriaSeleccionada = 0;
                txtNombreCategoria.Clear();
                txtDescripcionCategoria.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar");
            }

        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (idCategoriaSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una categoría de la tabla.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Seguro que quieres eliminar esta categoría?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                LogicaCategoria.EliminarCategoria(idCategoriaSeleccionada);

                MessageBox.Show("Categoría eliminada correctamente.");

                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = LogicaCategoria.ListarCategorias();

                idCategoriaSeleccionada = 0;
                txtNombreCategoria.Clear();
                txtDescripcionCategoria.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar");
            }
        }

        private void btnLimpiarCategoria_Click(object sender, EventArgs e)
        {
            idCategoriaSeleccionada = 0;
            txtNombreCategoria.Clear();
            txtDescripcionCategoria.Clear();
            dgvCategorias.ClearSelection();

        }
    }
}
