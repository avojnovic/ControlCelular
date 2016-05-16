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
using System.IO;

namespace ControlCelular
{
    public partial class Main : Form
    {

        Dictionary<int, Marca> _marcas = new Dictionary<int, Marca>();
        Dictionary<int, ColorTelefono> _colores = new Dictionary<int, ColorTelefono>();
        Dictionary<int, SistemaOperativo> _sistemasOperativos = new Dictionary<int, SistemaOperativo>();
        Dictionary<int, Modelo> _modelos = new Dictionary<int, Modelo>();
        Dictionary<int, Proveedor> _proveedores = new Dictionary<int, Proveedor>();
        Dictionary<int, Telefono> _telefonos = new Dictionary<int, Telefono>();
        Dictionary<int, Cliente> _clientes = new Dictionary<int, Cliente>();
        Dictionary<string, Venta> _venta = new Dictionary<string, Venta>();
        Dictionary<int, Venta> _historialVentas = new Dictionary<int, Venta>();
        bool loginok = false;
        public Main()
        {
            InitializeComponent();
        }


        private void Main_Load(object sender, EventArgs e)
        {

            this.Hide();

            FormLogin logon = new FormLogin();

            if (logon.ShowDialog() != DialogResult.OK)
            {

                //Handle authentication failures as necessary, for example:
                Application.Exit();
            }
            else
            {
                loginok = logon.loginok;
                this.CenterToScreen();

                _colores = ColorDAO.get(Application.StartupPath);
                _marcas = MarcaDAO.get(Application.StartupPath);
                _sistemasOperativos = SistemaOperativoDAO.get(Application.StartupPath);
                _modelos = ModeloDAO.get(Application.StartupPath, _sistemasOperativos, _marcas);
                _proveedores = ProveedorDAO.get(Application.StartupPath);
                _clientes = ClienteDAO.get(Application.StartupPath);
                refreshTelefonos(true);

                this.Show();

            }


            if (!loginok)
            {
                this.Close();
            }




        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string name = tabControl1.SelectedTab.Name;

            if (name == "tabTelefonos")
            {
                refreshTelefonos(true);
            }

            if (name == "tabModelos" )
            {
                refreshModelos(true);
            }

            if (name == "tabClientes")
            {
                refreshClientes(true);
            }
            if (name == "tabVentas" && dataGridViewVentas.DataSource==null)
            {
                refreshVentas(false);
            }
            if (name == "tabHistorialVentas")
            {
                refreshHistorialVentas(true);
            }

            if (name == "tabProveedores")
            {
                refreshProveedores(true);
            }


        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
            {
                if (dGV.Columns[j].Visible)
                    sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            }
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                {
                    if (dGV.Rows[i].Cells[j].Visible)
                        stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";

                }
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        #region Proveedores
        private void refreshProveedores(bool fromDB)
        {
            if (fromDB)
                _proveedores = ProveedorDAO.get(Application.StartupPath);

            setGridViewProveedores(_proveedores.Values.ToList());
        }

        private void setGridViewProveedores(List<Proveedor> list)
        {

            dataGridViewProveedor.DataSource = (from o in list where o.Borrado == false select o).ToList();

            dataGridViewProveedor.Columns["Borrado"].Visible = false;

            dataGridViewProveedor.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnExportarProveedores_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                ToCsV(dataGridViewProveedor, sfd.FileName);

            }
        }
        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            FormProveedor _form = new FormProveedor();

            _form.ShowDialog();
            refreshProveedores(true);
        }

