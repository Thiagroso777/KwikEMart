namespace KwikEMart
{
    partial class frmSerializacion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelSerializacion = new System.Windows.Forms.Panel();
            this.btnMenuPrincipal = new System.Windows.Forms.Button();
            this.btnListarClientes = new System.Windows.Forms.Button();
            this.labelClienteSerializado = new System.Windows.Forms.Label();
            this.lblClientesSerializacion = new System.Windows.Forms.Label();
            this.labelSerializacion = new System.Windows.Forms.Label();
            this.btnDeserializar = new System.Windows.Forms.Button();
            this.btnSerializar = new System.Windows.Forms.Button();
            this.listBoxDatosDeserializados = new System.Windows.Forms.ListBox();
            this.listBoxArchivoSerializado = new System.Windows.Forms.ListBox();
            this.panelSerializacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 389);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(604, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(25, 389);
            this.panel2.TabIndex = 5;
            // 
            // panelSerializacion
            // 
            this.panelSerializacion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelSerializacion.Controls.Add(this.btnMenuPrincipal);
            this.panelSerializacion.Controls.Add(this.btnListarClientes);
            this.panelSerializacion.Controls.Add(this.labelClienteSerializado);
            this.panelSerializacion.Controls.Add(this.lblClientesSerializacion);
            this.panelSerializacion.Controls.Add(this.labelSerializacion);
            this.panelSerializacion.Controls.Add(this.btnDeserializar);
            this.panelSerializacion.Controls.Add(this.btnSerializar);
            this.panelSerializacion.Controls.Add(this.listBoxDatosDeserializados);
            this.panelSerializacion.Controls.Add(this.listBoxArchivoSerializado);
            this.panelSerializacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSerializacion.Location = new System.Drawing.Point(25, 0);
            this.panelSerializacion.Name = "panelSerializacion";
            this.panelSerializacion.Size = new System.Drawing.Size(579, 389);
            this.panelSerializacion.TabIndex = 6;
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnMenuPrincipal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMenuPrincipal.Location = new System.Drawing.Point(430, 341);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(143, 38);
            this.btnMenuPrincipal.TabIndex = 12;
            this.btnMenuPrincipal.Text = "Menu Principal";
            this.btnMenuPrincipal.UseVisualStyleBackColor = false;
            this.btnMenuPrincipal.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnListarClientes
            // 
            this.btnListarClientes.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnListarClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnListarClientes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnListarClientes.Location = new System.Drawing.Point(6, 341);
            this.btnListarClientes.Name = "btnListarClientes";
            this.btnListarClientes.Size = new System.Drawing.Size(143, 38);
            this.btnListarClientes.TabIndex = 11;
            this.btnListarClientes.Text = "Listar clientes";
            this.btnListarClientes.UseVisualStyleBackColor = false;
            this.btnListarClientes.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelClienteSerializado
            // 
            this.labelClienteSerializado.AutoSize = true;
            this.labelClienteSerializado.Font = new System.Drawing.Font("Perpetua Titling MT", 13F, System.Drawing.FontStyle.Bold);
            this.labelClienteSerializado.ForeColor = System.Drawing.Color.Black;
            this.labelClienteSerializado.Location = new System.Drawing.Point(294, 76);
            this.labelClienteSerializado.Name = "labelClienteSerializado";
            this.labelClienteSerializado.Size = new System.Drawing.Size(228, 22);
            this.labelClienteSerializado.TabIndex = 10;
            this.labelClienteSerializado.Text = "Cliente serializado:";
            // 
            // lblClientesSerializacion
            // 
            this.lblClientesSerializacion.AutoSize = true;
            this.lblClientesSerializacion.Font = new System.Drawing.Font("Perpetua Titling MT", 13F, System.Drawing.FontStyle.Bold);
            this.lblClientesSerializacion.ForeColor = System.Drawing.Color.Black;
            this.lblClientesSerializacion.Location = new System.Drawing.Point(3, 76);
            this.lblClientesSerializacion.Name = "lblClientesSerializacion";
            this.lblClientesSerializacion.Size = new System.Drawing.Size(102, 22);
            this.lblClientesSerializacion.TabIndex = 9;
            this.lblClientesSerializacion.Text = "Clientes:";
            // 
            // labelSerializacion
            // 
            this.labelSerializacion.AutoSize = true;
            this.labelSerializacion.Font = new System.Drawing.Font("Perpetua Titling MT", 30F, System.Drawing.FontStyle.Bold);
            this.labelSerializacion.ForeColor = System.Drawing.Color.Black;
            this.labelSerializacion.Location = new System.Drawing.Point(115, 9);
            this.labelSerializacion.Name = "labelSerializacion";
            this.labelSerializacion.Size = new System.Drawing.Size(355, 48);
            this.labelSerializacion.TabIndex = 8;
            this.labelSerializacion.Text = "Serialización";
            // 
            // btnDeserializar
            // 
            this.btnDeserializar.BackColor = System.Drawing.Color.Maroon;
            this.btnDeserializar.Font = new System.Drawing.Font("Perpetua Titling MT", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDeserializar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeserializar.Location = new System.Drawing.Point(298, 293);
            this.btnDeserializar.Name = "btnDeserializar";
            this.btnDeserializar.Size = new System.Drawing.Size(275, 42);
            this.btnDeserializar.TabIndex = 7;
            this.btnDeserializar.Text = "DESERIALIZAR";
            this.btnDeserializar.UseVisualStyleBackColor = false;
            this.btnDeserializar.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnSerializar
            // 
            this.btnSerializar.BackColor = System.Drawing.Color.Maroon;
            this.btnSerializar.Font = new System.Drawing.Font("Perpetua Titling MT", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSerializar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSerializar.Location = new System.Drawing.Point(6, 293);
            this.btnSerializar.Name = "btnSerializar";
            this.btnSerializar.Size = new System.Drawing.Size(278, 42);
            this.btnSerializar.TabIndex = 6;
            this.btnSerializar.Text = "SERIALIZAR";
            this.btnSerializar.UseVisualStyleBackColor = false;
            this.btnSerializar.Click += new System.EventHandler(this.btnSerializar_Click_1);
            // 
            // listBoxDatosDeserializados
            // 
            this.listBoxDatosDeserializados.FormattingEnabled = true;
            this.listBoxDatosDeserializados.Location = new System.Drawing.Point(6, 101);
            this.listBoxDatosDeserializados.Name = "listBoxDatosDeserializados";
            this.listBoxDatosDeserializados.Size = new System.Drawing.Size(278, 186);
            this.listBoxDatosDeserializados.TabIndex = 5;
            // 
            // listBoxArchivoSerializado
            // 
            this.listBoxArchivoSerializado.FormattingEnabled = true;
            this.listBoxArchivoSerializado.Location = new System.Drawing.Point(298, 101);
            this.listBoxArchivoSerializado.Name = "listBoxArchivoSerializado";
            this.listBoxArchivoSerializado.Size = new System.Drawing.Size(278, 186);
            this.listBoxArchivoSerializado.TabIndex = 4;
            // 
            // frmSerializacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 389);
            this.Controls.Add(this.panelSerializacion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmSerializacion";
            this.Text = "frmSerializacion";
            this.panelSerializacion.ResumeLayout(false);
            this.panelSerializacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelSerializacion;
        private System.Windows.Forms.Button btnDeserializar;
        private System.Windows.Forms.Button btnSerializar;
        private System.Windows.Forms.ListBox listBoxDatosDeserializados;
        private System.Windows.Forms.ListBox listBoxArchivoSerializado;
        private System.Windows.Forms.Label labelSerializacion;
        private System.Windows.Forms.Label labelClienteSerializado;
        private System.Windows.Forms.Label lblClientesSerializacion;
        private System.Windows.Forms.Button btnListarClientes;
        private System.Windows.Forms.Button btnMenuPrincipal;
    }
}