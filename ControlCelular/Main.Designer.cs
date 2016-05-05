namespace ControlCelular
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTelefonos = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewTelefonos = new System.Windows.Forms.DataGridView();
            this.BtnNuevoTelefono = new System.Windows.Forms.Button();
            this.txtBuscarTefonos = new System.Windows.Forms.TextBox();
            this.tabModelos = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewModelos = new System.Windows.Forms.DataGridView();
            this.BtnNuevoModelo = new System.Windows.Forms.Button();
            this.txtBuscarModelos = new System.Windows.Forms.TextBox();
            this.tabVentas = new System.Windows.Forms.TabPage();
            this.tabProveedores = new System.Windows.Forms.TabPage();
            this.tabClientes = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClienteNuevo = new System.Windows.Forms.Button();
            this.txtBuscarClientes = new System.Windows.Forms.TextBox();
            this.dataGridViewClientes = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTelefonos.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefonos)).BeginInit();
            this.tabModelos.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModelos)).BeginInit();
            this.tabClientes.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1104, 644);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTelefonos);
            this.tabControl1.Controls.Add(this.tabModelos);
            this.tabControl1.Controls.Add(this.tabVentas);
            this.tabControl1.Controls.Add(this.tabProveedores);
            this.tabControl1.Controls.Add(this.tabClientes);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(23, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1058, 618);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabTelefonos
            // 
            this.tabTelefonos.Controls.Add(this.tableLayoutPanel2);
            this.tabTelefonos.Location = new System.Drawing.Point(4, 22);
            this.tabTelefonos.Name = "tabTelefonos";
            this.tabTelefonos.Padding = new System.Windows.Forms.Padding(3);
            this.tabTelefonos.Size = new System.Drawing.Size(1050, 592);
            this.tabTelefonos.TabIndex = 0;
            this.tabTelefonos.Text = "Telefonos";
            this.tabTelefonos.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridViewTelefonos, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.BtnNuevoTelefono, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtBuscarTefonos, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1044, 586);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridViewTelefonos
            // 
            this.dataGridViewTelefonos.AllowUserToAddRows = false;
            this.dataGridViewTelefonos.AllowUserToDeleteRows = false;
            this.dataGridViewTelefonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTelefonos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTelefonos.Location = new System.Drawing.Point(36, 60);
            this.dataGridViewTelefonos.MultiSelect = false;
            this.dataGridViewTelefonos.Name = "dataGridViewTelefonos";
            this.dataGridViewTelefonos.ReadOnly = true;
            this.dataGridViewTelefonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTelefonos.Size = new System.Drawing.Size(969, 523);
            this.dataGridViewTelefonos.TabIndex = 0;
            this.dataGridViewTelefonos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewTelefonos_CellMouseDoubleClick);
            // 
            // BtnNuevoTelefono
            // 
            this.BtnNuevoTelefono.Location = new System.Drawing.Point(36, 3);
            this.BtnNuevoTelefono.Name = "BtnNuevoTelefono";
            this.BtnNuevoTelefono.Size = new System.Drawing.Size(75, 22);
            this.BtnNuevoTelefono.TabIndex = 2;
            this.BtnNuevoTelefono.Text = "Nuevo";
            this.BtnNuevoTelefono.UseVisualStyleBackColor = true;
            this.BtnNuevoTelefono.Click += new System.EventHandler(this.BtnNuevoTelefono_Click);
            // 
            // txtBuscarTefonos
            // 
            this.txtBuscarTefonos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarTefonos.Location = new System.Drawing.Point(36, 32);
            this.txtBuscarTefonos.Name = "txtBuscarTefonos";
            this.txtBuscarTefonos.Size = new System.Drawing.Size(969, 20);
            this.txtBuscarTefonos.TabIndex = 1;
            this.txtBuscarTefonos.TextChanged += new System.EventHandler(this.txtBuscarTefonos_TextChanged);
            // 
            // tabModelos
            // 
            this.tabModelos.Controls.Add(this.tableLayoutPanel3);
            this.tabModelos.Location = new System.Drawing.Point(4, 22);
            this.tabModelos.Name = "tabModelos";
            this.tabModelos.Padding = new System.Windows.Forms.Padding(3);
            this.tabModelos.Size = new System.Drawing.Size(1050, 592);
            this.tabModelos.TabIndex = 1;
            this.tabModelos.Text = "Modelos";
            this.tabModelos.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.Controls.Add(this.dataGridViewModelos, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.BtnNuevoModelo, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtBuscarModelos, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1044, 586);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dataGridViewModelos
            // 
            this.dataGridViewModelos.AllowUserToAddRows = false;
            this.dataGridViewModelos.AllowUserToDeleteRows = false;
            this.dataGridViewModelos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewModelos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewModelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewModelos.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewModelos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewModelos.Location = new System.Drawing.Point(36, 60);
            this.dataGridViewModelos.MultiSelect = false;
            this.dataGridViewModelos.Name = "dataGridViewModelos";
            this.dataGridViewModelos.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewModelos.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewModelos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewModelos.Size = new System.Drawing.Size(969, 523);
            this.dataGridViewModelos.TabIndex = 0;
            this.dataGridViewModelos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewModelos_CellMouseDoubleClick);
            // 
            // BtnNuevoModelo
            // 
            this.BtnNuevoModelo.Location = new System.Drawing.Point(36, 3);
            this.BtnNuevoModelo.Name = "BtnNuevoModelo";
            this.BtnNuevoModelo.Size = new System.Drawing.Size(75, 22);
            this.BtnNuevoModelo.TabIndex = 2;
            this.BtnNuevoModelo.Text = "Nuevo";
            this.BtnNuevoModelo.UseVisualStyleBackColor = true;
            this.BtnNuevoModelo.Click += new System.EventHandler(this.BtnNuevoModelo_Click);
            // 
            // txtBuscarModelos
            // 
            this.txtBuscarModelos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarModelos.Location = new System.Drawing.Point(36, 32);
            this.txtBuscarModelos.Name = "txtBuscarModelos";
            this.txtBuscarModelos.Size = new System.Drawing.Size(969, 20);
            this.txtBuscarModelos.TabIndex = 1;
            this.txtBuscarModelos.TextChanged += new System.EventHandler(this.txtBuscarModelos_TextChanged);
            // 
            // tabVentas
            // 
            this.tabVentas.Location = new System.Drawing.Point(4, 22);
            this.tabVentas.Name = "tabVentas";
            this.tabVentas.Padding = new System.Windows.Forms.Padding(3);
            this.tabVentas.Size = new System.Drawing.Size(690, 412);
            this.tabVentas.TabIndex = 2;
            this.tabVentas.Text = "Ventas";
            this.tabVentas.UseVisualStyleBackColor = true;
            // 
            // tabProveedores
            // 
            this.tabProveedores.Location = new System.Drawing.Point(4, 22);
            this.tabProveedores.Name = "tabProveedores";
            this.tabProveedores.Size = new System.Drawing.Size(690, 412);
            this.tabProveedores.TabIndex = 3;
            this.tabProveedores.Text = "Proveedores";
            this.tabProveedores.UseVisualStyleBackColor = true;
            // 
            // tabClientes
            // 
            this.tabClientes.Controls.Add(this.tableLayoutPanel4);
            this.tabClientes.Location = new System.Drawing.Point(4, 22);
            this.tabClientes.Name = "tabClientes";
            this.tabClientes.Padding = new System.Windows.Forms.Padding(3);
            this.tabClientes.Size = new System.Drawing.Size(1050, 592);
            this.tabClientes.TabIndex = 4;
            this.tabClientes.Text = "Clientes";
            this.tabClientes.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel4.Controls.Add(this.btnClienteNuevo, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtBuscarClientes, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.dataGridViewClientes, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1044, 586);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // btnClienteNuevo
            // 
            this.btnClienteNuevo.Location = new System.Drawing.Point(37, 3);
            this.btnClienteNuevo.Name = "btnClienteNuevo";
            this.btnClienteNuevo.Size = new System.Drawing.Size(75, 22);
            this.btnClienteNuevo.TabIndex = 3;
            this.btnClienteNuevo.Text = "Nuevo";
            this.btnClienteNuevo.UseVisualStyleBackColor = true;
            this.btnClienteNuevo.Click += new System.EventHandler(this.btnClienteNuevo_Click);
            // 
            // txtBuscarClientes
            // 
            this.txtBuscarClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarClientes.Location = new System.Drawing.Point(37, 32);
            this.txtBuscarClientes.Name = "txtBuscarClientes";
            this.txtBuscarClientes.Size = new System.Drawing.Size(952, 20);
            this.txtBuscarClientes.TabIndex = 4;
            this.txtBuscarClientes.TextChanged += new System.EventHandler(this.txtBuscarClientes_TextChanged);
            // 
            // dataGridViewClientes
            // 
            this.dataGridViewClientes.AllowUserToAddRows = false;
            this.dataGridViewClientes.AllowUserToDeleteRows = false;
            this.dataGridViewClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewClientes.Location = new System.Drawing.Point(37, 60);
            this.dataGridViewClientes.MultiSelect = false;
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.ReadOnly = true;
            this.dataGridViewClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewClientes.Size = new System.Drawing.Size(952, 523);
            this.dataGridViewClientes.TabIndex = 5;
            this.dataGridViewClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClientes_CellDoubleClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 644);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.Text = "Control Celular";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabTelefonos.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefonos)).EndInit();
            this.tabModelos.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModelos)).EndInit();
            this.tabClientes.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTelefonos;
        private System.Windows.Forms.TabPage tabModelos;
        private System.Windows.Forms.DataGridView dataGridViewTelefonos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtBuscarTefonos;
        private System.Windows.Forms.Button BtnNuevoTelefono;
        private System.Windows.Forms.TabPage tabVentas;
        private System.Windows.Forms.TabPage tabProveedores;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dataGridViewModelos;
        private System.Windows.Forms.Button BtnNuevoModelo;
        private System.Windows.Forms.TextBox txtBuscarModelos;
        private System.Windows.Forms.TabPage tabClientes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnClienteNuevo;
        private System.Windows.Forms.TextBox txtBuscarClientes;
        private System.Windows.Forms.DataGridView dataGridViewClientes;
    }
}