        private void txtBuscarProveedor_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarProveedor.Text.Length > 0)
            {
                var res = (from o in _proveedores.Values.ToList()
                           where o.Nombre.Trim().ToUpper().Contains(txtBuscarProveedor.Text.Trim().ToUpper()) || o.Descripcion.Trim().ToUpper().Contains(txtBuscarProveedor.Text.Trim().ToUpper())
                           select o);

                setGridViewProveedores((List<Proveedor>)res.ToList());

            }
            else if (txtBuscarProveedor.Text.Length == 0)
            {

                setGridViewProveedores(_proveedores.Values.ToList());

            }
        }

        private void dataGridViewProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Proveedor currentObject = (Proveedor)dataGridViewProveedor.CurrentRow.DataBoundItem;

            FormProveedor _form = new FormProveedor();

            _form._proveedor = currentObject;
            _form.ShowDialog();

            refreshProveedores(true);
        }


        #endregion

        #region Historial de Ventas
        private void refreshHistorialVentas(bool fromDB)
        {
            if (fromDB)
                _historialVentas = VentaDAO.get(Application.StartupPath, _telefonos, _clientes);

            setGridViewHistorialVentas(_historialVentas.Values.ToList());
        }

        private void btnExportarHistorialVentas_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                ToCsV(dataGridViewHistorialVentas, sfd.FileName);

            }
        }

        private void setGridViewHistorialVentas(List<Venta> list)
        {
            dataGridViewHistorialVentas.DataSource = (from o in list where o.Borrado == false select o).ToList();

            dataGridViewHistorialVentas.Columns["Borrado"].Visible = false;
            dataGridViewHistorialVentas.Columns["Telefono"].Visible = false;
            dataGridViewHistorialVentas.Columns["Cliente"].Visible = false;
            dataGridViewHistorialVentas.Columns["Cobrado"].Visible = false;
            dataGridViewHistorialVentas.Columns["FechaCobro"].Visible = false;

            dataGridViewHistorialVentas.Columns["ClienteNombre"].HeaderText = "Cliente";
            dataGridViewHistorialVentas.Columns["TelefonoCompleto"].HeaderText = "Telefono";
            dataGridViewHistorialVentas.Columns["TelefonoImei"].HeaderText = "IMEI";
            dataGridViewHistorialVentas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        #endregion

        #region Ventas
        private void refreshVentas(bool fromDB)
        {
            if (fromDB)
                _clientes = ClienteDAO.get(Application.StartupPath);

            cmbClienteVenta.DataSource = (from o in _clientes.Values.ToList() where o.Borrado == false select o).ToList();
            cmbClienteVenta.DisplayMember = "NombreCompleto";
            cmbClienteVenta.ValueMember = "Id";
        }

        private void txtImeiVenta_TextChanged(object sender, EventArgs e)
        {
            if (txtImeiVenta.Text.Length == 15)
            {
                Telefono t = validarTelefono(txtImeiVenta.Text.Trim());
                if (t != null)
                {
                    txtImeiVenta.BackColor = Color.LightGreen;
                    txtCostoVenta.Text = t.Costo.ToString();
                    txtEquipoVenta.Text = t.ModeloDescripcion;
                    txtPrecioVenta.Focus();
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
            if (txtPrecioVenta.Text.Length > 0 && e.KeyChar == (char)Keys.Enter)
            {
                agregarVenta();
            }
            else
            {

                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
                {
                    e.Handled = true;
                    return;
                }
                else
                {
                    if (e.KeyChar == Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) && txtPrecioVenta.Text.Contains(Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
                    {
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        txtPrecioVenta.BackColor = Color.White;
                    }


                }

            }
         
        }

        private Telefono validarTelefono(string imei)
        {

            var res = (from o in _telefonos.Values.ToList()
                       where o.Imei == imei
                       select o);

            if (res.ToList().Count() == 1)
                return (Telefono)res.ToList()[0];
            else
                return null;

        }

        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            agregarVenta();


        }

        private void agregarVenta()
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
                else
                {
                    if (t.VendidoBool)
                    {
                        ok = false;
                        MessageBox.Show("Telefono ya fue vendido");

                    }
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

                        _venta.Add(_v.TelefonoImei, _v);
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

            txtImeiVenta.Focus();
        }

        private void refreshGrillaVenta(List<Venta> _venta)
        {
            if (_venta.Count > 0)
            {
                cmbClienteVenta.Enabled = false;
               txtTotal.Text= _venta.AsEnumerable().Sum(o => o.Monto).ToString();
            }
            else
            {
                cmbClienteVenta.Enabled = true;
                txtTotal.Text = "";
            }

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
            if (_venta == null || _venta.Values.ToList().Count == 0)
            {
                MessageBox.Show("No se ingresaron telefonos en la venta");

            }
            else
            {
                if (txtPagadoVenta.Text.Trim() == string.Empty)
                {
                    txtPagadoVenta.BackColor = Color.Red;
                }
                else
                {

                    DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea Guardar la venta?", "Guardar", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {


                        foreach (Venta x in _venta.Values.ToList())
                        {
                            VentaDAO.insert(Application.StartupPath, x);
                            
                        }

                        decimal monto = 0;

                        monto = _venta.Values.ToList().AsEnumerable().Sum(o => o.Monto);

                        monto = monto - decimal.Parse(txtPagadoVenta.Text.ToString());
                        Cliente cli = (Cliente)cmbClienteVenta.SelectedItem;
                        cli.Deuda = cli.Deuda + monto;

                        if (monto != 0)
                        {
                            ClienteDAO.update(Application.StartupPath, cli);
                        }

                        _venta = new Dictionary<string,Venta>();
                        dataGridViewVentas.DataSource = null;
                        txtCostoVenta.Text = "";
                        txtEquipoVenta.Text = "";
                        txtPrecioVenta.Text = "";
                        txtImeiVenta.Text = "";
                        txtPagadoVenta.Text = "";
                        txtTotal.Text = "";
                        cmbClienteVenta.Enabled = true;

                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }
            }
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea cancelar la venta?", "Cancelar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _venta = new Dictionary<string,Venta>();
                dataGridViewVentas.DataSource = null;
                txtCostoVenta.Text = "";
                txtEquipoVenta.Text = "";
                txtPrecioVenta.Text = "";
                txtImeiVenta.Text = "";
                txtPagadoVenta.Text = "";
                txtTotal.Text = "";
                cmbClienteVenta.Enabled = true;

            }
            else if (dialogResult == DialogResult.No)
            {

            }

        }

        private void txtPagadoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
            {
                e.Handled = true;
                return;
            }
            else
            {
                if (e.KeyChar == Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) && txtPagadoVenta.Text.Contains(Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
                {
                    e.Handled = true;
                    return;
                }
                else
                {
                    txtPagadoVenta.BackColor = Color.White;
                }


            }

        }


        #endregion

        #region Telefonos
        private void refreshTelefonos(bool fromDB)
        {
            if (fromDB)
                _telefonos = TelefonoDAO.get(Application.StartupPath, _modelos, _proveedores, _colores);


            setGridViewTelefonos(_telefonos.Values.ToList());
        }

        private void setGridViewTelefonos(List<Telefono> list)
        {

            dataGridViewTelefonos.DataSource = (from o in list where o.Borrado == false select o).ToList();
            dataGridViewTelefonos.Columns["Proveedor"].Visible = false;
            dataGridViewTelefonos.Columns["Borrado"].Visible = false;
            dataGridViewTelefonos.Columns["Modelo"].Visible = false;
            dataGridViewTelefonos.Columns["Venta"].Visible = false;
            dataGridViewTelefonos.Columns["Color"].Visible = false;
            dataGridViewTelefonos.Columns["VendidoBool"].Visible = false;
            dataGridViewTelefonos.Columns["ColorNombre"].HeaderText = "Color";
            dataGridViewTelefonos.Columns["ProveedorNombre"].HeaderText = "Nombre Proveedor";
            dataGridViewTelefonos.Columns["ModeloDescripcion"].HeaderText = "Modelo";
            dataGridViewTelefonos.Columns["FechaCompra"].HeaderText = "Fecha Compra";
            dataGridViewTelefonos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnExportTelefonos_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                ToCsV(dataGridViewTelefonos, sfd.FileName);

            }
        }
        private void txtBuscarTefonos_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarTefonos.Text.Length > 0)
            {
                var res = (from o in _telefonos.Values.ToList()
                           where o.Borrado == false && (o.Imei.Trim().ToUpper().Contains(txtBuscarTefonos.Text.Trim().ToUpper()) || o.ColorNombre.Trim().ToUpper().Contains(txtBuscarTefonos.Text.Trim().ToUpper()) || o.ModeloDescripcion.Trim().ToUpper().Contains(txtBuscarTefonos.Text.Trim().ToUpper()) || o.ProveedorNombre.Trim().ToUpper().Contains(txtBuscarTefonos.Text.Trim().ToUpper()))
                           select o);


                setGridViewTelefonos((List<Telefono>)res.ToList());

            }
            else if (txtBuscarTefonos.Text.Length == 0)
            {

                setGridViewTelefonos(_telefonos.Values.ToList());

            }

        }

        private void BtnNuevoTelefono_Click(object sender, EventArgs e)
        {
            FormTelefono _formTelefono = new FormTelefono();
            _formTelefono._telefonos = _telefonos;
            _formTelefono._modelos = _modelos;
            _formTelefono._proveedores = _proveedores;
            _formTelefono._colores = _colores;
            _formTelefono.ShowDialog();

            refreshTelefonos(true);

        }

        private void dataGridViewTelefonos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            Telefono currentObject = (Telefono)dataGridViewTelefonos.CurrentRow.DataBoundItem;

            FormTelefono _formTelefono = new FormTelefono();
            _formTelefono._telefonos = _telefonos;
            _formTelefono._modelos = _modelos;
            _formTelefono._proveedores = _proveedores;
            _formTelefono._colores = _colores;
            _formTelefono._telefono = currentObject;
            _formTelefono.ShowDialog();

            refreshTelefonos(true);

        }

        #endregion

        #region Modelos

        private void refreshModelos(bool fromDB)
        {
            if (fromDB)
                _modelos = ModeloDAO.get(Application.StartupPath, _sistemasOperativos, _marcas);


            foreach (Modelo item in _modelos.Values.ToList())
            {
                 var res = (from o in _telefonos.Values.ToList()
                           where o.Modelo.Id==item.Id && !o.VendidoBool && !o.Borrado
                           select o);

                 item.Stock = res.ToList().Count();
            }

            setGridViewModelos(_modelos.Values.ToList());
        }

        private void btnExportarModelos_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                ToCsV(dataGridViewModelos, sfd.FileName);

            }
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

        private void BtnNuevoModelo_Click(object sender, EventArgs e)
        {
            FormModelo _form = new FormModelo();

            _form._marcas = _marcas;
            _form._sistemasOperativos = _sistemasOperativos;
            _form.ShowDialog();
            refreshModelos(true);
        }

        private void dataGridViewModelos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            Modelo currentObject = (Modelo)dataGridViewModelos.CurrentRow.DataBoundItem;

            FormModelo _form = new FormModelo();
            _form._marcas = _marcas;
            _form._sistemasOperativos = _sistemasOperativos;
            _form._modelo = currentObject;
            _form.ShowDialog();

            refreshModelos(true);
        }
        #endregion

        #region Clientes
        private void refreshClientes(bool fromDB)
        {
            if (fromDB)
                _clientes = ClienteDAO.get(Application.StartupPath);

            setGridViewClientes(_clientes.Values.ToList());
        }

        private void btnExportarClientes_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                ToCsV(dataGridViewClientes, sfd.FileName);

            }
        }

        private void setGridViewClientes(List<Cliente> list)
        {


            dataGridViewClientes.DataSource = (from o in list where o.Borrado == false select o).ToList();

            dataGridViewClientes.Columns["Borrado"].Visible = false;
            dataGridViewClientes.Columns["NombreCompleto"].Visible = false;

            dataGridViewClientes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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

        #endregion


        



       

       

       

        

        



    }
}
