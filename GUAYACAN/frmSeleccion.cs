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
    public partial class frmSeleccion : Form
    {
        public frmSeleccion()
        {
            InitializeComponent();
        }

        private void btnDirec1_Click(object sender, EventArgs e)
        {
            if(fbdDirectorio.ShowDialog()==DialogResult.OK)
            {
                tbDTrabajo.Text = fbdDirectorio.SelectedPath.ToString();
            }
        }

        private void btnDirec2_Click(object sender, EventArgs e)
        {
            if (fbdDirectorio.ShowDialog() == DialogResult.OK)
            {
                tbDOrganizacion.Text = fbdDirectorio.SelectedPath.ToString();
            }
        }

        private void btnDirec3_Click(object sender, EventArgs e)
        {
            if (fbdDirectorio.ShowDialog() == DialogResult.OK)
            {
                tbDPublicacion.Text = fbdDirectorio.SelectedPath.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.RutaTrabajo = @tbDTrabajo.Text.ToString();
            Properties.Settings.Default.RutaOrganizacion = @tbDOrganizacion.Text.ToString();
            Properties.Settings.Default.RutaPublicacion = @tbDPublicacion.Text.ToString();
            Properties.Settings.Default.Publicar = cbPublicar.Checked;
            Properties.Settings.Default.Save();

            this.Close();

        }

        private void frmSeleccion_Load(object sender, EventArgs e)
        {
            tbDTrabajo.Text = Properties.Settings.Default.RutaTrabajo.ToString();
            tbDOrganizacion.Text = Properties.Settings.Default.RutaOrganizacion.ToString();
            tbDPublicacion.Text = Properties.Settings.Default.RutaPublicacion.ToString();
            cbPublicar.Checked = Properties.Settings.Default.Publicar;
        }
    }
}
