using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessObjects;
using DAO;

namespace ControlCelular
{
    public partial class FormModelo : Form
    {
        public Modelo _modelo = null;
        public Dictionary<int, SistemaOperativo> _sistemasOperativos;
        public Dictionary<int, Marca> _marcas;

        public FormModelo()
        {
            InitializeComponent();
        }

        private void FormModelo_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            CmbSistemaOperativo.DataSource = _sistemasOperativos.Values.ToList();
            CmbMarca.DataSource = _marcas.Values.ToList();

            CmbSistemaOperativo.DisplayMember = "Nombre";
            CmbSistemaOperativo.ValueMember = "Id";
            CmbSistemaOperativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbMarca.DisplayMember = "Nombre";
            CmbMarca.ValueMember = "Id";
            CmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            if (_modelo != null)
            {
                TxtId.Text = _modelo.Id.ToString();
                TxtModelo.Text = _modelo.Modelo1;
                TxtNombre.Text = _modelo.Nombre;
                txtDescripcion.Text = _modelo.Descripcion;
                txtProcesador.Text = _modelo.Procesador;
                CmbSistemaOperativo.SelectedValue = _modelo.SistemaOperativo.Id;
                CmbMarca.SelectedValue = _modelo.Marca.Id;
                txtMemoria.Text = _modelo.Memoria;

            }
            else
            {
                BtnBorrar.Visible = false;
            }
        }


        private bool validar()
        {
            bool ok = true;
            if (TxtNombre.Text.Trim() == String.Empty)
            {
                TxtNombre.BackColor = Color.LightCyan;
                ok = false;
            }
            else
            {
                TxtNombre.BackColor = Color.White;
            }
            if (TxtModelo.Text.Trim() == String.Empty)
            {
                TxtModelo.BackColor = Color.LightCyan;
                ok = false;
            }
            else
            {
                TxtModelo.BackColor = Color.White;
            }
           

            return ok;


        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                bool insert = false;
                if (_modelo == null)
                {//Nuevo
                    _modelo = new Modelo();
                    insert = true;
                }

                _modelo.Descripcion = txtDescripcion.Text.ToString();
                _modelo.Marca = (Marca)CmbMarca.SelectedItem;
                _modelo.SistemaOperativo = (SistemaOperativo)CmbSistemaOperativo.SelectedItem;
                _modelo.Modelo1 = TxtModelo.Text.ToString();
                _modelo.Nombre = TxtNombre.Text.ToString();
                _modelo.Procesador = txtProcesador.Text.ToString();
                _modelo.Memoria = txtMemoria.Text.ToString();
                _modelo.Borrado = false;

                if (insert)
                    ModeloDAO.insert(Application.StartupPath, _modelo);
                else
                    ModeloDAO.update(Application.StartupPath, _modelo);


                this.Close();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea borrar el Modelo?", "Borrar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _modelo.Borrado = true;
                ModeloDAO.update(Application.StartupPath, _modelo);
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

       

    }
}
