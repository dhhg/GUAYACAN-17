using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using LachosXML;
using System.IO;

namespace GUAYACAN
{
    public partial class frmCancelacion : Form
    {

        private dbConexionSQL db;
        private string CadenaConexion;
        private string dbUsr;
        private string dbPwd;

        public frmCancelacion()
        {
            InitializeComponent();
        }

        private void tbRFC_Leave(object sender, EventArgs e)
        {
            if (tbRFC.Text.Length == 12 || tbRFC.Text.Length == 13)
            {
                string query = "select t1.preriodo from recibos t1 inner join tbEmpresa t2 on t1.rfcemisro = t2.RFCEmpresa where t1.rfcemisro='" + tbRFC.Text.ToString() +"' group by t1.preriodo";
                cbTipo.Items.Clear();
                cbTipo=Carga_Combo(tbRFC.Text.ToString(),query,cbTipo);
            }
            else
            {
                MessageBox.Show("No se ingreso el dato correcto del R.F.C.","Advertencia");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCancelacion_Load(object sender, EventArgs e)
        {
            LeerConexion();
            db = new dbConexionSQL(@CadenaConexion);
        }

        private void LeerConexion()
        {
            XMLLachos dbConf = new XMLLachos();
            dbConf.Ruta = @Application.StartupPath.ToString();
            dbConf.NomArch = "db-configuracion.xml";

            dbConf.leer();

            this.CadenaConexion = dbConf.CadenaConexion.ToString();
            this.dbUsr = dbConf.Usuario.ToString();
            this.dbPwd = dbConf.Password.ToString();

        }


        private ComboBox Carga_Combo(string rfc, string query, ComboBox Lista)
        {
            //string query = "select t1.numeroperiodo from recibos t1 inner join tbEmpresa t2 on t1.rfcemisro = t2.RFCEmpresa where t1.rfcemisro='"+rfc+"' group by t1.numeroperiodo";
            db.Consultar(query,"Periodo");
            DataTable Periodos = new DataTable();
            db.da.Fill(Periodos);
            db.Desconectar();
            int i=0;
            while (i < Periodos.Rows.Count)
            {
                Lista.Items.Add(Periodos.Rows[i][0]);
                i++;
            }
            return Lista;
        }

        private void LlenarTabla(string rfc, string numperiodo, string periodo)
        {
            string query = "select preriodo as 'Tipo', NumeroPeriodo as 'Periodo', fechapago as 'Fecha', Receptor as 'Empleado' ,foliofiscal as 'UUID' from Recibos where rfcemisro='" + rfc + "' and numeroperiodo ='" + numperiodo + "' and preriodo='" + periodo + "'";
            db.Consultar(query, "Tabla");
            DataTable Info = new DataTable();
            db.da.Fill(Info);
            db.Desconectar();

            dgvInformacion.DataSource = Info;
        }

        private void cbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarTabla(tbRFC.Text.ToString(), cbPeriodo.Text.ToString(),cbTipo.Text.ToString());
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select t1.numeroperiodo from recibos t1 inner join tbEmpresa t2 on t1.rfcemisro = t2.RFCEmpresa where t1.rfcemisro='" + tbRFC.Text.ToString() + "' and t1.preriodo='" + cbTipo.Text.ToString() +"' group by t1.numeroperiodo";
            cbPeriodo.Items.Clear();
            cbPeriodo = Carga_Combo(tbRFC.Text.ToString(), query, cbPeriodo);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta;
                respuesta = MessageBox.Show("¿Esta seguro que desea eliminar los recibos del periodo seleccionado?", "Eliminación de Archivos", MessageBoxButtons.YesNo);
                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    string query = "SELECT GUIDArchivo, ruta as r_org, RutaPublicar as r_publicar, archivopdf, archivoxml  FROM RECIBOS where rfcemisro='" + tbRFC.Text.ToString() + "' AND preriodo='" + cbTipo.Text.ToString() + "' and numeroperiodo=" + cbPeriodo.Text.ToString();
                    //"SELECT GUIDArchivo, (RutaPublicar +'\\'+ archivoxml) as publico_xml, (RutaPublicar +'\'+ archivopdf) as publico_pdf, (ruta+'\'+archivoxml) org_xml, (ruta+'\'+archivopdf) org_pdf  FROM RECIBOS where rfcemisro='"+tbRFC.Text.ToString()+"' AND preriodo='"+cbTipo.Text.ToString()+"' and numeroperiodo="+cbPeriodo.Text.ToString();
                    db.Consultar(query, "Recibos");
                    DataTable Recibo = new DataTable();
                    db.da.Fill(Recibo);
                    db.Desconectar();
                    int i = 0;
                    while (i < Recibo.Rows.Count)
                    {
                        DataRow Fila = Recibo.Rows[i];
                        
                        File.Delete(Fila[1].ToString()+@"\"+Fila[3].ToString());
                        File.Delete(Fila[1].ToString()+@"\"+Fila[4].ToString());
                        File.Delete(Fila[2].ToString()+@"\"+Fila[3].ToString());
                        File.Delete(Fila[2].ToString()+@"\"+Fila[4].ToString());

                        db.Eliminar("recibos", "GUIDArchivo='" + Fila[0]+"'");
                        db.Desconectar();
                        i += 1;
                    }

                    MessageBox.Show("Los recibos han sido eliminados");
                    this.Close();

                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, "+ ex.Message.ToString(),"Error");
            }
        }
    }
}
