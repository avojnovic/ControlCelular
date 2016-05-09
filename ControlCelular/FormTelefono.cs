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
using System.Globalization;

namespace ControlCelular
{
    public partial class FormTelefono : Form
    {
        public Telefono _telefono = null;
        public Dictionary<int, Telefono> _telefonos;
        public Dictionary<int, Modelo> _modelos;
        public Dictionary<int, Proveedor> _proveedores;
        public Dictionary<int, Marca> _marcas;
        public Dictionary<int, SistemaOperativo> _sistemasOperativos;
        public List<Proveedor> _proveedoresNoBorrados;
        public FormTelefono()
        {
            InitializeComponent();
        }

        private void FormTelefono_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            //CmbModelo.DataSource = _modelos.Values.ToList();
            _proveedoresNoBorrados=(from o in _proveedores.Values.ToList() where o.Borrado == false select o).ToList();
            CmbProveedor.DataSource = _proveedoresNoBorrados;
            CmbProveedor.DisplayMember = "Nombre";
            CmbProveedor.ValueMember = "Id";

            CmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
 


            if (_telefono != null)
            {
                TxtId.Text = _telefono.Id.ToString();
                TxtColor.Text = _telefono.Color;
                TxtImei.Text = _telefono.Imei.ToString();
                txtCosto.Text = _telefono.Costo.ToString();
                List<Modelo> l = new List<Modelo>();
                l.Add(_telefono.Modelo);
                setGridViewModelos(l);

                if (!_telefono.Proveedor.Borrado)
                    CmbProveedor.SelectedValue = _telefono.Proveedor.Id;
               
            }
            else
            {
                BtnBorrar.Visible = false;
                refreshModelos(false);
                dataGridViewModelos.ClearSelection();
            }
        }


