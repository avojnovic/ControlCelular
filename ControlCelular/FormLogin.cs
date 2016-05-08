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
    public partial class FormLogin : Form
    {
        Dictionary<int, Usuario> _usuarios = new Dictionary<int, Usuario>();
        public bool loginok = false;
        public FormLogin()
        {
            InitializeComponent();

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.CenterToScreen();

            _usuarios = UsuarioDAO.get(Application.StartupPath);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            trylogin();
        }

        private void trylogin()
        {
            List<Usuario> list = (from o in _usuarios.Values.ToList() where o.NombreUsuario.ToLower() == txtUsuario.Text.ToString().Trim().ToLower() && o.Password.ToLower() == txtPassword.Text.ToString().Trim().ToLower() select o).ToList();


            if (list.Count == 1)
            {
                loginok = true;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos!");
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                trylogin();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                trylogin();
            }
        }
    }
}
