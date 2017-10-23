using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using LachosXML;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Net;


namespace GUAYACAN
{
    public partial class frmPrincipal : Form
    {

        struct Parametros
        {
            public int proceso;
            public int retraso;
        }

        struct Correo
        {
            public string db {get; set;}
            public string CodigoEmpleado {get; set;}
        }

        struct CfgCorrreo
        {
            public string email{get;set;}
            public string usr {get; set;}
            public string pwd {get; set;}
            public string pto { get; set;}
            public string srvsalida {get; set;}
            public bool autentificacion {get; set;}
            public string de {get; set;}

        }

        struct FTPSetting
        {
            public string Servidor {get; set;}
            public string Usuario {get; set;}
            public string Password {get; set;}
            public string NombreArchivo {get; set;}
            public string RutaArchivo {get; set;}

        }

        private string Modulo;
        private int modulo;  //0 xml, 1 pdf, 2 imprsion, 3 correo
        private bool EsCancelado = false;
        private string SQL;

        private Parametros _procesoEyS;
        private Correo _correo;
        private CfgCorrreo _cfgcorreo;
        FTPSetting _ftpsrv;

        public string periodo;
        public string rfc;
        public string rfcemisor;
        public string rfcprovcertif;
        public string emisor;
        public string FechaPago;
        public string SerieCertificadoEmisor;
        public string FolioFiscal;
        public string SerieCertificadoSat;
        public string FechaHoraCertificado;
        public string FechaTimbrado;
        public string SelloSat;
        public string CadenaOriginal;
        public string Version;
        public string Sello;
        public string Ruta;
        public string ArchivoPDF;
        public string ArchivoXML;
        public string GUIdArchivo;
        public string NumeroEmpleado;
        public string cLetra;
        public string total;
        public string qr;
        public string tt;
        public string Forma_de_pago;
        public string Mpago;
        public string MetodoPago;
        public string VersionCFDI;
        public string Complemento;
        public string NumPeriodo;
        public string Carpeta;
        public string nombre_receptor;

        private dbConexionSQL db; //objeto conexion a db

        private string CadenaConexion; //cadena de conexion
        private string dbUsr; //usuario de la instacia
        private string dbPwd; // contraseña de la instacia

        private string CadenaConexion2; // cadena de conexion para obtener los datos de la empresa de nominas.

        public frmPrincipal()
        {
            Thread t = new Thread(new ThreadStart(pantallainicio));
            t.Start();
            Thread.Sleep(3000);
            InitializeComponent();
            t.Abort();
        }

        public void pantallainicio()
        {
            Application.Run(new frmSplash());
        }
        private void tsmSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int proceso = ((Parametros)e.Argument).proceso;
            int retraso = ((Parametros)e.Argument).retraso;
            int index = 1;
            
