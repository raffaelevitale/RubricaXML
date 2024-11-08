namespace Esercizio03___Rubrica
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.modificaContattoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaContattoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ricercaContattoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grbContatto = new System.Windows.Forms.GroupBox();
            this.btnCreaContatto = new System.Windows.Forms.Button();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtIndirizzo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCognome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxContatti = new System.Windows.Forms.ListBox();
            this.abbonamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.grbContatto.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificaContattoToolStripMenuItem,
            this.eliminaContattoToolStripMenuItem,
            this.ricercaContattoToolStripMenuItem,
            this.abbonamentoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.esciToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(626, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // modificaContattoToolStripMenuItem
            // 
            this.modificaContattoToolStripMenuItem.Name = "modificaContattoToolStripMenuItem";
            this.modificaContattoToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.modificaContattoToolStripMenuItem.Text = "Modifica Contatto";
            this.modificaContattoToolStripMenuItem.Click += new System.EventHandler(this.modificaContattoToolStripMenuItem_Click);
            // 
            // eliminaContattoToolStripMenuItem
            // 
            this.eliminaContattoToolStripMenuItem.Name = "eliminaContattoToolStripMenuItem";
            this.eliminaContattoToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.eliminaContattoToolStripMenuItem.Text = "Elimina Contatto";
            this.eliminaContattoToolStripMenuItem.Click += new System.EventHandler(this.eliminaContattoToolStripMenuItem_Click);
            // 
            // ricercaContattoToolStripMenuItem
            // 
            this.ricercaContattoToolStripMenuItem.Name = "ricercaContattoToolStripMenuItem";
            this.ricercaContattoToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.ricercaContattoToolStripMenuItem.Text = "Ricerca Contatto";
            this.ricercaContattoToolStripMenuItem.Click += new System.EventHandler(this.ricercaContattoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // grbContatto
            // 
            this.grbContatto.Controls.Add(this.btnCreaContatto);
            this.grbContatto.Controls.Add(this.txtTelefono);
            this.grbContatto.Controls.Add(this.txtEmail);
            this.grbContatto.Controls.Add(this.txtIndirizzo);
            this.grbContatto.Controls.Add(this.txtNome);
            this.grbContatto.Controls.Add(this.txtCognome);
            this.grbContatto.Controls.Add(this.label5);
            this.grbContatto.Controls.Add(this.label4);
            this.grbContatto.Controls.Add(this.label3);
            this.grbContatto.Controls.Add(this.label2);
            this.grbContatto.Controls.Add(this.label1);
            this.grbContatto.Location = new System.Drawing.Point(13, 28);
            this.grbContatto.Name = "grbContatto";
            this.grbContatto.Size = new System.Drawing.Size(269, 211);
            this.grbContatto.TabIndex = 1;
            this.grbContatto.TabStop = false;
            this.grbContatto.Text = "Dati del contatto";
            // 
            // btnCreaContatto
            // 
            this.btnCreaContatto.Location = new System.Drawing.Point(11, 148);
            this.btnCreaContatto.Name = "btnCreaContatto";
            this.btnCreaContatto.Size = new System.Drawing.Size(173, 40);
            this.btnCreaContatto.TabIndex = 10;
            this.btnCreaContatto.Text = "Salva il Contatto";
            this.btnCreaContatto.UseVisualStyleBackColor = true;
            this.btnCreaContatto.Click += new System.EventHandler(this.btnCreaContatto_Click_1);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(84, 122);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(84, 94);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // txtIndirizzo
            // 
            this.txtIndirizzo.Location = new System.Drawing.Point(84, 68);
            this.txtIndirizzo.Name = "txtIndirizzo";
            this.txtIndirizzo.Size = new System.Drawing.Size(100, 20);
            this.txtIndirizzo.TabIndex = 7;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(84, 42);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 6;
            // 
            // txtCognome
            // 
            this.txtCognome.Location = new System.Drawing.Point(84, 13);
            this.txtCognome.Name = "txtCognome";
            this.txtCognome.Size = new System.Drawing.Size(100, 20);
            this.txtCognome.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Telefono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "E-Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Indirizzo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cognome";
            // 
            // listBoxContatti
            // 
            this.listBoxContatti.FormattingEnabled = true;
            this.listBoxContatti.Location = new System.Drawing.Point(288, 28);
            this.listBoxContatti.Name = "listBoxContatti";
            this.listBoxContatti.Size = new System.Drawing.Size(326, 212);
            this.listBoxContatti.TabIndex = 2;
            // 
            // abbonamentoToolStripMenuItem
            // 
            this.abbonamentoToolStripMenuItem.Name = "abbonamentoToolStripMenuItem";
            this.abbonamentoToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.abbonamentoToolStripMenuItem.Text = "Abbonamento";
            this.abbonamentoToolStripMenuItem.Click += new System.EventHandler(this.abbonamentoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 416);
            this.Controls.Add(this.listBoxContatti);
            this.Controls.Add(this.grbContatto);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(642, 455);
            this.MinimumSize = new System.Drawing.Size(642, 455);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rubrica";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grbContatto.ResumeLayout(false);
            this.grbContatto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modificaContattoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaContattoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.GroupBox grbContatto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtIndirizzo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCognome;
        private System.Windows.Forms.Button btnCreaContatto;
        private System.Windows.Forms.ListBox listBoxContatti;
        private System.Windows.Forms.ToolStripMenuItem ricercaContattoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abbonamentoToolStripMenuItem;
    }
}

