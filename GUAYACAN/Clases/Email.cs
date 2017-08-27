using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.IO;
using System.Collections;
using System.Net.Mime;


namespace GUAYACAN
{
    class Emails 
    {

        //elementos del cliente del correo.
        public string De { get; set; } //nombre del quien envia el correo
        public string Email { get; set; } //correo electronico quien envia el mensaje
        public string Para { get; set; } //destinatario 
        public string Cc { get; set; } //direccion de correos a los cuales se les enviara una copia del mensaje
        public string Bcc { get; set; } //direcciond e correo que se manejaran oculta la copia
        public string Asunto { get; set; } //asunto del correo
        public string Cuerpo { get; set; } //mensaje del correo
        public bool HayAdjuntos { get; set; } //indicador si hay archivos adjuntos
        //public ListView Adjuntos; //lista de archivos adjuntos.
        public string Plantilla { get; set; } //se indica la ruta y el archivo del cual se va obtener la informacion del correo. 
        public string RutaPlantilla { get; set; } //se establece la ruta donde se encuntra la plantilla

        //configuracion del cliente de correo
        public string UsrMail { get; set; } //usuario del servidor
        public string PswMail { get; set; } //contraseña del correo
        public string Host { get; set; } //direccion del servidor
        public int PuertoCorreo { get; set; } //puerto para realizar la conexion
        public bool Autoidentificacion { get; set; } //sirve para indicar si se usa autentificación
        public bool FormatoHTML { get; set; } //para indicar si el formato del texto va ser en html o plano"

        public string Notificaion; //sirve para almacenar los mensajes de error

        private MailMessage Mensaje; //Objeto que define el correo
        private SmtpClient ServidorCorreo; //objetoque define al servidor.

        //contructor de la clase.
        public Emails()
        {
            this.De = "";
            this.Email = "";
            this.Para = "";
            this.Cc = "";
            this.Bcc = "";
            this.Asunto = "";
            this.Cuerpo = "";
            this.UsrMail = "";
            this.PswMail = "";
            this.PuertoCorreo = 25;
            this.Host = "";
            this.Notificaion = "";
            this.Autoidentificacion = false;
            this.HayAdjuntos = false;
            this.FormatoHTML = true;
            this.RutaPlantilla = "";
            this.Plantilla = "";
            //this.Adjuntos = new ListView();
            this.Mensaje = new MailMessage();
            this.ServidorCorreo = new SmtpClient();

        }

        //Configuracion
        //sirver para establecer la configuracion del servidor.

        private void Configuracion()
        {
            this.ServidorCorreo.Port = this.PuertoCorreo;
            this.ServidorCorreo.Host = this.Host;

            if (this.Autoidentificacion == true)
            {
                this.ServidorCorreo.Credentials = new System.Net.NetworkCredential(this.UsrMail, this.PswMail);
            }

        }

        public void ArchivosAdjuntos(string Archivo)
        {
            Attachment adjunto = new Attachment(@Archivo, MediaTypeNames.Application.Octet);
            Mensaje.Attachments.Add(adjunto);
        }

        //CrearCorreo
        //sirve para crear y ensamblar el mensaje 
        private void CrearCorreo()
        {
            this.Mensaje.From = new MailAddress(this.Email.ToString(), this.De.ToString());
            this.Mensaje.To.Add(this.Para.ToString());
            if (this.Cc != "")
            {
                this.Mensaje.CC.Add(this.Cc.ToString());
            }
            if (this.Bcc != "")
            {
                this.Mensaje.Bcc.Add(this.Bcc.ToString());
            }
            this.Mensaje.Subject = this.Asunto.ToString();
            if (this.FormatoHTML == true)
            {
                this.Mensaje.IsBodyHtml = true;
            }
            this.Mensaje.Body = Cuerpo.ToString();
        }

        //Enviar
        //Sirver para configurar el servidor, crear y ensamblar el correo y enviar el mismo
        //retorna un valor booleano donde falso es cuando no hay error y verdadero cuando hay
        //error.
        public bool Enviar()
        {
            try
            {
                this.Configuracion();
                this.CrearCorreo();
                this.ServidorCorreo.Send(Mensaje);
                return false;
            }
            catch (Exception ex)
            {
                this.Notificaion = ex.ToString();
                return true;
            }
        }