        private bool validar()
        {
            bool ok = true;
            if (TxtColor.Text.Trim() == String.Empty)
            {
                TxtColor.BackColor = Color.LightCyan;
                ok = false;
            }
            else
            {
                TxtColor.BackColor = Color.White;
            }
            if (txtCosto.Text.Trim() == String.Empty)
            {
                txtCosto.BackColor = Color.LightCyan;
                ok = false;
            }
            else
            {
                txtCosto.BackColor = Color.White;
            }
            if (TxtImei.Text.Trim().Length !=15)
            {
                TxtImei.BackColor = Color.LightCyan;
                ok = false;
            }
            else
            {
                TxtImei.BackColor = Color.White;
            }
            if (dataGridViewModelos.SelectedRows.Count==0)
            {
                txtBuscarModelos.BackColor = Color.LightCyan;
                ok = false;
            }
            else
            {
                txtBuscarModelos.BackColor = Color.White;
            }

            if (CmbProveedor.SelectedItem == null)
            {
                lblProveedor.ForeColor = Color.Red;
                ok = false;
            }
            else
            {
                lblProveedor.ForeColor = Color.Black;   
            }

            if (_telefono == null)
            {//Nuevo
                var duplicado = (from x in _telefonos.Values.ToList()
                                 where x.Imei == TxtImei.Text.ToString()
                                 select x
                                           );

                if (duplicado != null && duplicado.ToList().Count > 0)
                {
                    MessageBox.Show("El IMEI Ingresado ya existe: " + duplicado.ToList()[0].ModeloDescripcion);
                    ok = false;
                }
            }
            else
            {
                var duplicado = (from x in _telefonos.Values.ToList()
                                 where x.Imei == TxtImei.Text.ToString()
                                 select x
                                           );
                List<Telefono> list = duplicado.ToList();
                if (_telefono.Imei.Trim() != TxtImei.Text.ToString().Trim())
                {
                    if (duplicado != null && list.Count > 0)
                    {
                        MessageBox.Show("El IMEI Ingresado ya existe: " + list[0].ModeloDescripcion);
                        ok = false;
                    }
                }
            }


            return ok;


        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                bool insert = false;
                if (_telefono == null)
                {//Nuevo

                   _telefono = new Telefono();
                    insert = true;
                    _telefono.Venta = 0;
                }

                _telefono.Imei = TxtImei.Text.ToString();
                _telefono.Modelo = (Modelo)dataGridViewModelos.CurrentRow.DataBoundItem;
                _telefono.Proveedor = (Proveedor)CmbProveedor.SelectedItem;
                _telefono.Color = TxtColor.Text.ToString();
                _telefono.Costo = decimal.Parse(txtCosto.Text.ToString());


                _telefono.Borrado = false;

                if (insert)
                    TelefonoDAO.insert(Application.StartupPath, _telefono);
                else
                    TelefonoDAO.update(Application.StartupPath, _telefono);


                this.Close();
            }
      
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea borrar el telefono?", "Borrar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _telefono.Borrado = true;
                TelefonoDAO.update(Application.StartupPath, _telefono);
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
               
            }
            
          
        }

        private void refreshModelos(bool fromDB)
        {
            if (fromDB)
                _modelos = ModeloDAO.get(Application.StartupPath, _sistemasOperativos, _marcas);

            setGridViewModelos(_modelos.Values.ToList());
        }

        private void setGridViewModelos(List<Modelo> list)
        {

            dataGridViewModelos.DataSource = (from o in list where o.Borrado == false select o).ToList();
            dataGridViewModelos.Columns["SistemaOperativo"].Visible = false;
            dataGridViewModelos.Columns["Marca"].Visible = false;
            dataGridViewModelos.Columns["Modelo1"].HeaderText = "Modelo";
            dataGridViewModelos.Columns["SistemaOperativoNombre"].HeaderText = "Sistema Operativo";
            dataGridViewModelos.Columns["MarcaNombre"].HeaderText = "Marca";
            dataGridViewModelos.Columns["Borrado"].Visible = false;
            dataGridViewModelos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
        }

        private void txtBuscarModelos_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarModelos.Text.Length > 0)
            {
                var res = (from o in _modelos.Values.ToList()
                           where o.Descripcion.Trim().ToUpper().Contains(txtBuscarModelos.Text.Trim().ToUpper()) || o.MarcaNombre.Trim().ToUpper().Contains(txtBuscarModelos.Text.Trim().ToUpper()) || o.Nombre.Trim().ToUpper().Contains(txtBuscarModelos.Text.Trim().ToUpper()) || o.Procesador.Trim().ToUpper().Contains(txtBuscarModelos.Text.Trim().ToUpper()) || o.SistemaOperativoNombre.Trim().ToUpper().Contains(txtBuscarModelos.Text.Trim().ToUpper())
                           select o);


                setGridViewModelos((List<Modelo>)res.ToList());

            }
            else if (txtBuscarModelos.Text.Length == 0)
            {

                if (_telefono != null)
                {
                    List<Modelo> l = new List<Modelo>();
                    l.Add(_telefono.Modelo);
                    setGridViewModelos(l);

                }
                else
                    setGridViewModelos(_modelos.Values.ToList());

            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {

   
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) && txtCosto.Text.Contains(Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
            {
                e.Handled = true;
                return;
            }
            else
            {
                txtCosto.BackColor = Color.White;
            }
        }

        private void TxtImei_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }

            if (TxtImei.Text.Length >= 15 && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
            
        }

        static bool IsValidIMEI(string imei)
        {
            int[] n = new int[imei.Length];
            for (int i = 0; i < imei.Length; i++)
            {
                n[i] = int.Parse(imei[i].ToString());
            }

            for (int i = 0; i < imei.Length - 1; i++)
            {
                if (i % 2 == 1)
                {
                    n[i] = n[i] * 2;
                }
            }

            for (int i = 0; i < imei.Length - 1; i++)
            {
                if (i % 2 == 1)
                {
                    if (n[i].ToString().Length > 1)
                        n[i] = int.Parse(n[i].ToString()[0].ToString()) + int.Parse(n[i].ToString()[1].ToString());
                }
            }

            int total = 0;
            for (int i = 0; i < imei.Length - 1; i++)
            {
                total += n[i];
            }

            int mod = total % 10;

            if (mod > 0)
            {
                mod = 10 - mod;
            }

            return (n[imei.Length - 1] == mod);
        }

        private void TxtImei_TextChanged(object sender, EventArgs e)
        {
            if (TxtImei.Text.Length == 15)
            {
                if (IsValidIMEI(TxtImei.Text.Trim()))
                {
                    TxtImei.BackColor = Color.LightGreen;
                }
                else
                {
                    TxtImei.BackColor = Color.Red;
                }
            }
            else
            {
                TxtImei.BackColor = Color.White;
            }
        }

       

    }
}
