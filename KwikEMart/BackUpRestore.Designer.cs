namespace KwikEMart
{
    partial class BackUpRestore
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
            this.panelBackUpRestore = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnGenerarBKUP = new System.Windows.Forms.Button();
            this.dgvVersiones = new System.Windows.Forms.DataGridView();
            this.labelBackUpRestore = new System.Windows.Forms.Label();
            this.panelBackUpRestore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersiones)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 21);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 428);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 22);
            this.panel2.TabIndex = 1;
            // 
            // panelBackUpRestore
            // 
            this.panelBackUpRestore.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelBackUpRestore.Controls.Add(this.btnMenu);
            this.panelBackUpRestore.Controls.Add(this.btnRestaurar);
            this.panelBackUpRestore.Controls.Add(this.btnGenerarBKUP);
            this.panelBackUpRestore.Controls.Add(this.dgvVersiones);
            this.panelBackUpRestore.Controls.Add(this.labelBackUpRestore);
            this.panelBackUpRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackUpRestore.Location = new System.Drawing.Point(0, 21);
            this.panelBackUpRestore.Name = "panelBackUpRestore";
            this.panelBackUpRestore.Size = new System.Drawing.Size(469, 407);
            this.panelBackUpRestore.TabIndex = 2;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Gray;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Perpetua Titling MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(308, 343);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(149, 58);
            this.btnMenu.TabIndex = 36;
            this.btnMenu.Text = "volver al menu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.Color.Firebrick;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Perpetua Titling MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurar.ForeColor = System.Drawing.Color.White;
            this.btnRestaurar.Location = new System.Drawing.Point(127, 343);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(120, 58);
            this.btnRestaurar.TabIndex = 35;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGenerarBKUP
            // 
            this.btnGenerarBKUP.BackColor = System.Drawing.Color.Firebrick;
            this.btnGenerarBKUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarBKUP.Font = new System.Drawing.Font("Perpetua Titling MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarBKUP.ForeColor = System.Drawing.Color.White;
            this.btnGenerarBKUP.Location = new System.Drawing.Point(12, 343);
            this.btnGenerarBKUP.Name = "btnGenerarBKUP";
            this.btnGenerarBKUP.Size = new System.Drawing.Size(109, 58);
            this.btnGenerarBKUP.TabIndex = 34;
            this.btnGenerarBKUP.Text = "Generar BackUp";
            this.btnGenerarBKUP.UseVisualStyleBackColor = false;
            this.btnGenerarBKUP.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgvVersiones
            // 
            this.dgvVersiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVersiones.Location = new System.Drawing.Point(12, 54);
            this.dgvVersiones.Name = "dgvVersiones";
            this.dgvVersiones.Size = new System.Drawing.Size(445, 283);
            this.dgvVersiones.TabIndex = 6;
            // 
            // labelBackUpRestore
            // 
            this.labelBackUpRestore.AutoSize = true;
            this.labelBackUpRestore.Font = new System.Drawing.Font("Perpetua Titling MT", 26F, System.Drawing.FontStyle.Bold);
            this.labelBackUpRestore.ForeColor = System.Drawing.Color.White;
            this.labelBackUpRestore.Location = new System.Drawing.Point(5, 3);
            this.labelBackUpRestore.Name = "labelBackUpRestore";
            this.labelBackUpRestore.Size = new System.Drawing.Size(396, 42);
            this.labelBackUpRestore.TabIndex = 5;
            this.labelBackUpRestore.Text = "BackUp y Restore";
            // 
            // BackUpRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 450);
            this.Controls.Add(this.panelBackUpRestore);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BackUpRestore";
            this.Text = "BackUpRestore";
            this.panelBackUpRestore.ResumeLayout(false);
            this.panelBackUpRestore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersiones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelBackUpRestore;
        private System.Windows.Forms.Label labelBackUpRestore;
        private System.Windows.Forms.DataGridView dgvVersiones;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button btnGenerarBKUP;
        private System.Windows.Forms.Button btnMenu;
    }
}