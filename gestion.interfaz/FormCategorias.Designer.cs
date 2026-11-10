namespace gestion.interfaz
{
    partial class FormCategorias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGuardarCategoria = new Button();
            txtNombreCategoria = new TextBox();
            dgvCategorias = new DataGridView();
            lblNombreCategoria = new Label();
            txtDescripcionCategoria = new TextBox();
            btnLimpiarCategoria = new Button();
            btnEliminarCategoria = new Button();
            btnModificarCategoria = new Button();
            lblDescripcionCategori = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();
            // 
            // btnGuardarCategoria
            // 
            btnGuardarCategoria.Location = new Point(104, 324);
            btnGuardarCategoria.Name = "btnGuardarCategoria";
            btnGuardarCategoria.Size = new Size(186, 34);
            btnGuardarCategoria.TabIndex = 0;
            btnGuardarCategoria.Text = "Guardar Categoria";
            btnGuardarCategoria.UseVisualStyleBackColor = true;
            btnGuardarCategoria.Click += btnGuardarCategoria_Click;
            // 
            // txtNombreCategoria
            // 
            txtNombreCategoria.Location = new Point(120, 179);
            txtNombreCategoria.Name = "txtNombreCategoria";
            txtNombreCategoria.Size = new Size(159, 31);
            txtNombreCategoria.TabIndex = 1;
            // 
            // dgvCategorias
            // 
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Location = new Point(43, 482);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersWidth = 62;
            dgvCategorias.Size = new Size(1114, 309);
            dgvCategorias.TabIndex = 2;
            dgvCategorias.CellClick += dgvCategorias_CellClick;
            // 
            // lblNombreCategoria
            // 
            lblNombreCategoria.AutoSize = true;
            lblNombreCategoria.Location = new Point(120, 102);
            lblNombreCategoria.Name = "lblNombreCategoria";
            lblNombreCategoria.Size = new Size(159, 25);
            lblNombreCategoria.TabIndex = 3;
            lblNombreCategoria.Text = "Nombre Categoria";
            // 
            // txtDescripcionCategoria
            // 
            txtDescripcionCategoria.Location = new Point(401, 179);
            txtDescripcionCategoria.Name = "txtDescripcionCategoria";
            txtDescripcionCategoria.Size = new Size(203, 31);
            txtDescripcionCategoria.TabIndex = 4;
            // 
            // btnLimpiarCategoria
            // 
            btnLimpiarCategoria.Location = new Point(365, 413);
            btnLimpiarCategoria.Name = "btnLimpiarCategoria";
            btnLimpiarCategoria.Size = new Size(186, 34);
            btnLimpiarCategoria.TabIndex = 5;
            btnLimpiarCategoria.Text = "Limpiar Categoria";
            btnLimpiarCategoria.UseVisualStyleBackColor = true;
            btnLimpiarCategoria.Click += btnLimpiarCategoria_Click;
            // 
            // btnEliminarCategoria
            // 
            btnEliminarCategoria.Location = new Point(104, 413);
            btnEliminarCategoria.Name = "btnEliminarCategoria";
            btnEliminarCategoria.Size = new Size(186, 34);
            btnEliminarCategoria.TabIndex = 6;
            btnEliminarCategoria.Text = "Eliminar Categoria";
            btnEliminarCategoria.UseVisualStyleBackColor = true;
            btnEliminarCategoria.Click += btnEliminarCategoria_Click;
            // 
            // btnModificarCategoria
            // 
            btnModificarCategoria.Location = new Point(365, 324);
            btnModificarCategoria.Name = "btnModificarCategoria";
            btnModificarCategoria.Size = new Size(186, 34);
            btnModificarCategoria.TabIndex = 7;
            btnModificarCategoria.Text = "Modificar Categoria";
            btnModificarCategoria.UseVisualStyleBackColor = true;
            btnModificarCategoria.Click += btnModificarCategoria_Click;
            // 
            // lblDescripcionCategori
            // 
            lblDescripcionCategori.AutoSize = true;
            lblDescripcionCategori.Location = new Point(419, 102);
            lblDescripcionCategori.Name = "lblDescripcionCategori";
            lblDescripcionCategori.Size = new Size(185, 25);
            lblDescripcionCategori.TabIndex = 8;
            lblDescripcionCategori.Text = "Descripcion Categoria";
            // 
            // FormCategorias
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 803);
            Controls.Add(lblDescripcionCategori);
            Controls.Add(btnModificarCategoria);
            Controls.Add(btnEliminarCategoria);
            Controls.Add(btnLimpiarCategoria);
            Controls.Add(txtDescripcionCategoria);
            Controls.Add(lblNombreCategoria);
            Controls.Add(dgvCategorias);
            Controls.Add(txtNombreCategoria);
            Controls.Add(btnGuardarCategoria);
            Name = "FormCategorias";
            Text = "FormCategorias";
            Load += FormCategorias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardarCategoria;
        private TextBox txtNombreCategoria;
        private DataGridView dgvCategorias;
        private Label lblNombreCategoria;
        private TextBox txtDescripcionCategoria;
        private Button btnLimpiarCategoria;
        private Button btnEliminarCategoria;
        private Button btnModificarCategoria;
        private Label lblDescripcionCategori;
    }
}