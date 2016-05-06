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
        public Telefono _telenofo = null;
        public Dictionary<int, Modelo> _modelos;
        public Dictionary<int, Proveedor> _proveedores;
        public Dictionary<int, Marca> _marcas;
        public Dictionary<int, SistemaOperativo> _sistemasOperativos;
        public FormTelefono()
        {
            InitializeComponent();
        }

        private void FormTelefono_Load(object sender, EventArgs e)
        {
            //CmbModelo.DataSource = _modelos.Values.ToList();
            CmbProveedor.DataSource = _proveedores.Values.ToList();
            CmbProveedor.DisplayMember = "Nombre";
            CmbProveedor.ValueMember = "Id";

            CmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
 


            if (_telenofo != null)
            {
                TxtId.Text = _telenofo.Id.ToString();
                TxtColor.Text = _telenofo.Color;
                TxtImei.Text = _telenofo.Imei.ToString();
                txtCosto.Text = _telenofo.Costo.ToString();
                List<Modelo> l = new List<Modelo>();
                l.Add(_telenofo.Modelo);
                setGridViewModelos(l);
                CmbProveedor.SelectedValue = _telenofo.Proveedor.Id;
               
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

            return ok;


        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                bool insert = false;
                if (_telenofo == null)
                {//Nuevo
                    _telenofo = new Telefono();
                    insert = true;
                }

                _telenofo.Imei = TxtImei.Text.ToString();
                _telenofo.Modelo = (Modelo)dataGridViewModelos.CurrentRow.DataBoundItem;
                _telenofo.Proveedor = (Proveedor)CmbProveedor.SelectedItem;
                _telenofo.Color = TxtColor.Text.ToString();
                _telenofo.Costo = decimal.Parse(txtCosto.Text.ToString());


                _telenofo.Borrado = false;

                if (insert)
                    TelefonoDAO.insert(Application.StartupPath, _telenofo);
                else
                    TelefonoDAO.update(Application.StartupPath, _telenofo);


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
                _telenofo.Borrado = true;
                TelefonoDAO.update(Application.StartupPath, _telenofo);
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

                if (_telenofo != null)
                {
                    List<Modelo> l = new List<Modelo>();
                    l.Add(_telenofo.Modelo);
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
