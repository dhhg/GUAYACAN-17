namespace GUAYACAN
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.msPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAcercade = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servidorFTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFEnOrganizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFEnPublicarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarRecibosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pbProceso = new System.Windows.Forms.ProgressBar();
            this.btnXML = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lbProceso = new System.Windows.Forms.Label();
            this.btnFTP = new System.Windows.Forms.Button();
            this.qrCode = new Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl();
            this.msPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrCode)).BeginInit();
            this.SuspendLayout();
            // 
            // msPrincipal
            // 
            this.msPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSalir,
            this.tsmAcercade,
            this.configuraciónToolStripMenuItem,
            this.operacionesToolStripMenuItem});
            this.msPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msPrincipal.Name = "msPrincipal";
            this.msPrincipal.Size = new System.Drawing.Size(609, 24);
            this.msPrincipal.TabIndex = 0;
            this.msPrincipal.Text = "Menú";
            // 
            // tsmSalir
            // 
            this.tsmSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmSalir.Name = "tsmSalir";
            this.tsmSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmSalir.Size = new System.Drawing.Size(41, 20);
            this.tsmSalir.Text = "&Salir";
            this.tsmSalir.Click += new System.EventHandler(this.tsmSalir_Click);
            // 
            // tsmAcercade
            // 
            this.tsmAcercade.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmAcercade.Name = "tsmAcercade";
            this.tsmAcercade.Size = new System.Drawing.Size(71, 20);
            this.tsmAcercade.Text = "&Acerca de";
            this.tsmAcercade.Click += new System.EventHandler(this.tsmAcercade_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.directoriosToolStripMenuItem,
            this.conexiónToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuraciónToolStripMenuItem.Text = "Co&nfiguración";
            // 
            // directoriosToolStripMenuItem
            // 
            this.directoriosToolStripMenuItem.Name = "directoriosToolStripMenuItem";
            this.directoriosToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.directoriosToolStripMenuItem.Text = "Directorios";
            this.directoriosToolStripMenuItem.Click += new System.EventHandler(this.directoriosToolStripMenuItem_Click);
            // 
            // conexiónToolStripMenuItem
            // 
            this.conexiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.servidorFTPToolStripMenuItem});
            this.conexiónToolStripMenuItem.Name = "conexiónToolStripMenuItem";
            this.conexiónToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.conexiónToolStripMenuItem.Text = "Conexión";
            // 
            // servidorFTPToolStripMenuItem
            // 
            this.servidorFTPToolStripMenuItem.Name = "servidorFTPToolStripMenuItem";
            this.servidorFTPToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.servidorFTPToolStripMenuItem.Text = "Servidor FTP";
            this.servidorFTPToolStripMenuItem.Click += new System.EventHandler(this.servidorFTPToolStripMenuItem_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarToolStripMenuItem,
            this.imprimirToolStripMenuItem,
            this.eliminarRecibosToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.operacionesToolStripMenuItem.Text = "&Operaciones";
            // 
            // generarToolStripMenuItem
            // 
            this.generarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pDFEnOrganizacionToolStripMenuItem,
            this.pDFEnPublicarToolStripMenuItem});
            this.generarToolStripMenuItem.Name = "generarToolStripMenuItem";
            this.generarToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.generarToolStripMenuItem.Text = "Re generar";
            // 
            // pDFEnOrganizacionToolStripMenuItem
            // 
            this.pDFEnOrganizacionToolStripMenuItem.Name = "pDFEnOrganizacionToolStripMenuItem";
            this.pDFEnOrganizacionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.pDFEnOrganizacionToolStripMenuItem.Text = "PDF en Organizacion";
            // 
            // pDFEnPublicarToolStripMenuItem
            // 
            this.pDFEnPublicarToolStripMenuItem.Name = "pDFEnPublicarToolStripMenuItem";
            this.pDFEnPublicarToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.pDFEnPublicarToolStripMenuItem.Text = "PDF en Publicar";
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.imprimirToolStripMenuItem.Text = "Re Imprimir";
            // 
            // eliminarRecibosToolStripMenuItem
            // 
            this.eliminarRecibosToolStripMenuItem.Name = "eliminarRecibosToolStripMenuItem";
            this.eliminarRecibosToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.eliminarRecibosToolStripMenuItem.Text = "Eliminar Recibos";
            this.eliminarRecibosToolStripMenuItem.Click += new System.EventHandler(this.eliminarRecibosToolStripMenuItem_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnPDF.Image")));
            this.btnPDF.Location = new System.Drawing.Point(125, 46);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(75, 57);
            this.btnPDF.TabIndex = 2;
            this.btnPDF.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnEmail.Image")));
            this.btnEmail.Location = new System.Drawing.Point(407, 46);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(75, 57);
            this.btnEmail.TabIndex = 4;
            this.btnEmail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(313, 46);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 57);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.SlateGray;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(501, 46);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 57);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pbProceso
            // 
            this.pbProceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(127)))), ((int)(((byte)(190)))));
            this.pbProceso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(127)))), ((int)(((byte)(190)))));
            this.pbProceso.Location = new System.Drawing.Point(31, 129);
            this.pbProceso.Name = "pbProceso";
            this.pbProceso.Size = new System.Drawing.Size(545, 23);
            this.pbProceso.TabIndex = 6;
            // 
            // btnXML
            // 
            this.btnXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXML.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnXML.Image = ((System.Drawing.Image)(resources.GetObject("btnXML.Image")));
            this.btnXML.Location = new System.Drawing.Point(31, 46);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(75, 57);
            this.btnXML.TabIndex = 1;
            this.btnXML.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXML.UseVisualStyleBackColor = true;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(253, 180);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 27);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbProceso
            // 
            this.lbProceso.AutoSize = true;
            this.lbProceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(127)))), ((int)(((byte)(190)))));
            this.lbProceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbProceso.Location = new System.Drawing.Point(261, 155);
            this.lbProceso.Name = "lbProceso";
            this.lbProceso.Size = new System.Drawing.Size(86, 13);
            this.lbProceso.TabIndex = 8;
            this.lbProceso.Text = "Proceso al 0%....";
            // 
            // btnFTP
            // 
            this.btnFTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFTP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFTP.Image = ((System.Drawing.Image)(resources.GetObject("btnFTP.Image")));
            this.btnFTP.Location = new System.Drawing.Point(219, 46);
            this.btnFTP.Name = "btnFTP";
            this.btnFTP.Size = new System.Drawing.Size(75, 57);
            this.btnFTP.TabIndex = 9;
            this.btnFTP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFTP.UseVisualStyleBackColor = true;
            this.btnFTP.Click += new System.EventHandler(this.btnFTP_Click);
            // 
            // qrCode
            // 
            this.qrCode.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M;
            this.qrCode.Image = ((System.Drawing.Image)(resources.GetObject("qrCode.Image")));
            this.qrCode.Location = new System.Drawing.Point(353, 46);
            this.qrCode.Name = "qrCode";
            this.qrCode.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two;
            this.qrCode.Size = new System.Drawing.Size(235, 197);
            this.qrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.qrCode.TabIndex = 10;
            this.qrCode.TabStop = false;
            this.qrCode.Text = "qrCodeImgControl1";
            this.qrCode.Visible = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(609, 255);
            this.Controls.Add(this.btnFTP);
            this.Controls.Add(this.lbProceso);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pbProceso);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnXML);
            this.Controls.Add(this.msPrincipal);
            this.Controls.Add(this.qrCode);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msPrincipal;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(625, 294);
            this.MinimumSize = new System.Drawing.Size(625, 294);
            this.Name = "frmPrincipal";
            this.Text = "::== Asistente de Entrega de Recibos Masivos ==::";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.msPrincipal.ResumeLayout(false);
            this.msPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmAcercade;
        private System.Windows.Forms.ToolStripMenuItem tsmSalir;
        private System.Windows.Forms.Button btnXML;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ProgressBar pbProceso;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbProceso;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFEnOrganizacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFEnPublicarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servidorFTPToolStripMenuItem;
        private System.Windows.Forms.Button btnFTP;
        private System.Windows.Forms.ToolStripMenuItem eliminarRecibosToolStripMenuItem;
        private Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl qrCode;
    }
}