            try
            {
                ///////////////////////////////////////////cargado de xml a la base de datos./////////////////////////////////////////////////

                if (modulo == 0)
                {
                    index = 1;
                    int i = 0;
                    DirectoryInfo di = new DirectoryInfo(Properties.Settings.Default.RutaTrabajo);//(@"c:\NominasCFDI"); //valor cambiable para indicar el origen
                    FileInfo[] archivos = di.GetFiles("*.xml");
                    //string Carpeta;

                    foreach (FileInfo f in archivos)
                    {
                        string nomarchivo = f.Name.ToString();
                        LeerXML(f.FullName.ToString());
                        string[] Nombre = nomarchivo.Split('.');
                        GUIdArchivo = Nombre[0];
                        string sucursal = periodo;
                        tt = "";
                        //PeriodoNumero(GUIdArchivo); // se obtiene el numero de periodo que se aplica el recibo
                        string queryBDN = "select BaseDatos from tbempresa where rfcempresa='"+ rfcemisor+"'";
                        db.Consultar(queryBDN, "Empresa");
                        DataTable Empresa = new DataTable();
                        db.da.Fill(Empresa);
                        DataRow Fempresa = Empresa.Rows[0];
                        string dbNommina = Fempresa[0].ToString();
                        db.Desconectar();

                    directorios: //etiqueta de control.
                        if (System.IO.Directory.Exists(@Properties.Settings.Default.RutaOrganizacion + @"\" + emisor)) //empresa  @di.FullName.ToString()
                        {
                            if (System.IO.Directory.Exists(@Properties.Settings.Default.RutaOrganizacion + @"\" + emisor + @"\" + sucursal)) //periodo
                            {
                                if (System.IO.Directory.Exists(@Properties.Settings.Default.RutaOrganizacion + @"\" + emisor + @"\" + sucursal + @"\" + (PeriodoNumero(GUIdArchivo,dbNommina)+"-"+FechaPago))) //fecha de pago
                                {
                                    if (File.Exists(f.FullName.ToString()))
                                    {
                                        
                                        string[] FechaT = FechaTimbrado.Split('T');
                                        
                                        if (!File.Exists(Properties.Settings.Default.RutaOrganizacion.ToString() + @"\" + emisor + @"\" + sucursal + @"\" + Carpeta + @"\" + rfc + "_" + NumPeriodo + "_" + FechaT[0] + "T" + FechaT[1].Replace(':', '_') + ".xml")) //di.FullName.ToString()
                                        {
                                            ///////////////////////////////////////////////////proceso de copiado de archivos////////////////////////////////////

                                            //PeriodoNumero(GUIdArchivo); // se obtiene el numero de periodo que se aplica el recibo


                                            //string[] FechaT = FechaTimbrado.Split('T');

                                            //File.Copy(f.FullName.ToString(), Properties.Settings.Default.RutaOrganizacion.ToString() + @"\" + emisor + @"\" + sucursal + @"\" + FechaPago + @"\" + rfc + "_" + FechaT[0] + "T" + FechaT[1].Replace(':', '_') + ".xml",true);
                                            //File.Copy(f.FullName.ToString(), Properties.Settings.Default.RutaPublicacion + @"\" + rfc + "_" + FechaT[0] + "T" + FechaT[1].Replace(':', '_') + ".xml",true);
                                            //Ruta = Properties.Settings.Default.RutaOrganizacion.ToString() + @"\" + emisor + @"\" + sucursal + @"\" + FechaPago;

                                            File.Copy(f.FullName.ToString(), Properties.Settings.Default.RutaOrganizacion.ToString() + @"\" + emisor + @"\" + sucursal + @"\" + NumPeriodo +"-"+FechaPago + @"\" + rfc +"_"+ NumPeriodo +"_" + FechaT[0] + "T" + FechaT[1].Replace(':', '_') + ".xml", true);
                                            File.Copy(f.FullName.ToString(), Properties.Settings.Default.RutaPublicacion + @"\" + rfc + "_" + NumPeriodo + "_" + FechaT[0] + "T" + FechaT[1].Replace(':', '_') + ".xml", true);
                                            Ruta = Properties.Settings.Default.RutaOrganizacion.ToString() + @"\" + emisor + @"\" + sucursal + @"\" + NumPeriodo +"-"+FechaPago;

                                            ArchivoPDF = rfc + "_" + NumPeriodo + "_" + FechaT[0] + "T" + FechaT[1].Replace(':', '_') + ".pdf";
                                            ArchivoXML = rfc + "_" + NumPeriodo + "_" + FechaT[0] + "T" + FechaT[1].Replace(':', '_') + ".xml";


                                            Bitacora("El recibo " + f.FullName.ToString() + " se copio en el directorio con el nombre " + f.FullName.ToString() + " | " + emisor + " | " + sucursal + " | " + FechaPago + " | " + rfc + ".xml");

                                            if(Complemento.ToString()=="3.3")
                                            {
                                                CadenaOriginal = "||" + Version + "|" + FolioFiscal + "|" + FechaTimbrado + "|" + Sello + "|" + SerieCertificadoSat + "||";
                                            }
                                            else
                                            {
                                                CadenaOriginal = "||" + Version + "|" + FolioFiscal + "|" + FechaHoraCertificado + "|" + SelloSat + "|" + SerieCertificadoSat + "||";
                                            }
                                            CantidadLetra camletra = new CantidadLetra();

                                            if (total != null && total.ToString().Length > 0)
                                            {
                                                cLetra = camletra.ConvertirCadena(total);

                                                totalqr(total);
                                                
                                                //fecha 23/10/2017
                                                //modificacion de generacion de contenido del qrcode donde se indica la version del complemento.

                                                if (Complemento.ToString() == "3.3")
                                                {
                                                    qr= "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?&id="+FolioFiscal+"&re="+rfcemisor+"&rr="+rfc+"&tt="+tt;

                                                }
                                                else
                                                {
                                                    qr = "?re=" + rfcemisor + "&rr=" + rfc + "&tt=" + tt + "&id=" + FolioFiscal;
                                                }

                                                //////////////////////////////////////////////////////////////////////////////////////////
                                                
                                                Metodo_Pago();
                                                
                                                //23/10/2017
                                                //se modifico el metodo de almacenamiento de la tabla de recibos donde se agrego el rfc del pac.

                                                if (Complemento.ToString() == "3.2")
                                                {
                                                    SQL = "insert into Recibos(GUIDArchivo,numeroempleado,periodo,fechapago,seriecertifiadoemisor,foliofiscal,seriesertificadosat,cadenaoriginal,version,sello,ruta,archivopdf,archivoxml,enviado,impreso,pdf,FechaTimbrado,qrcode,cletra,emisor,rfcemisro,sellosat,RutaPublicar,FormaDePago,MetodoPago,Complemento,VersionCFDi,FTP,NumeroPeriodo,Receptor,imgqrcode) values ('" + GUIdArchivo + "','" + NumeroEmpleado + "','" + periodo + "','" + FechaPago + "','" + SerieCertificadoEmisor + "','" + FolioFiscal + "','" + SerieCertificadoSat + "','" + CadenaOriginal + "','" + Version + "','" + Sello + "','" + @Ruta + "','" + ArchivoPDF + "','" + ArchivoXML + "'," + "0,0,0,'" + FechaTimbrado + "','" + qr + "','" + cLetra + "','" + emisor + "','" + rfcemisor + "','" + SelloSat + "','" + Properties.Settings.Default.RutaPublicacion.ToString() + "','" + Forma_de_pago.ToString() + "','" + MetodoPago.ToString() + "','" + Complemento.ToString() + "','" + VersionCFDI.ToString() + "',0," + NumPeriodo + ",'" + nombre_receptor + "','" + Properties.Settings.Default.RutaTrabajo.ToString() + @"\qrcode\" + GUIdArchivo + ".png" + "')";
                                                }

                                                if (Complemento.ToString() == "3.3")
                                                {
                                                    SQL = "insert into Recibos values ('" + GUIdArchivo + "','" + NumeroEmpleado + "','" + periodo + "','" + FechaPago + "','" + SerieCertificadoEmisor + "','" + FolioFiscal + "','" + SerieCertificadoSat + "','" + CadenaOriginal + "','" + Version + "','" + Sello + "','" + @Ruta + "','" + ArchivoPDF + "','" + ArchivoXML + "'," + "0,0,0,'" + FechaTimbrado + "','" + qr + "','" + cLetra + "','" + emisor + "','" + rfcemisor + "','" + rfcprovcertif + "','"  + SelloSat + "','" + Properties.Settings.Default.RutaPublicacion.ToString() + "','" + Forma_de_pago.ToString() + "','" + MetodoPago.ToString() + "','" + Complemento.ToString() + "','" + VersionCFDI.ToString() + "',0," + NumPeriodo + ",'" + nombre_receptor + "','" + Properties.Settings.Default.RutaTrabajo.ToString() + @"\qrcode\" + GUIdArchivo + ".png" + "')";
                                                }

                                                /////////////////////////////////////////////////////////////////////////////////////////////
                                                //SQL.Replace(@"\","/");
                                                if (db.Insertar(SQL))
                                                {
                                                    //MessageBox.Show("Error");                                                   
                                                    Bitacora("El recibo " + GUIdArchivo + " no se pudo registrar en la base de datos");
                                                    Bitacora("Error " + db.Error);
                                                }
                                                else
                                                {
                                                    Bitacora("El recibo " + GUIdArchivo + " fue registrado con exito");
                                                }
                                            }
                                            else
                                            {
                                                Bitacora("El recibo " + f.FullName.ToString() + "no cuenta con un total valido");
                                            }

                                            if (!backgroundWorker.CancellationPending)
                                            {
                                                backgroundWorker.ReportProgress(index++ * 100 / proceso, string.Format("Dato procesado {0}",i));
                                                i++;
                                                Thread.Sleep(retraso);
                                            }
                                            File.Delete(f.FullName);
                                            Bitacora("El recibo " + GUIdArchivo + "fue borrado");
                                            tt = null;
                                        }
                                        else
                                        {
                                            if (!backgroundWorker.CancellationPending)
                                            {
                                                backgroundWorker.ReportProgress(index++ * 100 / proceso, string.Format("Dato procesado {0}", i));
                                                i++;
                                                Thread.Sleep(retraso);
                                            }
                                            File.Delete(f.FullName);
                                            Bitacora("El recibo " + f.FullName.ToString() + " ya existe en el directorio " + f.FullName.ToString() + " | " + sucursal + " | " + FechaPago);
                                        }
                                    }
                                }//fecha de pago
                                else
                                {
                                    DirectoryInfo dis = new DirectoryInfo(Properties.Settings.Default.RutaOrganizacion.ToString() + @"\" + emisor + @"\" + sucursal);
                                    Carpeta = NumPeriodo+"-"+FechaPago; 
                                    dis.CreateSubdirectory(Carpeta);
                                    Bitacora("Se creo el diretorio " + Properties.Settings.Default.RutaOrganizacion.ToString() + " | " + sucursal + " | " + Carpeta);
                                    goto directorios;
                                }
                            }//periodo
                            else
                            {
                                DirectoryInfo dis = new DirectoryInfo(Properties.Settings.Default.RutaOrganizacion.ToString() + @"\" + emisor);
                                dis.CreateSubdirectory(sucursal);
                                Bitacora("Se creo el diretorio " + Properties.Settings.Default.RutaOrganizacion.ToString() + " | " + sucursal);
                                goto directorios;
                            }
                        }//empresa
                        else
                        {
                            DirectoryInfo dorg = new DirectoryInfo(Properties.Settings.Default.RutaOrganizacion.ToString());
                            DirectoryInfo dis = dorg.CreateSubdirectory(emisor);
                            Bitacora("Se creo el diretorio " + Properties.Settings.Default.RutaOrganizacion.ToString() + " | " + emisor);
                            goto directorios;
                        }
                    }//foreach
                } //modulo

                ///////////////////////////////////////proceso de generacion de pdf/////////////////////////////////////////////////

                if (modulo == 1)
                {
                    index = 1;
                    //string sql = @"select GUIDArchivo, (ruta + '\' + archivopdf)as archivo, numeroempleado  from recibos where pdf=0";
                    //                         0                         1                                    2              3            4         5                                                   6
                    string sql = @"select t1.GUIDArchivo, (t1.ruta + '\' + t1.archivopdf)as archivo, t1.numeroempleado, t2.BaseDatos,t2.recibo, (t1.RutaPublicar + '\' + t1.archivopdf) as publicar, qrcode from recibos t1 inner join tbEmpresa t2  on t1.rfcemisro = t2.RFCEmpresa where t1.pdf=0";
                    db.Consultar(sql, "Recibos");

                    DataTable Tabla = new DataTable();

                    db.da.Fill(Tabla);

                    int i = 0;
                    int c = 0;

                    if (Tabla.Rows.Count > 0)
                    {
                        while (i < Tabla.Rows.Count)
                        {
                            DataRow Fila = Tabla.Rows[i];

                            qrcode(Fila[6].ToString(), Properties.Settings.Default.RutaTrabajo.ToString(),Fila[0].ToString());

                            ReportDocument Recibo = new ReportDocument();

                            ParameterField pfGUIDArchivo = new ParameterField();
                            ParameterFields pfsGUIDArchivo = new ParameterFields();
                            ParameterDiscreteValue pdvGUIDArchivo = new ParameterDiscreteValue();
                            Bitacora("Se crearon los parametros necesarios para crystal reports....");
                            CrystalDecisions.Shared.ExportFormatType efiletype = (CrystalDecisions.Shared.ExportFormatType)Enum.Parse(typeof(CrystalDecisions.Shared.ExportFormatType), "PortableDocFormat");
                            Bitacora("CrystalDecisions.Shared.ExportFormatType efiletype = (CrystalDecisions.Shared.ExportFormatType)Enum.Parse(typeof(CrystalDecisions.Shared.ExportFormatType), 'PortableDocFormat');");
                            Bitacora("Se creo la instancia para la exportación del formato a PDF");

                            

                            pfGUIDArchivo.Name = "GUIDArchivo";
                            pdvGUIDArchivo.Value = Fila[0].ToString();
                            pfGUIDArchivo.CurrentValues.Add(pdvGUIDArchivo);
                            pfsGUIDArchivo.Add(pfGUIDArchivo);
                            Bitacora("Se pasaron los parametros del reporte a crystal.....");

                            string formato = @Application.StartupPath.ToString() + @"\Formato\" + Fila[4].ToString(); ;
                            Bitacora("Se arma la cadena de ubicación del formato......");
                            Recibo.Load(@formato);
                            Bitacora("Se carga el formato en memoria");
                            Recibo.SetParameterValue("GUIDArchivo", Fila[0].ToString());
                            Bitacora("Se colocan los parametros al formato......");
                            Bitacora("Se prepara el sistema para establecer conexión con el SQL");
                            Recibo.SetDatabaseLogon(dbUsr,dbPwd);
                            Bitacora("Se establecio conexión con el SQL.....");
                            /////////////////////////////////////////////////////////proceso de exportacion a pdf/////////////////////////////////////////////////

                            ///////////////////////////////////////////////////carpeta de organizacion////////////////////////////////

                            Recibo.ExportToDisk(efiletype, @Fila[1].ToString());
                            Bitacora("El recibo " + @Fila[1].ToString() + "se impreso en formato PDF");
                            
                            //////////////////////////////////////////////////carpeta de publicacion//////////////////////////////////

                            Recibo.ExportToDisk(efiletype, @Fila[5].ToString());
                            Bitacora("El recibo " + @Fila[5].ToString() + "se impreso en formato PDF");
                            
                            ////////////////////////////////////////////////////////fin de proceso de exportacion a pdf//////////////////////////////////////////

                            /////////////////////////////////////////////////////registro en la base de datos.//////////////////////////////////////////////
                            
                            Actualizar(Fila[0].ToString(), "pdf=1");

                            ////////////////////////////////////////////////////fin de registro en la base de datos/////////////////////////////////////////

                            if (!backgroundWorker.CancellationPending)
                            {
                                backgroundWorker.ReportProgress(i * 100 / proceso, string.Format("Dato procesado {0}", i));
                                i++;
                                Thread.Sleep(retraso);
                            }

                            Recibo.Close();
                        }
                    }

                }

                //////////////////////////////////////////////////////fin de proceso de generacion de pds./////////////////////////////////////////////////////

                //////////////////////////////////////////////////////proceso de impresion masiva de recibos./////////////////////////////////////////////////

                if (modulo == 2)
                {
                    db = new dbConexionSQL(@CadenaConexion);
                    //string sql = @"select GUIDArchivo, (ruta + '\' + archivopdf)as archivo, numeroempleado  from recibos where pdf=0";
                    //string sql = @"select t1.GUIDArchivo, (t1.ruta + '\' + t1.archivopdf)as archivo, t1.numeroempleado, t2.BaseDatos,t2.recibo from recibos t1 inner join tbEmpresa t2  on t1.rfcemisro = t2.RFCEmpresa where t1.impreso=0";
                    string sql = @"select t1.GUIDArchivo, (t1.ruta + '\' + t1.archivopdf)as archivo, t1.numeroempleado, t2.BaseDatos,t2.recibo, (t1.RutaPublicar + '\' + t1.archivopdf) as publicar, qrcode from recibos t1 inner join tbEmpresa t2  on t1.rfcemisro = t2.RFCEmpresa where t1.pdf=0";
                    db.Consultar(sql, "Recibos");

                    DataTable Tabla = new DataTable();

                    db.da.Fill(Tabla);

                    int i = 0;
                    int c = 0;

                    if (Tabla.Rows.Count > 0)
                    {
                        while (i < Tabla.Rows.Count)
                        {
                            DataRow Fila = Tabla.Rows[i];

                            qrcode(Fila[6].ToString(), Properties.Settings.Default.RutaTrabajo.ToString(), Fila[0].ToString());

                            ReportDocument Recibo = new ReportDocument();

                            ParameterField pfGUIDArchivo = new ParameterField();
                            ParameterFields pfsGUIDArchivo = new ParameterFields();
                            ParameterDiscreteValue pdvGUIDArchivo = new ParameterDiscreteValue();
                            CrystalDecisions.Shared.ExportFormatType efiletype = (CrystalDecisions.Shared.ExportFormatType)Enum.Parse(typeof(CrystalDecisions.Shared.ExportFormatType), "PortableDocFormat");

                            pfGUIDArchivo.Name = "GUIDArchivo";
                            pdvGUIDArchivo.Value = Fila[0].ToString();
                            pfGUIDArchivo.CurrentValues.Add(pdvGUIDArchivo);
                            pfsGUIDArchivo.Add(pfGUIDArchivo);

                            string formato = @Application.StartupPath.ToString() + @"\Formato\" + Fila[4].ToString(); ;

                            Recibo.Load(@formato);
                            Recibo.SetParameterValue("GUIDArchivo", Fila[0].ToString());
                            Recibo.SetDatabaseLogon(dbUsr, dbPwd);

                            //proceso de impresion

                            System.Drawing.Printing.PrinterSettings impresora = new System.Drawing.Printing.PrinterSettings();
                            Recibo.PrintOptions.PrinterName = impresora.PrinterName;
                            Recibo.PrintToPrinter(1, false, 1, 1);

                            Bitacora("El recibo " + @Fila[1].ToString() + "se impreso en papel");
                            Actualizar(Fila[0].ToString(), "impreso=1");

                            Recibo.Close();

                            if (!backgroundWorker.CancellationPending)
                            {
                                backgroundWorker.ReportProgress(index++ * 100 / proceso, string.Format("Dato procesado {0}", i));
                                i++;
                                Thread.Sleep(retraso);
                            }
                            

                        }
                        db.Desconectar();
                    }
                    else
                    {
                        Bitacora("Error no hay recibos que imprimir");
                    }
                }
                
                /////////////////////////////////////////////////////fin de proceso de impresion de recibos masiva////////////////////////////////////////////

                ////////////////////////////////////////////////////proceso de envio de recibo por via correo electronico.////////////////////////////////////

                if (modulo == 3)
                {
                    string queryListado = "select t1.GUIDArchivo,(t1.ruta + '\' + t1.archivopdf ) as pdf, (t1.ruta + '\' + t1.archivoxml ) as xml from recibos t1 where t1.enviado=0;";
                    db.Consultar(queryListado,"Empleado");
                    DataTable Correos = new DataTable();
                    db.da.Fill(Correos);
                    db.Desconectar();
                    int _email = 0;
                    int indice=0;

                    int contador = 1;

                    while(_email<Correos.Rows.Count)
                    {
                        DataRow Fila = Correos.Rows[indice];

                        Datos_Para_Remitente(Fila[0].ToString());

                        //string queryRemitente = "select correoelectronico from [" + _correo.db.ToString() + "].[dbo].[NOM10001] where codigoempleado='" + _correo.CodigoEmpleado.ToString().Trim() + "';";
                        string queryRemitente = "select CorreoElectronico from [" + _correo.db.ToString() + "].[dbo].[nom10001] where codigoempleado='" + _correo.CodigoEmpleado.ToString() + "';";
                        db.Consultar(queryRemitente,"Empleado");
                        DataTable CorreoRemitente = new DataTable();
                        db.da.Fill(CorreoRemitente);
                        DataRow FilaRemitente = CorreoRemitente.Rows[0];
                        db.Desconectar();

                        Emails mail = new Emails();

                        mail.UsrMail = _cfgcorreo.usr;
                        mail.PswMail = _cfgcorreo.pwd;
                        mail.Email = _cfgcorreo.email;
                        mail.PuertoCorreo = Convert.ToInt32(_cfgcorreo.pto);
                        mail.Host= _cfgcorreo.srvsalida;
                        mail.FormatoHTML = false;
                        mail.HayAdjuntos = true;
                        mail.Autoidentificacion = _cfgcorreo.autentificacion;

                        mail.Para = FilaRemitente[0].ToString();
                        mail.Bcc = _cfgcorreo.email;
                        mail.De = "Departamento de Recursos Humanos";
                        mail.Asunto = "Entrega de Recibos de Nominas";
                        mail.Cuerpo = "Por este edio le hacemos llegar su recibo de nominas";
                        
                        mail.ArchivosAdjuntos(Fila[1].ToString());
                        mail.ArchivosAdjuntos(Fila[2].ToString());

                        if(!mail.Enviar())
                        {
                            Bitacora("Se ha enviado el recibo de la cuenta " + mail.Email + "para " + mail.Para + "con BCC " + mail.Bcc);
                        }
                        else
                        {
                            Bitacora("Error al enviar el recibo de la cuenta " + mail.Email + " para " + mail.Para + "con BCC " + mail.Bcc);
                            Bitacora("Error " + mail.Notificaion);
                        }

                        if (!backgroundWorker.CancellationPending)
                        {
                            backgroundWorker.ReportProgress(index++ * 100 / proceso, string.Format("Dato procesado {0}", _email));
                            _email++;
                            Thread.Sleep(retraso);
                        }

                        contador++;

                        if(contador == 10)
                        {
                            Thread.Sleep(10000);
                            contador=0;
                        }

                    }
                    

                }

                ///////////////////////////////////////////////////fin de proceso de envio de correo electronico.////////////////////////////////////////////

                //////////////////////////////////////////////////inicia proceso de upload de archivos en servidor.//////////////////////////////////////////

                if (modulo == 4)
                {
                    index = 1;
                    string sql = @"select t1.GUIDArchivo, (t1.RutaPublicar + '\' + t1.archivopdf) as publicar, t1.archivopdf from recibos t1 inner join tbEmpresa t2  on t1.rfcemisro = t2.RFCEmpresa where t1.ftp=0 union select t1.GUIDArchivo, (t1.RutaPublicar + '\' + t1.archivoxml) as publicar, t1.archivoxml from recibos t1 inner join tbEmpresa t2  on t1.rfcemisro = t2.RFCEmpresa where t1.ftp=0";
                    db.Consultar(sql, "Recibos");

                    DataTable Tabla = new DataTable();

                    db.da.Fill(Tabla);
                    int i=0;

                    if (Tabla.Rows.Count > 0)
                    {
                        

                        while (i < Tabla.Rows.Count)
                        {
                            DataRow Fila = Tabla.Rows[i];

               

                            UploadFTP(Fila[1].ToString(), Properties.Settings.Default.SrvFTP.ToString(), Properties.Settings.Default.UsuarioFTP.ToString(), Properties.Settings.Default.PwdFTP.ToString());
                            
                            Bitacora("Se envio al servidor " + Properties.Settings.Default.SrvFTP.ToString() + "el archivo " + Fila[1].ToString());
                            
                            db.Actualizar("Recibos", "FTP=1", "GUIDArchivo='" + Fila[0].ToString() + "'");

                            File.Delete(Fila[1].ToString());
                            
                            if (!backgroundWorker.CancellationPending)
                            {
                                backgroundWorker.ReportProgress(index++ * 100 / proceso, string.Format("Dato procesado {0}", i));
                                i++;
                                //Thread.Sleep(retraso);
                            }
                        }
                    }
                }

                //////////////////////////////////////////////////fin de proceso de upload///////////////////////////////////////////////////////////////////


                if (modulo == 5)
                {
                    for (int j = 0; j < proceso; j++)
                    {
                        if (!backgroundWorker.CancellationPending)
                        {
                            backgroundWorker.ReportProgress(index++ * 100 / proceso, string.Format("Dato procesado {0}", j));
                            Thread.Sleep(retraso);


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                backgroundWorker.CancelAsync();
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Bitacora("Error, " + ex.Message.ToString());

            }
        }


        /// <summary>
        /// Metodo_Pago
        /// Traduce los códigos del método de pago de su valor numerico al valor de su significado en texto.
        /// </summary>
        private void Metodo_Pago()
        {
            string[] Metodo = Mpago.Split(',');
            int j=0;
            this.MetodoPago = "";
            foreach(string i in Metodo)
            {
                if (j < Metodo.Count() - 1)
                {
                    switch (i)
                    {
                        case "01":
                            {
                                this.MetodoPago = this.MetodoPago + "Efectivo" + ",";
                                break;
                            }
                        case "02":
                            {
                                this.MetodoPago = this.MetodoPago + "Cheque norminativo" + ",";
                                break;
                            }
                        case "03":
                            {
                                this.MetodoPago = this.MetodoPago + "Transferencia electrónica de fondos" + ",";
                                break;
                            }
                        case "04":
                            {
                                this.MetodoPago = this.MetodoPago + "Tarjeta de crédito" + ",";
                                break;
                            }
                        case "05":
                            {
                                this.MetodoPago = this.MetodoPago + "Monedero electrónico" + ",";
                                break;
                            }
                        case "06":
                            {
                                this.MetodoPago = this.MetodoPago + "Dinero electrónico" + ",";
                                break;
                            }
                        case "08":
                            {
                                this.MetodoPago = this.MetodoPago + "Vales de despensa" + ",";
                                break;
                            }
                        case "28":
                            {
                                this.MetodoPago = this.MetodoPago + "Tarjeta de débto" + ",";
                                break;
                            }
                        case "29":
                            {
                                this.MetodoPago = this.MetodoPago + "Tarjeta de servicio" + ",";
                                break;
                            }
                        case "99":
                            {
                                //fecha de modificacion 25/10/2017
                                //se valido el cambio de etiqueta que se define por el complemento de cfdi.
                                if (Complemento.ToString() == "3.3")
                                {
                                    this.MetodoPago = this.MetodoPago + "Por definir" + ",";
                                }
                                else
                                {
                                    this.MetodoPago = this.MetodoPago + "Otros" + ",";
                                } 
                                break;
                            }
                        case "NA":
                            {
                                this.MetodoPago = this.MetodoPago + "NA" + ",";
                                break;
                            }
                    }

                   
                }
                if (j == Metodo.Count() - 1)
                {
                    switch (i)
                    {
                        case "01":
                            {
                                this.MetodoPago = this.MetodoPago + "Efectivo";
                                break;
                            }
                        case "02":
                            {
                                this.MetodoPago = this.MetodoPago + "Cheque norminativo";
                                break;
                            }
                        case "03":
                            {
                                this.MetodoPago = this.MetodoPago + "Transferencia electrónica de fondos";
                                break;
                            }
                        case "04":
                            {
                                this.MetodoPago = this.MetodoPago + "Tarjeta de crédito";
                                break;
                            }
                        case "05":
                            {
                                this.MetodoPago = this.MetodoPago + "Monedero electrónico";
                                break;
                            }
                        case "06":
                            {
                                this.MetodoPago = this.MetodoPago + "Dinero electrónico";
                                break;
                            }
                        case "08":
                            {
                                this.MetodoPago = this.MetodoPago + "Vales de despensa";
                                break;
                            }
                        case "28":
                            {
                                this.MetodoPago = this.MetodoPago + "Tarjeta de débto";
                                break;
                            }
                        case "29":
                            {
                                this.MetodoPago = this.MetodoPago + "Tarjeta de servicio";
                                break;
                            }
                        case "99":
                            {
                                //fecha de modificacion 25/10/2017
                                //se valido el cambio de etiqueta que se define por el complemento de cfdi.
                                if (Complemento.ToString() == "3.3")
                                {
                                    this.MetodoPago = this.MetodoPago + "Por definir" + ",";
                                }
                                else
                                {
                                    this.MetodoPago = this.MetodoPago + "Otros" + ",";
                                } 
                                //this.MetodoPago = this.MetodoPago + "Otros";
                                break;
                            }
                        case "NA":
                            {
                                this.MetodoPago = this.MetodoPago + "NA";
                                break;
                            }
                    }
                    
                }
                j++;
            }

        }

        private void cfgCorreo()
        {
            string queryCfgCorreo ="select t1.email, t1.servidorsalida, t1.servidorentrante, t1.puerto, t1.usuario, t1.pwd, t1.autoidentificacion from email t1;";
            db.Consultar(queryCfgCorreo,"cfgCorreo");
            DataTable cfg = new DataTable();
            db.da.Fill(cfg);
            DataRow fila_cfg = cfg.Rows[0];
            _cfgcorreo.email=fila_cfg[0].ToString();
            _cfgcorreo.srvsalida=fila_cfg[1].ToString();
            _cfgcorreo.pto=fila_cfg[3].ToString();
            _cfgcorreo.usr=fila_cfg[4].ToString();
            _cfgcorreo.pwd=fila_cfg[5].ToString();
            _cfgcorreo.autentificacion= Convert.ToBoolean(fila_cfg[6]);
            db.Desconectar();
        }

        private void Datos_Para_Remitente(string GUIDArch)
        {
            string query = "select t2.BaseDatos,t1.numeroempleado from recibos t1 inner join tbempresa t2 on t1.rfcemisro=t2.RFCEmpresa where GUIDArchivo = '" + GUIDArch + "';";
            DataTable Remitente = new DataTable();
            db.Consultar(query, "Remitente");
            db.da.Fill(Remitente);
            DataRow Fila = Remitente.Rows[0];
            db.Desconectar();

            
            _correo.db = Fila[0].ToString();
            _correo.CodigoEmpleado=Fila[1].ToString();


        }

        private void totalqr(string total)
        {
            string[] numero = total.Split('.');
            string agregado = "0";
            
            
            for (int i = 0; i < (10-numero[0].Length); i++)
            {
                tt += agregado;
            }

            tt+=numero[0]+"."+numero[1];

            for (int d = 0; d < (6-numero[1].Length); d++)
            {
                tt += agregado;
            }


        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                pbProceso.Value = e.ProgressPercentage;
                lbProceso.Text = string.Format("Procesando...{0}%", e.ProgressPercentage);
                pbProceso.Update();
            }
            catch
            {

            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (EsCancelado)
            {
                string Mensaje = "El proceso de " + Modulo + " se a cancelado por el usuario";
                MessageBox.Show(Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string Mensaje = "El proceso de " + Modulo + " se a completado";
                MessageBox.Show(Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (modulo == 0)
                {
                    string query = "select count(t1.pdf) as pendiente from recibos t1 where t1.pdf=0;";
                    db.Consultar(query, "Recibos");

                    DataTable Tabla = new DataTable();

                    db.da.Fill(Tabla);

                    DataRow Fila = Tabla.Rows[0];

                    db.Desconectar();
                    this.EsCancelado = false;

                    if (!backgroundWorker.IsBusy)
                    {
                        this.modulo = 1;

                        _procesoEyS.proceso = Convert.ToInt32(Fila[0].ToString()) - 1; //1200;
                        _procesoEyS.retraso = 100;
                        backgroundWorker.RunWorkerAsync(_procesoEyS);
                        Modulo = "Elaboración de PDFs";
                        
                    }
                    

                }

                if (Properties.Settings.Default.Publicar)
                {
                    if (modulo == 1)
                    {
                        DialogResult respuesta;
                        respuesta = MessageBox.Show("¿Deseas que se carguen los archivos PDFs y XMLs en el servidor?", "Carga de Archivos", MessageBoxButtons.YesNo);
                        if (respuesta == System.Windows.Forms.DialogResult.Yes)
                        {
                            string query = "select (count(pdf)+count(GUIDArchivo)) as NumArchivos from recibos where ftp=0 and pdf=1";
                            db.Consultar(query, "Recibos");
                            DataTable Tabla = new DataTable();
                            db.da.Fill(Tabla);
                            db.Desconectar();

                            DataRow Fila = Tabla.Rows[0];

                            Cursor.Current = Cursors.WaitCursor;
                            this.EsCancelado = false;

                            modulo = 4;

                            if (!backgroundWorker.IsBusy)
                            {

                                _procesoEyS.proceso = Convert.ToInt32(Fila[0].ToString()) - 1; //1200;

                                Modulo = "Upload de archivos";

                                backgroundWorker.RunWorkerAsync(_procesoEyS);
                            }
                            Cursor.Current = Cursors.Default;

                        }

                    }
                }
            }
            
        }

        

        private void btnXML_Click(object sender, EventArgs e)
        {
            if (!Val_Directorios())
            {
                DirectoryInfo di = new DirectoryInfo(Properties.Settings.Default.RutaTrabajo);//(@"c:\NominasCFDI"); //valor cambiable para indicar el origen
                FileInfo[] archivos = di.GetFiles("*.xml");

                this.EsCancelado = false;
                if (!backgroundWorker.IsBusy)
                {
                    _procesoEyS.proceso = archivos.Count(); //1200;
                    _procesoEyS.retraso = 100;
                    backgroundWorker.RunWorkerAsync(_procesoEyS);
                    Modulo = "Cargado de XML";
                    this.modulo = 0;
                }
            }
            else
            {
                frmSeleccion Directorios = new frmSeleccion();
                Directorios.Show();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                this.EsCancelado = true;
                backgroundWorker.CancelAsync(); 
            }
        }

        /*
         * modificación para manejar las 2 version de complemento de los cfd version 3.2 y 3.3
         * se debe de poner un punto de condicion para saber si con que version de xml se esta trabajando
         */

        private bool Validacion_Version_XML(string archivoXML, string archivoXSD)
        {
            try
            {
                //XmlTextReader tr = new XmlTextReader(archivoXML); // se monto el xml que se va a validar
                //XmlValidatingReader vr = new XmlValidatingReader(tr); // se coloca el contenido del archivo en memoria

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas.Add(null,XmlReader.Create(@archivoXSD));

                XmlReader xmlReader = XmlReader.Create(@archivoXML,settings);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);
                xmlReader.Close();
                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
            
        }

        private void LeerXML(string archivo)
        {
            string archivoXSD_32 = "nomina11.xsd"; //Application.StartupPath + @"\cfdv32.xsd";
            string archivoXSD_33 = "nomina12.xsd"; //Application.StartupPath + @"\cfdv33.xsd";

            if (!Validacion_Version_XML(archivo, archivoXSD_33))
            {
                //Bitacora("El archivo " + archivo + "es de la version 3.2 de cfdi");
                System.Xml.XmlTextReader Recibo = new System.Xml.XmlTextReader(@archivo);

                while (Recibo.Read())
                {
                    Recibo.MoveToContent();

                    if (Recibo.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        // se determinaa la lectura de los componentes de las version de los  cfdi atravez de la version 


                        switch (Recibo.Name.ToString())
                        {
                            case "cfdi:Comprobante":
                                {
                                    SerieCertificadoEmisor = Recibo.GetAttribute("NoCertificado").ToString();
                                    Sello = Recibo.GetAttribute("Sello").ToString();
                                    total = Recibo.GetAttribute("Total").ToString();
                                    //se cambian los valores de la forma de pago  por el metodo de pago esto debido al cambio del sat en la version 3.3.
                                    Forma_de_pago = Recibo.GetAttribute("MetodoPago"); //Recibo.GetAttribute("FormaDePago");  
                                    Mpago = Recibo.GetAttribute("FormaPago"); //Recibo.GetAttribute("MetodoDePago");
                                    Complemento = Recibo.GetAttribute("Version").ToString();
                                    break;
                                }
                            case "cfdi:Emisor":
                                {
                                    rfcemisor = Recibo.GetAttribute("Rfc").ToString();
                                    emisor = Recibo.GetAttribute("Nombre").ToString();
                                    break;
                                }
                            case "cfdi:Receptor":
                                {
                                    rfc = Recibo.GetAttribute("Rfc").ToString(); //rfc del trabajador
                                    nombre_receptor = Recibo.GetAttribute("Nombre").ToString();
                                    break;
                                }
                            case "tfd:TimbreFiscalDigital":
                                {
                                    FolioFiscal = Recibo.GetAttribute("UUID").ToString(); //nodo["tfd:TimbreFiscalDigital "].GetAttribute("UUID").ToString();
                                    SelloSat = Recibo.GetAttribute("SelloSAT").ToString();
                                    SerieCertificadoSat = Recibo.GetAttribute("NoCertificadoSAT").ToString();
                                    Version = Recibo.GetAttribute("Version").ToString();
                                    FechaTimbrado = Recibo.GetAttribute("FechaTimbrado").ToString();
                                    rfcprovcertif = Recibo.GetAttribute("RfcProvCertif").ToString();

                                    break;
                                }
                            case "nomina12:Nomina":
                                {
                                    //periodo = Recibo.GetAttribute("PeriodicidadPago").ToString();                                
                                    FechaPago = Recibo.GetAttribute("FechaPago").ToString();
                                    //NumeroEmpleado = Recibo.GetAttribute("NumEmpleado").ToString();
                                    VersionCFDI = Recibo.GetAttribute("Version").ToString();
                                    break;
                                }
                            case "nomina12:Receptor":
                                {
                                    periodo = Recibo.GetAttribute("PeriodicidadPago").ToString();
                                    //FechaPago = Recibo.GetAttribute("FechaPago").ToString();
                                    NumeroEmpleado = Recibo.GetAttribute("NumEmpleado").ToString();
                                    //VersionCFDI = Recibo.GetAttribute("Version").ToString();
                                    break;
                                }
                        }


                    }


                }
                Recibo.Close();
            }
                        

        }

        
        private void Bitacora(string texto)
        {
            string ubicacion= Properties.Settings.Default.RutaTrabajo.ToString() + @"\logs\";
            DateTime hoy = DateTime.Now;
            string archivo = hoy.Day.ToString()+hoy.Month.ToString()+hoy.Year.ToString()+".txt";
            string path = @ubicacion + archivo;
            StreamWriter bit;
            try
            {
                registro:
                if (System.IO.Directory.Exists(@ubicacion)) //empresa  @di.FullName.ToString()
                {
                    if (!File.Exists(@path))
                    {
                        bit = new StreamWriter(@path);
                        string ln = "[" + hoy.Hour.ToString() + ":" + hoy.Minute.ToString() + ":" + hoy.Second.ToString() + "] ";
                        string Mensaje = ln + texto;
                        bit.WriteLine(Mensaje);

                    }
                    else
                    {
                        bit = File.AppendText(@path);
                        string ln = "[" + hoy.Hour.ToString() + ":" + hoy.Minute.ToString() + ":" + hoy.Second.ToString() + "] ";
                        string Mensaje = ln + texto;
                        bit.WriteLine(Mensaje);

                    }
                }
                else
                {
                    DirectoryInfo dorg = new DirectoryInfo(Properties.Settings.Default.RutaTrabajo);
                    DirectoryInfo dis = dorg.CreateSubdirectory("logs");
                    goto registro;
                }
            }
            catch (Exception ex)
            {
                if (!File.Exists(@path))
                {
                    bit = new StreamWriter(@path);
                    string ln = "[" + hoy.Hour.ToString() + ":" + hoy.Minute.ToString() + ": " + hoy.Second.ToString()  + "] ";
                    string Mensaje = ln + "Error " + ex;
                    bit.WriteLine(Mensaje);

                }
                else
                {
                    bit = File.AppendText(@path);
                    string ln = "[" + hoy.Hour.ToString() + ":" +hoy.Minute.ToString() + ":" + hoy.Second.ToString() + "] ";
                    string Mensaje = ln + "Error " + ex;
                    bit.WriteLine(Mensaje);
                }
            }

            bit.Close();

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

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //operacionesToolStripMenuItem.Visible = false;
            generarToolStripMenuItem.Visible = false;
            imprimirToolStripMenuItem.Visible = false;

            LeerConexion();
            db = new dbConexionSQL(@CadenaConexion);
            if (!Properties.Settings.Default.Publicar)
            {
                btnFTP.Enabled = false;
            }
            else
            {
                btnFTP.Enabled = true;
            }

        }

        private void Actualizar(string archivo, string valor)
        {
            if (db.Actualizar("recibos", valor, "GUIdArchivo='" + archivo + "'"))
            {
                //MessageBox.Show("No se pudo actulizar el estatus del recibo");
                Bitacora("El recibo " + archivo + " no se pudo cambiar su estatus en la base de datos");
            }
            else
            {
                Bitacora("El recibo " + archivo + " se ha cambiado su estatus en la base de datos");
            }

        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            string query = "select count(t1.pdf) as pendiente from recibos t1 where t1.pdf=0;";
            db.Consultar(query, "Recibos");

            DataTable Tabla = new DataTable();

            db.da.Fill(Tabla);

            DataRow Fila = Tabla.Rows[0];

            db.Desconectar();
            this.EsCancelado = false;
            if (!backgroundWorker.IsBusy)
            {
                _procesoEyS.proceso = Convert.ToInt32(Fila[0].ToString())-1; //1200;
                _procesoEyS.retraso = 100;
                backgroundWorker.RunWorkerAsync(_procesoEyS);
                Modulo = "Elaboración de PDFs";
                this.modulo = 1;
            }

            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string query = "select count(t1.impreso) as pendiente from recibos t1 where t1.impreso=0;";
            db.Consultar(query, "Recibos");

            DataTable Tabla = new DataTable();

            db.da.Fill(Tabla);

            DataRow Fila = Tabla.Rows[0];

            db.Desconectar();
            this.EsCancelado = false;
            if (!backgroundWorker.IsBusy)
            {
                _procesoEyS.proceso = Convert.ToInt32(Fila[0].ToString()) - 1; //1200;
                _procesoEyS.retraso = 100;
                backgroundWorker.RunWorkerAsync(_procesoEyS);
                Modulo = "Elaboración de Impresiones";
                this.modulo = 2;
            }
        }

        private void directoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeleccion sel = new frmSeleccion();
            sel.Show();
        }

        private void tsmAcercade_Click(object sender, EventArgs e)
        {
            AboutBox AcercaDe = new AboutBox();
            AcercaDe.Show();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            string query = "select count(t1.enviado) as pendiente from recibos t1 where t1.impreso=0;";
            db.Consultar(query, "Recibos");

            DataTable Tabla = new DataTable();

            db.da.Fill(Tabla);

            DataRow Fila = Tabla.Rows[0];

            db.Desconectar();
            this.EsCancelado = false;
            if (!backgroundWorker.IsBusy)
            {
                _procesoEyS.proceso = Convert.ToInt32(Fila[0].ToString()) - 1; //1200;
                _procesoEyS.retraso = 100;
                backgroundWorker.RunWorkerAsync(_procesoEyS);
                Modulo = "Elaboración de Impresiones";
                this.modulo = 3;
            }
        
        }

        private void servidorFTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCfgFTP cfgServidor = new frmCfgFTP();
            cfgServidor.Show();
        }

        private void btnFTP_Click(object sender, EventArgs e)
        {
            //Upload();

            string query = "select (count(pdf)+count(GUIDArchivo)) as NumArchivos from recibos where ftp=0 and pdf=1";
            db.Consultar(query, "Recibos");
            DataTable Tabla = new DataTable();
            db.da.Fill(Tabla);
            db.Desconectar();

            DataRow Fila = Tabla.Rows[0];

            Cursor.Current = Cursors.WaitCursor;
            this.EsCancelado = false;
            if (!backgroundWorker.IsBusy)
            {
                _procesoEyS.proceso = Convert.ToInt32(Fila[0].ToString()) - 1; //1200;
                //_procesoEyS.retraso = 100;
                //backgroundWorker.RunWorkerAsync(_procesoEyS);
                Modulo = "Upload de archivos";
                this.modulo = 4;
                //bwFTP.WorkerReportsProgress = true;
                //bwFTP.RunWorkerAsync(_procesoEyS);
                backgroundWorker.RunWorkerAsync(_procesoEyS);


                
            }
            Cursor.Current = Cursors.Default;
        }

        public void UploadFTP(string RutaArchivo, string RutaRemota, string Login, string Password)
        {
            using (FileStream fs = new FileStream(RutaArchivo, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                string url = Path.Combine(RutaRemota, Path.GetFileName(RutaArchivo));

                //creo un objeto ftp.

                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(url);

                //fijo las credenciales, usuario y contraseño

                ftp.Credentials = new NetworkCredential(Login, Password);
                //le digo que no mantenga la conexion activa al terminar.
                ftp.KeepAlive = false;

                //indicamos que la operacion es subir un archivo
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                // en modo binario
                ftp.UseBinary = true;
                
                //indicamos la longitud total de lo que vamos a enviar.
                ftp.ContentLength = fs.Length;

                //desactivo cualquier posible proxy http.
                ftp.Proxy = null;
                fs.Position = 0;

                //obtener el stream del socket sobre el que se va escribir.
                int bufferLength = 2048;
                byte[] buff = new byte[bufferLength];

                int contenLen;

                using (Stream strm = ftp.GetRequestStream())
                {
                    //leer del buffer 2kb  cada vez
                    contenLen = fs.Read(buff, 0, bufferLength);

                    //mientras haya datos en el buffer
                    while (contenLen != 0)
                    {
                        //escribir en el stream de conexion
                        //el contenido del stream del fichero
                        strm.Write(buff, 0, bufferLength);
                        contenLen = fs.Read(buff, 0, bufferLength);
                    }
                }
            }
        }

        private string PeriodoNumero(string GUIDArchivo, string dbNomina)
        {
            string query = "select t3.NumeroPeriodo as NumeroPeriodo from [" + dbNomina.ToString().Trim() + "].[dbo].[nom10043] t1 inner join [" + dbNomina.ToString().Trim() + "].[dbo].[nom10001] t2 on t1.IdEmpleado=t2.IdEmpleado  inner join [" + dbNomina.ToString().Trim() + "].[dbo].[nom10002] t3 on t1.IdPeriodo=t3.IdPeriodo where t1.GUIDDocumentoDSL='" + GUIDArchivo + "'";
            db.Consultar(query, "Recibo");
            DataTable periodo = new DataTable();
            db.da.Fill(periodo);
            DataRow fila = periodo.Rows[0];
            NumPeriodo = fila[0].ToString() ;
            db.Desconectar();
            return NumPeriodo;
        }

        private void eliminarRecibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCancelacion EliminarRecibos = new frmCancelacion();
            EliminarRecibos.Show();
        }

        private bool Val_Directorios()
        {
            if (Properties.Settings.Default.RutaTrabajo != null && Properties.Settings.Default.RutaTrabajo.Length > 0 && Properties.Settings.Default.RutaTrabajo != string.Empty)
            {
                if (Properties.Settings.Default.RutaOrganizacion != null && Properties.Settings.Default.RutaOrganizacion.Length > 0 && Properties.Settings.Default.RutaOrganizacion != string.Empty)
                {
                    if (Properties.Settings.Default.RutaPublicacion != null && Properties.Settings.Default.RutaPublicacion.Length > 0 && Properties.Settings.Default.RutaPublicacion != string.Empty)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private void qrcode(string qr, string ruta, string guid)
        {
            qrCode.Text = qr;

            generarcodigo:
            if (System.IO.Directory.Exists(ruta + @"\" + "qrcode"))
            {
                
                qrCode.Text = qr;
                Image img = (Image)qrCode.Image.Clone();
            ElaborarQRCODE:
                if (!File.Exists(ruta + @"\qrcode\" + guid+".png"))
                {                
                    img.Save(ruta + @"\qrcode\" + guid+".png");
                    img.Dispose();
                }
                else
                {
                    File.Delete(ruta + @"\qrcode\" + guid+".png");
                    goto ElaborarQRCODE;
                }
            }
            else
            {
                DirectoryInfo dorg = new DirectoryInfo(ruta);
                DirectoryInfo dis = dorg.CreateSubdirectory("qrcode");
                Bitacora("Se creo el diretorio " + ruta + " | qrcode");
                goto generarcodigo;
            }
        }

        
    }
}
