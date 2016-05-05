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
            _telefonos = TelefonoDAO.get(Application.StartupPath, _modelos, _proveedores);

            
            setGridViewTelefonos(_telefonos.Values.ToList());    
           
            
        }

        private void setGridViewTelefonos(List<Telefono> _telefonos)
        {
            dataGridViewTelefonos.DataSource = _telefonos;


            dataGridViewTelefonos.Columns["Proveedor"].Visible = false;
            dataGridViewTelefonos.Columns["Borrado"].Visible = false;
            dataGridViewTelefonos.Columns["Modelo"].Visible = false;
            dataGridViewTelefonos.Columns["ProveedorNombre"].HeaderText = "Nombre Proveedor";
            dataGridViewTelefonos.Columns["ModeloDescripcion"].HeaderText = "Modelo";
            dataGridViewTelefonos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
            
        }

        private void txtBuscarTefonos_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarTefonos.Text.Length > 3)
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

        private void dataGridViewTelefonos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO EDITAR

        }

        private void BtnNuevoTelefono_Click(object sender, EventArgs e)
        {
            FormTelefono _formTelefono = new FormTelefono();
            _formTelefono.ShowDialog();
        }

   

     
    }
}
