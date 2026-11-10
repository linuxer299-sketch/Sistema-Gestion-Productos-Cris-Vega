using GestionProductos.Logica;
namespace gestion.interfaz
{
    public partial class Form1 : Form
    {
        private int idProductoSeleccionado = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = LogicaProducto.ListarProductos();
            cmbCategoria.DataSource = LogicaCategoria.ListarCategorias();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "IdCategoria";

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Escribe un precio válido.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Escribe un número entero válido para el stock.");
                return;
            }

            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Selecciona una categoría.");
                return;
            }

            try
            {
                Producto producto = new Producto
                {
                    Nombre = txtNombre.Text,
                    Precio = precio,
                    Stock = stock,
                    IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue)
                };

                LogicaProducto.GuardarProducto(producto);

                MessageBox.Show("Producto guardado correctamente.");
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = LogicaProducto.ListarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar");
            }

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            using (FormCategorias formulario = new FormCategorias())
            {
                formulario.ShowDialog();
            }

            cmbCategoria.DataSource = LogicaCategoria.ListarCategorias();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "IdCategoria";

        }



        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            idProductoSeleccionado =
                Convert.ToInt32(fila.Cells["IdProducto"].Value);

            txtNombre.Text =
                fila.Cells["Nombre"].Value?.ToString() ?? string.Empty;

            txtPrecio.Text =
                fila.Cells["Precio"].Value?.ToString() ?? string.Empty;

            txtStock.Text =
                fila.Cells["Stock"].Value?.ToString() ?? string.Empty;

            cmbCategoria.SelectedValue =
                Convert.ToInt32(fila.Cells["IdCategoria"].Value);

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto de la tabla.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Escribe un precio válido.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Escribe un número entero válido para el stock.");
                return;
            }

            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Selecciona una categoría.");
                return;
            }

            try
            {
                Producto producto = new Producto
                {
                    IdProducto = idProductoSeleccionado,
                    Nombre = txtNombre.Text,
                    Precio = precio,
                    Stock = stock,
                    IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue)
                };

                LogicaProducto.ModificarProducto(producto);

                MessageBox.Show("Producto modificado correctamente.");

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = LogicaProducto.ListarProductos();

                idProductoSeleccionado = 0;
                txtNombre.Clear();
                txtPrecio.Clear();
                txtStock.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto de la tabla.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Seguro que quieres eliminar este producto?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                LogicaProducto.EliminarProducto(idProductoSeleccionado);

                MessageBox.Show("Producto eliminado correctamente.");

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = LogicaProducto.ListarProductos();

                idProductoSeleccionado = 0;
                txtNombre.Clear();
                txtPrecio.Clear();
                txtStock.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar");
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            idProductoSeleccionado = 0;
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtBuscar.Clear();
            cmbCategoria.SelectedIndex = -1;

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = LogicaProducto.ListarProductos();
            dgvProductos.ClearSelection();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var resultados = LogicaProducto.BuscarProductos(txtBuscar.Text.Trim());

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = resultados;

                idProductoSeleccionado = 0;
                txtNombre.Clear();
                txtPrecio.Clear();
                txtStock.Clear();
                cmbCategoria.SelectedIndex = -1;

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al buscar");
            }

        }
    }
}
