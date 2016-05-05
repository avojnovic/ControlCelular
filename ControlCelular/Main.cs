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
    public partial class Main : Form
    {

        Dictionary<int, Marca> _marcas = new Dictionary<int, Marca>();
        Dictionary<int, SistemaOperativo> _sistemasOperativos = new Dictionary<int, SistemaOperativo>();
        Dictionary<int, Modelo> _modelos = new Dictionary<int, Modelo>();
        Dictionary<int, Proveedor> _proveedores = new Dictionary<int, Proveedor>();
        Dictionary<int, Telefono> _telefonos = new Dictionary<int, Telefono>(); 

                            
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

        private void refreshTelefonos(bool fromDB)
        {
            if(fromDB)
                _telefonos = TelefonoDAO.get(Application.StartupPath, _modelos, _proveedores);

            setGridViewTelefonos(_telefonos.Values.ToList());
        }

        private void setGridViewTelefonos(List<Telefono> list)
        {
            dataGridViewTelefonos.DataSource = list;
            dataGridViewTelefonos.Columns["Proveedor"].Visible = false;
            dataGridViewTelefonos.Columns["Borrado"].Visible = false;
            dataGridViewTelefonos.Columns["Modelo"].Visible = false;
            dataGridViewTelefonos.Columns["ProveedorNombre"].HeaderText = "Nombre Proveedor";
            dataGridViewTelefonos.Columns["ModeloDescripcion"].HeaderText = "Modelo";
            dataGridViewTelefonos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
        }


        private void refreshModelos(bool fromDB)
        {
            if (fromDB)
                _modelos = ModeloDAO.get(Application.StartupPath, _sistemasOperativos, _marcas);

            setGridViewModelos(_modelos.Values.ToList());
        }

        private void setGridViewModelos(List<Modelo> list)
        {

            dataGridViewModelos.DataSource = list;
            dataGridViewModelos.Columns["SistemaOperativo"].Visible = false;
            dataGridViewModelos.Columns["Marca"].Visible = false;
            dataGridViewModelos.Columns["Modelo1"].HeaderText = "Modelo";
            dataGridViewModelos.Columns["SistemaOperativoNombre"].HeaderText = "Sistema Operativo";
            dataGridViewModelos.Columns["MarcaNombre"].HeaderText = "Marca";
            dataGridViewModelos.Columns["Borrado"].Visible = false;
            dataGridViewModelos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
        }

        private void txtBuscarTefonos_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarTefonos.Text.Length > 0)
            {
                var res = (from o in _telefonos.Values.ToList()
                           where o.Imei.Trim().ToUpper().Contains(txtBuscarTefonos.Text.Trim().ToUpper()) || o.Color.Trim().ToUpper().Contains(txtBuscarTefonos.Text.Trim().ToUpper()) || o.ModeloDescripcion.Trim().ToUpper().Contains(txtBuscarTefonos.Text.Trim().ToUpper()) || o.ProveedorNombre.Trim().ToUpper().Contains(txtBuscarTefonos.Text.Trim().ToUpper())
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

          string name=  tabControl1.SelectedTab.Text;

          if (name == "Modelos" && dataGridViewModelos.DataSource==null)
          {
              refreshModelos(false);
          }

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

       

   

     
    }
}
