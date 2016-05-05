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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewTelefonos = new System.Windows.Forms.DataGridView();
            this.txtBuscarTefonos = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnNuevoTelefono = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefonos)).BeginInit();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 464);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(23, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(698, 438);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(690, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Telefonos";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(684, 406);
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
            this.dataGridViewTelefonos.Size = new System.Drawing.Size(609, 343);
            this.dataGridViewTelefonos.TabIndex = 0;
            this.dataGridViewTelefonos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTelefonos_CellContentDoubleClick);
            // 
            // txtBuscarTefonos
            // 
            this.txtBuscarTefonos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarTefonos.Location = new System.Drawing.Point(36, 32);
            this.txtBuscarTefonos.Name = "txtBuscarTefonos";
            this.txtBuscarTefonos.Size = new System.Drawing.Size(609, 20);
            this.txtBuscarTefonos.TabIndex = 1;
            this.txtBuscarTefonos.TextChanged += new System.EventHandler(this.txtBuscarTefonos_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(690, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 464);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.Text = "Control Celular";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelefonos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewTelefonos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtBuscarTefonos;
        private System.Windows.Forms.Button BtnNuevoTelefono;
    }
}

