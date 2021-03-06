﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessObjects;
using DAO;
using System.Globalization;

namespace ControlCelular
{
    public partial class FormCliente : Form
    {
        public Cliente _cliente = null;

        public FormCliente()
        {
            InitializeComponent();

          
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {

            this.CenterToScreen();
            if (_cliente != null)
            {
                TxtId.Text = _cliente.Id.ToString();
                TxtNombre.Text = _cliente.Nombre;
                txtDescripcion.Text = _cliente.Descripcion;
                TxtApellido.Text = _cliente.Apellido;
                txtDeuda.Text = _cliente.Deuda.ToString();


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
            if (TxtApellido.Text.Trim() == String.Empty)
            {
                TxtApellido.BackColor = Color.LightCyan;
                ok = false;
            }
            else
            {
                TxtApellido.BackColor = Color.White;
            }


            return ok;


        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                bool insert = false;
                if (_cliente == null)
                {//Nuevo
                    _cliente = new Cliente();
                    insert = true;
                }

                _cliente.Descripcion = txtDescripcion.Text.ToString();


                _cliente.Nombre = TxtNombre.Text.ToString();
                _cliente.Apellido = TxtApellido.Text.ToString();
               // _cliente.Deuda = decimal.Parse(txtDeuda.Text.ToString());
                _cliente.Borrado = false;

                if (insert)
                   ClienteDAO.insert(Application.StartupPath, _cliente);
                else
                    ClienteDAO.update(Application.StartupPath, _cliente);


                this.Close();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea borrar el Cliente?", "Borrar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _cliente.Borrado = true;
                ClienteDAO.update(Application.StartupPath, _cliente);
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void txtDeuda_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar != '-') && !(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
            {
              
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '-' && txtDeuda.Text.ToString().Length > 0)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) && txtDeuda.Text.Contains(Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
            {
                e.Handled = true;
                return;
            }
          
        }

       
    }
}
