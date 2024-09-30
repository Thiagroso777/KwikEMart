namespace KwikEMart
{
    partial class BitacoraEventos
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
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.panelBitEventos = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnQuitarFiltro = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.cmbRiesgo = new System.Windows.Forms.ComboBox();
            this.lblRiesgo = new System.Windows.Forms.Label();
            this.labelBitEventos = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            this.panelBitEventos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEventos
            // 
            this.dgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos.Location = new System.Drawing.Point(33, 71);
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.Size = new System.Drawing.Size(684, 299);
            this.dgvEventos.TabIndex = 5;
            // 
            // panelBitEventos
            // 
            this.panelBitEventos.BackColor = System.Drawing.Color.DimGray;
            this.panelBitEventos.Controls.Add(this.btnImprimir);
            this.panelBitEventos.Controls.Add(this.btnQuitarFiltro);
            this.panelBitEventos.Controls.Add(this.btnFiltrar);
            this.panelBitEventos.Controls.Add(this.btnMenu);
            this.panelBitEventos.Controls.Add(this.cmbRiesgo);
            this.panelBitEventos.Controls.Add(this.lblRiesgo);
            this.panelBitEventos.Controls.Add(this.dgvEventos);
            this.panelBitEventos.Controls.Add(this.labelBitEventos);
            this.panelBitEventos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBitEventos.Location = new System.Drawing.Point(24, 0);
            this.panelBitEventos.Name = "panelBitEventos";
            this.panelBitEventos.Size = new System.Drawing.Size(752, 450);
            this.panelBitEventos.TabIndex = 5;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Firebrick;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Perpetua Titling MT", 10F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(437, 390);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(122, 48);
            this.btnImprimir.TabIndex = 41;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnQuitarFiltro
            // 
            this.btnQuitarFiltro.BackColor = System.Drawing.Color.Firebrick;
            this.btnQuitarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarFiltro.Font = new System.Drawing.Font("Perpetua Titling MT", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuitarFiltro.ForeColor = System.Drawing.Color.White;
            this.btnQuitarFiltro.Location = new System.Drawing.Point(293, 390);
            this.btnQuitarFiltro.Name = "btnQuitarFiltro";
            this.btnQuitarFiltro.Size = new System.Drawing.Size(138, 48);
            this.btnQuitarFiltro.TabIndex = 40;
            this.btnQuitarFiltro.Text = "Quitar Filtro";
            this.btnQuitarFiltro.UseVisualStyleBackColor = false;
            this.btnQuitarFiltro.Visible = false;
            this.btnQuitarFiltro.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.Firebrick;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Perpetua Titling MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(160, 390);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(127, 48);
            this.btnFiltrar.TabIndex = 33;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.DimGray;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Perpetua Titling MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(565, 390);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(152, 48);
            this.btnMenu.TabIndex = 32;
            this.btnMenu.Text = "Volver al menú principal";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cmbRiesgo
            // 
            this.cmbRiesgo.FormattingEnabled = true;
            this.cmbRiesgo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbRiesgo.Location = new System.Drawing.Point(33, 411);
            this.cmbRiesgo.Name = "cmbRiesgo";
            this.cmbRiesgo.Size = new System.Drawing.Size(121, 21);
            this.cmbRiesgo.TabIndex = 31;
            // 
            // lblRiesgo
            // 
            this.lblRiesgo.AutoSize = true;
            this.lblRiesgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRiesgo.ForeColor = System.Drawing.Color.White;
            this.lblRiesgo.Location = new System.Drawing.Point(30, 390);
            this.lblRiesgo.Name = "lblRiesgo";
            this.lblRiesgo.Size = new System.Drawing.Size(61, 18);
            this.lblRiesgo.TabIndex = 30;
            this.lblRiesgo.Text = "Riesgo";
            // 
            // labelBitEventos
            // 
            this.labelBitEventos.AutoSize = true;
            this.labelBitEventos.Font = new System.Drawing.Font("Perpetua Titling MT", 30F, System.Drawing.FontStyle.Bold);
            this.labelBitEventos.ForeColor = System.Drawing.Color.White;
            this.labelBitEventos.Location = new System.Drawing.Point(113, 20);
            this.labelBitEventos.Name = "labelBitEventos";
            this.labelBitEventos.Size = new System.Drawing.Size(527, 48);
            this.labelBitEventos.TabIndex = 4;
            this.labelBitEventos.Text = "Bitácora de eventos";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(776, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(24, 450);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(24, 450);
            this.panel1.TabIndex = 3;
            // 
            // BitacoraEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelBitEventos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BitacoraEventos";
            this.Text = "BitacoraEventos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            this.panelBitEventos.ResumeLayout(false);
            this.panelBitEventos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEventos;
        private System.Windows.Forms.Panel panelBitEventos;
        private System.Windows.Forms.Button btnQuitarFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.ComboBox cmbRiesgo;
        private System.Windows.Forms.Label lblRiesgo;
        private System.Windows.Forms.Label labelBitEventos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImprimir;
    }
}