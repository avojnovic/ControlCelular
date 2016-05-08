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
    public partial class FormProveedor : Form
    {
        public FormProveedor()
        {
            InitializeComponent();
        }

       public Proveedor _proveedor;

       private void FormProveedor_Load(object sender, EventArgs e)
       {
           this.CenterToScreen();
           if (_proveedor != null)
           {
               TxtId.Text = _proveedor.Id.ToString();
               TxtNombre.Text = _proveedor.Nombre;
               txtDescripcion.Text = _proveedor.Descripcion;
            

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
         


           return ok;


       }

       private void BtnGuardar_Click(object sender, EventArgs e)
       {
           if (validar())
           {
               bool insert = false;
               if (_proveedor == null)
               {//Nuevo
                   _proveedor = new Proveedor();
                   insert = true;
               }

               _proveedor.Descripcion = txtDescripcion.Text.ToString();


               _proveedor.Nombre = TxtNombre.Text.ToString();
               
               _proveedor.Borrado = false;

               if (insert)
                   ProveedorDAO.insert(Application.StartupPath, _proveedor);
               else
                   ProveedorDAO.update(Application.StartupPath, _proveedor);


               this.Close();
           }
       }

       private void BtnCancelar_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void BtnBorrar_Click(object sender, EventArgs e)
       {
           DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea borrar el Proveedor?", "Borrar", MessageBoxButtons.YesNo);
           if (dialogResult == DialogResult.Yes)
           {
               _proveedor.Borrado = true;
               ProveedorDAO.update(Application.StartupPath, _proveedor);
               this.Close();
           }
           else if (dialogResult == DialogResult.No)
           {

           }
       }

    }
}