        //Leer formato base.
        //sirve para enviar un correo del cual se cuenta con una plantilla.

        public void AbrirPlantilla()
        {
            StreamReader ArchivoPlantilla = new StreamReader(@RutaPlantilla + @Plantilla.ToString());
            //this.Cuerpo += ArchivoPlantilla.ReadToEnd();
            string aux = "";
            while (aux != null)
            {
                //Se lee la linea del archivo.
                aux = ArchivoPlantilla.ReadLine();

                if (aux != null)
                {
                    this.Cuerpo += aux;

                    bool imgLocalizada = aux.Trim().StartsWith("<img");
                    if (imgLocalizada)
                    {
                        string ArchivoAux1 = aux.Substring(aux.IndexOf("src=\"") + 5);
                        string ArchivoAux2;
                        string Archivo;
                        int inicio;

                        if (ArchivoAux1.IndexOf(".jpg") != -1)
                        {
                            ArchivoAux2 = ArchivoAux1.Substring(ArchivoAux1.IndexOf(".jpg\"") + 4);
                            inicio = ArchivoAux1.Length - ArchivoAux2.Length;
                            Archivo = ArchivoAux1.Remove(inicio);
                            Attachment adjunto = new Attachment(@RutaPlantilla + Archivo, MediaTypeNames.Application.Octet);
                            Mensaje.Attachments.Add(adjunto);
                        }

                        if (ArchivoAux1.IndexOf(".png\"") != -1)
                        {
                            ArchivoAux2 = ArchivoAux1.Substring(ArchivoAux1.IndexOf(".png\"") + 4);
                            inicio = ArchivoAux1.Length - ArchivoAux2.Length;
                            Archivo = ArchivoAux1.Remove(inicio);
                            Attachment adjunto = new Attachment(@RutaPlantilla + Archivo);
                            Mensaje.Attachments.Add(adjunto);
                        }

                        if (ArchivoAux1.IndexOf(".gif\"") != -1)
                        {
                            ArchivoAux2 = ArchivoAux1.Substring(ArchivoAux1.IndexOf(".gif\"") + 4);
                            inicio = ArchivoAux1.Length - ArchivoAux2.Length;
                            Archivo = ArchivoAux1.Remove(inicio);
                            Attachment adjunto = new Attachment(@RutaPlantilla + Archivo);
                            Mensaje.Attachments.Add(adjunto);
                        }


                    }
                }


            }
            ArchivoPlantilla.Close();
        }

        //procedimiento para conexion desde archivo.
        //public void cfgArchivo(string xmlRuta, string xmlArchivo)
        //{
        //    // se crea el objeto con el cual se trabajara con el archivo de configuracion.
        //    // del archivo xml.
        //    XMLLachos Archivo = new XMLLachos();
        //    Archivo.NomArch = xmlArchivo.ToString(); //Se estable el nombre del archivo xml
        //    Archivo.Ruta = xmlRuta.ToString(); //se indica la ruta donde se encuentra almacenado.

        //    //se obtiene la informacion de configuracion de la conexion del archivo xml.
        //    Archivo.leer();

        //    //se establecen los valores para establecer la configuracion de conexion.

        //    this.Servidor = Archivo.Servidor;
        //    this.Puerto = Archivo.Puerto;
        //    this.Usuario = Archivo.Usuario;
        //    this.BaseDatos = Archivo.BaseDatos;
        //    this.Password = Archivo.Password;
        //}


        //~Emails
        //es el destructor de la clase.
        ~Emails()
        {
            this.De = "";
            this.Email = "";
            this.Para = "";
            this.Cc = "";
            this.Bcc = "";
            this.Asunto = "";
            this.Cuerpo = "";
            this.UsrMail = "";
            this.PswMail = "";
            this.PuertoCorreo = 0;
            this.Host = "";
            this.Notificaion = "";
            this.Autoidentificacion = false;
            this.HayAdjuntos = false;
            this.FormatoHTML = false;
            //this.Adjuntos = null;
            this.Mensaje = null;
            this.ServidorCorreo = null;
            this.Plantilla = "";
            this.RutaPlantilla = "";
        }
    }

    
}
