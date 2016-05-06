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
    public partial class Main : Form
    {

        Dictionary<int, Marca> _marcas = new Dictionary<int, Marca>();
        Dictionary<int, SistemaOperativo> _sistemasOperativos = new Dictionary<int, SistemaOperativo>();
        Dictionary<int, Modelo> _modelos = new Dictionary<int, Modelo>();
        Dictionary<int, Proveedor> _proveedores = new Dictionary<int, Proveedor>();
        Dictionary<int, Telefono> _telefonos = new Dictionary<int, Telefono>();
        Dictionary<int, Cliente> _clientes = new Dictionary<int, Cliente>();
        Dictionary<string, Venta> _venta = new Dictionary<string, Venta>();
                            
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
            _marcas = MarcaDAO.get(Application.StartupPath);
            _sistemasOperativos = SistemaOperativoDAO.get(Application.StartupPath);
            _modelos = ModeloDAO.get(Application.StartupPath, _sistemasOperativos, _marcas);
            _proveedores = ProveedorDAO.get(Application.StartupPath);

            refreshTelefonos(true); 
           
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string name = tabControl1.SelectedTab.Name;
           
            //if (name == "tabTelefonos" && dataGridViewTelefonos.DataSource == null)
            //{
            //    refreshTelefonos(false);
            //}

            if (name == "tabModelos" && dataGridViewModelos.DataSource == null)
            {
                refreshModelos(false);
            }

            if (name == "tabClientes" && dataGridViewClientes.DataSource == null)
            {
                refreshClientes(true);
            }
            if (name == "tabVentas")
            {
                refreshVentas(true);
            }

        }

        private void refreshVentas(bool fromDB)
        {
            if (fromDB)
                _clientes = ClienteDAO.get(Application.StartupPath);

            cmbClienteVenta.DataSource = _clientes.Values.ToList() ;
            cmbClienteVenta.DisplayMember = "NombreCompleto";
            cmbClienteVenta.ValueMember = "Id";
        }

        private void refreshTelefonos(bool fromDB)
        {
            if(fromDB)
                _telefonos = TelefonoDAO.get(Application.StartupPath, _modelos, _proveedores);

            setGridViewTelefonos(_telefonos.Values.ToList());
        }

        private void setGridViewTelefonos(List<Telefono> list)
        {
    
            dataGridViewTelefonos.DataSource = (from o in list where o.Borrado == false select o).ToList();
            dataGridViewTelefonos.Columns["Proveedor"].Visible = false;
            dataGridViewTelefonos.Columns["Borrado"].Visible = false;
            dataGridViewTelefonos.Columns["Modelo"].Visible = false;
            dataGridViewTelefonos.Columns["ProveedorNombre"].HeaderText = "Nombre Proveedor";
            dataGridViewTelefonos.Columns["ModeloDescripcion"].HeaderText = "Modelo";
            dataGridViewTelefonos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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
            dataGridViewModelos.Columns["ModeloDescripcion"].Visible = false;
            dataGridViewModelos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        private void refreshClientes(bool fromDB)
        {
            if (fromDB)
                _clientes = ClienteDAO.get(Application.StartupPath);

            setGridViewClientes(_clientes.Values.ToList());
        }

        private void setGridViewClientes(List<Cliente> list)
        {


            dataGridViewClientes.DataSource = (from o in list where o.Borrado == false select o).ToList();

            dataGridViewClientes.Columns["Borrado"].Visible = false;
            dataGridViewClientes.Columns["NombreCompleto"].Visible = false;

            dataGridViewClientes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void txtBuscarTefonos_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarTefonos.Text.Length > 0)
            {
                var res = (from o in _telefonos.Values.ToList()
                           where o.Borrado==false && (o.Imei.Trim().ToUpper().Contains(txtBuscarTefonos.Text.Trim().ToUpper()) || o.Color.Trim().ToUpper().Contains(txtBuscarTefonos.Text.Trim().ToUpper()) || o.ModeloDescripcion.Trim().ToUpper().Contains(txtBuscarTefonos.Text.Trim().ToUpper()) || o.ProveedorNombre.Trim().ToUpper().Contains(txtBuscarTefonos.Text.Trim().ToUpper()))
                           select o);


                setGridViewTelefonos((List<Telefono>)res.ToList());
              
            }
            else if (txtBuscarTefonos.Text.Length==0)
            {

                setGridViewTelefonos(_telefonos.Values.ToList());
                
            }

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

                setGridViewModelos(_modelos.Values.ToList());

            }
        }


        private void BtnNuevoTelefono_Click(object sender, EventArgs e)
        {
            FormTelefono _formTelefono = new FormTelefono();
            _formTelefono._modelos = _modelos;
            _formTelefono._proveedores = _proveedores;
            _formTelefono.ShowDialog();

            refreshTelefonos(true);

        }

        private void dataGridViewTelefonos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            Telefono currentObject = (Telefono)dataGridViewTelefonos.CurrentRow.DataBoundItem;

            FormTelefono _formTelefono = new FormTelefono();
            _formTelefono._modelos = _modelos;
            _formTelefono._proveedores = _proveedores;
            _formTelefono._telenofo = currentObject;
            _formTelefono.ShowDialog();

            refreshTelefonos(true);

        }

       

        private void BtnNuevoModelo_Click(object sender, EventArgs e)
        {
            FormModelo _form = new FormModelo();
            
            _form._marcas = _marcas;
            _form._sistemasOperativos=_sistemasOperativos;
            _form.ShowDialog();
            refreshModelos(true);
        }

        private void dataGridViewModelos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            Modelo currentObject = (Modelo)dataGridViewModelos.CurrentRow.DataBoundItem;

            FormModelo _form = new FormModelo();
            _form._marcas = _marcas;
            _form._sistemasOperativos= _sistemasOperativos;
            _form._modelo = currentObject;
            _form.ShowDialog();

            refreshModelos(true);
        }

        private void btnClienteNuevo_Click(object sender, EventArgs e)
        {
            FormCliente _form = new FormCliente();

            _form.ShowDialog();
            refreshClientes(true);
        }

        private void txtBuscarClientes_TextChanged(object sender, EventArgs e)
        {

            if (txtBuscarClientes.Text.Length > 0)
            {
                var res = (from o in _clientes.Values.ToList()
                           where o.Nombre.Trim().ToUpper().Contains(txtBuscarClientes.Text.Trim().ToUpper()) || o.Apellido.Trim().ToUpper().Contains(txtBuscarClientes.Text.Trim().ToUpper()) || o.Descripcion.Trim().ToUpper().Contains(txtBuscarClientes.Text.Trim().ToUpper()) || o.NombreCompleto.Trim().ToUpper().Contains(txtBuscarClientes.Text.Trim().ToUpper()) 
                           select o);

                setGridViewClientes((List<Cliente>)res.ToList());

            }
            else if (txtBuscarClientes.Text.Length == 0)
            {

                setGridViewClientes(_clientes.Values.ToList());

            }
        }

        private void dataGridViewClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente currentObject = (Cliente)dataGridViewClientes.CurrentRow.DataBoundItem;

            FormCliente _form = new FormCliente();

            _form._cliente = currentObject;
            _form.ShowDialog();

            refreshClientes(true);
        }

        private void txtImeiVenta_TextChanged(object sender, EventArgs e)
        {
            if (txtImeiVenta.Text.Length == 15)
            {
                Telefono t = validarTelefono(txtImeiVenta.Text.Trim());
                if (t!=null)
                {
                    txtImeiVenta.BackColor = Color.LightGreen;
                    txtCostoVenta.Text = t.Costo.ToString();
                    txtEquipoVenta.Text = t.ModeloDescripcion;
                }
                else
                {
                    txtImeiVenta.BackColor = Color.Red;
                    txtCostoVenta.Text = "";
                    txtEquipoVenta.Text = "";
                }
            }
            else
            {
                txtImeiVenta.BackColor = Color.White;
                txtCostoVenta.Text = "";
                txtEquipoVenta.Text = "";
            }
        }

        private void txtImeiVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }

            if (txtImeiVenta.Text.Length >= 15 && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
            {
                e.Handled = true;
                return;
            }
            else
            {
                txtPrecioVenta.BackColor = Color.White;
            }
        }


        private Telefono validarTelefono(string imei)
        { 
     
                 var res = (from o in _telefonos.Values.ToList()
                           where o.Imei==imei
                           select o);

                 if (res.ToList().Count() == 1)
                     return (Telefono)res.ToList()[0];
                 else
                     return null;

        }

        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if (txtImeiVenta.Text.Length == 15)
            {
                Telefono t = validarTelefono(txtImeiVenta.Text.Trim());
                if (t == null)
                {
                    ok = false;
                    txtImeiVenta.BackColor = Color.Red;
                }
                if (txtPrecioVenta.Text.Length == 0)
                {
                    ok = false;
                    txtPrecioVenta.BackColor = Color.Red;
                }
                if (cmbClienteVenta.SelectedItem == null)
                {
                    ok = false;
                }

                

              

                if (ok)
                {

                    if (_venta.ContainsKey(t.Imei))
                        ok = false;

                    if (ok)
                    {

                        Venta _v = new Venta();
                        _v.Cliente = (Cliente)cmbClienteVenta.SelectedItem;
                        _v.Fecha = DateTime.Today;
                        _v.Monto = decimal.Parse(txtPrecioVenta.Text.ToString());
                        _v.Telefono = t;

                        _venta.Add(_v.TelefonoImei,_v);
                        refreshGrillaVenta(_venta.Values.ToList());
                        txtPrecioVenta.Text = "";
                        txtImeiVenta.Text = "";
                        txtEquipoVenta.Text = "";
                        txtCostoVenta.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Imei ya ingresado");
                    }
                }

            }
            else
            { 
            
            }

        }

        private void refreshGrillaVenta(List<Venta> _venta)
        {
            dataGridViewVentas.DataSource = _venta;

            dataGridViewVentas.Columns["Borrado"].Visible = false;
            dataGridViewVentas.Columns["Id"].Visible = false;
            dataGridViewVentas.Columns["Cobrado"].Visible = false;
            dataGridViewVentas.Columns["FechaCobro"].Visible = false;
            dataGridViewVentas.Columns["Cliente"].Visible = false;
            dataGridViewVentas.Columns["Telefono"].Visible = false;
            dataGridViewVentas.Columns["ClienteNombre"].HeaderText = "Cliente";
            dataGridViewVentas.Columns["TelefonoCompleto"].HeaderText = "Modelo Telefono";
            dataGridViewVentas.Columns["TelefonoImei"].HeaderText = "Imei";
            dataGridViewVentas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void btnQuitarVenta_Click(object sender, EventArgs e)
        {
            if (dataGridViewVentas.CurrentRow != null)
            {
                Venta currentObject = (Venta)dataGridViewVentas.CurrentRow.DataBoundItem;

                _venta.Remove(currentObject.TelefonoImei);
                refreshGrillaVenta(_venta.Values.ToList());
            }

        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea Guardar la venta?", "Guardar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                foreach (Venta x in _venta.Values.ToList())
                {
                    VentaDAO.insert(Application.StartupPath, x);
                
                }


                _venta = null;
                dataGridViewVentas.DataSource = null;
                txtCostoVenta.Text = "";
                txtEquipoVenta.Text = "";
                txtPrecioVenta.Text = "";
                txtImeiVenta.Text = "";

            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea cancelar la venta?", "Cancelar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _venta = null;
                dataGridViewVentas.DataSource = null;
                txtCostoVenta.Text = "";
                txtEquipoVenta.Text = "";
                txtPrecioVenta.Text = "";
                txtImeiVenta.Text = "";
               
            }
            else if (dialogResult == DialogResult.No)
            {

            }

        }



   

     
    }
}
