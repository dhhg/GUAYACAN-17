namespace GUAYACAN
{
    partial class frmSeleccion
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
            this.fbdDirectorio = new System.Windows.Forms.FolderBrowserDialog();
            this.tbDTrabajo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDOrganizacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDPublicacion = new System.Windows.Forms.TextBox();
            this.btnDirec1 = new System.Windows.Forms.Button();
            this.btnDirec2 = new System.Windows.Forms.Button();
            this.btnDirec3 = new System.Windows.Forms.Button();
            this.cbPublicar = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDTrabajo
            // 
            this.tbDTrabajo.Location = new System.Drawing.Point(150, 17);
            this.tbDTrabajo.Name = "tbDTrabajo";
            this.tbDTrabajo.Size = new System.Drawing.Size(197, 20);
            this.tbDTrabajo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Directorio de Trabajo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Directorio de Organización";
            // 
            // tbDOrganizacion
            // 
            this.tbDOrganizacion.Location = new System.Drawing.Point(150, 46);
            this.tbDOrganizacion.Name = "tbDOrganizacion";
            this.tbDOrganizacion.Size = new System.Drawing.Size(197, 20);
            this.tbDOrganizacion.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Directorio de Publicación";
            // 
            // tbDPublicacion
            // 
            this.tbDPublicacion.Location = new System.Drawing.Point(150, 74);
            this.tbDPublicacion.Name = "tbDPublicacion";
            this.tbDPublicacion.Size = new System.Drawing.Size(197, 20);
            this.tbDPublicacion.TabIndex = 4;
            // 
            // btnDirec1
            // 
            this.btnDirec1.Location = new System.Drawing.Point(353, 15);
            this.btnDirec1.Name = "btnDirec1";
            this.btnDirec1.Size = new System.Drawing.Size(27, 23);
            this.btnDirec1.TabIndex = 6;
            this.btnDirec1.Text = "...";
            this.btnDirec1.UseVisualStyleBackColor = true;
            this.btnDirec1.Click += new System.EventHandler(this.btnDirec1_Click);
            // 
            // btnDirec2
            // 
            this.btnDirec2.Location = new System.Drawing.Point(353, 44);
            this.btnDirec2.Name = "btnDirec2";
            this.btnDirec2.Size = new System.Drawing.Size(27, 23);
            this.btnDirec2.TabIndex = 7;
            this.btnDirec2.Text = "...";
            this.btnDirec2.UseVisualStyleBackColor = true;
            this.btnDirec2.Click += new System.EventHandler(this.btnDirec2_Click);
            // 
            // btnDirec3
            // 
            this.btnDirec3.Location = new System.Drawing.Point(353, 73);
            this.btnDirec3.Name = "btnDirec3";
            this.btnDirec3.Size = new System.Drawing.Size(27, 23);
            this.btnDirec3.TabIndex = 8;
            this.btnDirec3.Text = "...";
            this.btnDirec3.UseVisualStyleBackColor = true;
            this.btnDirec3.Click += new System.EventHandler(this.btnDirec3_Click);
            // 
            // cbPublicar
            // 
            this.cbPublicar.AutoSize = true;
            this.cbPublicar.Location = new System.Drawing.Point(15, 106);
            this.cbPublicar.Name = "cbPublicar";
            this.cbPublicar.Size = new System.Drawing.Size(64, 17);
            this.cbPublicar.TabIndex = 9;
            this.cbPublicar.Text = "Publicar";
            this.cbPublicar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(224, 102);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(305, 102);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 133);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbPublicar);
            this.Controls.Add(this.btnDirec3);
            this.Controls.Add(this.btnDirec2);
            this.Controls.Add(this.btnDirec1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDPublicacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDOrganizacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDTrabajo);
            this.Name = "frmSeleccion";
            this.Text = "Seleccion de Directorios de Trabajo";
            this.Load += new System.EventHandler(this.frmSeleccion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdDirectorio;
        private System.Windows.Forms.TextBox tbDTrabajo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDOrganizacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDPublicacion;
        private System.Windows.Forms.Button btnDirec1;
        private System.Windows.Forms.Button btnDirec2;
        private System.Windows.Forms.Button btnDirec3;
        private System.Windows.Forms.CheckBox cbPublicar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}