namespace KwikEMart
{
    partial class BitacoraCambio
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
            this.dgvCambios = new System.Windows.Forms.DataGridView();
            this.panelBitCambios = new System.Windows.Forms.Panel();
            this.btnRestaurarProd = new System.Windows.Forms.Button();
            this.btnQuitarFiltro = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lblCodProd = new System.Windows.Forms.Label();
            this.lblBitCambios = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambios)).BeginInit();
            this.panelBitCambios.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCambios
            // 
            this.dgvCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCambios.Location = new System.Drawing.Point(34, 76);
            this.dgvCambios.Name = "dgvCambios";
            this.dgvCambios.Size = new System.Drawing.Size(684, 314);
            this.dgvCambios.TabIndex = 6;
            // 
            // panelBitCambios
            // 
            this.panelBitCambios.BackColor = System.Drawing.Color.DimGray;
            this.panelBitCambios.Controls.Add(this.btnRestaurarProd);
            this.panelBitCambios.Controls.Add(this.btnQuitarFiltro);
            this.panelBitCambios.Controls.Add(this.btnMenu);
            this.panelBitCambios.Controls.Add(this.txtCodProd);
            this.panelBitCambios.Controls.Add(this.btnFiltrar);
            this.panelBitCambios.Controls.Add(this.lblCodProd);
            this.panelBitCambios.Controls.Add(this.dgvCambios);
            this.panelBitCambios.Controls.Add(this.lblBitCambios);
            this.panelBitCambios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBitCambios.Location = new System.Drawing.Point(24, 0);
            this.panelBitCambios.Name = "panelBitCambios";
            this.panelBitCambios.Size = new System.Drawing.Size(752, 450);
            this.panelBitCambios.TabIndex = 5;
            // 
            // btnRestaurarProd
            // 
            this.btnRestaurarProd.BackColor = System.Drawing.Color.Firebrick;
            this.btnRestaurarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurarProd.Font = new System.Drawing.Font("Perpetua Titling MT", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestaurarProd.ForeColor = System.Drawing.Color.White;
            this.btnRestaurarProd.Location = new System.Drawing.Point(438, 395);
            this.btnRestaurarProd.Name = "btnRestaurarProd";
            this.btnRestaurarProd.Size = new System.Drawing.Size(122, 48);
            this.btnRestaurarProd.TabIndex = 40;
            this.btnRestaurarProd.Text = "Restaurar producto";
            this.btnRestaurarProd.UseVisualStyleBackColor = false;
            // 
            // btnQuitarFiltro
            // 
            this.btnQuitarFiltro.BackColor = System.Drawing.Color.Firebrick;
            this.btnQuitarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarFiltro.Font = new System.Drawing.Font("Perpetua Titling MT", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuitarFiltro.ForeColor = System.Drawing.Color.White;
            this.btnQuitarFiltro.Location = new System.Drawing.Point(294, 395);
            this.btnQuitarFiltro.Name = "btnQuitarFiltro";
            this.btnQuitarFiltro.Size = new System.Drawing.Size(138, 48);
            this.btnQuitarFiltro.TabIndex = 39;
            this.btnQuitarFiltro.Text = "Quitar Filtro";
            this.btnQuitarFiltro.UseVisualStyleBackColor = false;
            this.btnQuitarFiltro.Visible = false;
            this.btnQuitarFiltro.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.DimGray;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Perpetua Titling MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(566, 395);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(152, 48);
            this.btnMenu.TabIndex = 38;
            this.btnMenu.Text = "Volver al menú principal";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtCodProd
            // 
            this.txtCodProd.Location = new System.Drawing.Point(34, 423);
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.Size = new System.Drawing.Size(115, 20);
            this.txtCodProd.TabIndex = 37;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.Firebrick;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Perpetua Titling MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(161, 395);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(127, 48);
            this.btnFiltrar.TabIndex = 36;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // lblCodProd
            // 
            this.lblCodProd.AutoSize = true;
            this.lblCodProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodProd.ForeColor = System.Drawing.Color.White;
            this.lblCodProd.Location = new System.Drawing.Point(31, 400);
            this.lblCodProd.Name = "lblCodProd";
            this.lblCodProd.Size = new System.Drawing.Size(118, 18);
            this.lblCodProd.TabIndex = 34;
            this.lblCodProd.Text = "Cod. Producto";
            // 
            // lblBitCambios
            // 
            this.lblBitCambios.AutoSize = true;
            this.lblBitCambios.Font = new System.Drawing.Font("Perpetua Titling MT", 30F, System.Drawing.FontStyle.Bold);
            this.lblBitCambios.ForeColor = System.Drawing.Color.White;
            this.lblBitCambios.Location = new System.Drawing.Point(109, 18);
            this.lblBitCambios.Name = "lblBitCambios";
            this.lblBitCambios.Size = new System.Drawing.Size(532, 48);
            this.lblBitCambios.TabIndex = 5;
            this.lblBitCambios.Text = "Bitácora de cambios";
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
            // BitacoraCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelBitCambios);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BitacoraCambio";
            this.Text = "BitacoraCambio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambios)).EndInit();
            this.panelBitCambios.ResumeLayout(false);
            this.panelBitCambios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCambios;
        private System.Windows.Forms.Panel panelBitCambios;
        private System.Windows.Forms.Button btnQuitarFiltro;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.TextBox txtCodProd;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblCodProd;
        private System.Windows.Forms.Label lblBitCambios;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRestaurarProd;
    }
}