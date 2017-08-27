using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUAYACAN
{
    public partial class frmCfgFTP : Form
    {
        public frmCfgFTP()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SrvFTP = tbServidor.Text.ToString();
            Properties.Settings.Default.UsuarioFTP = tbUsuario.Text.ToString();
            Properties.Settings.Default.PwdFTP = tbContraseña.Text.ToString();
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCfgFTP_Load(object sender, EventArgs e)
        {
            tbServidor.Text = Properties.Settings.Default.SrvFTP.ToString();
            tbUsuario.Text = Properties.Settings.Default.UsuarioFTP.ToString();
            tbContraseña.Text = Properties.Settings.Default.PwdFTP.ToString();
        }
    }
}
