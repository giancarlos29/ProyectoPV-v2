namespace ProyectoPV.Presentacion
{
    partial class frmHistorico
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblHistoricoClientes = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sistemaPrestamosPVDataSet = new ProyectoPV.SistemaPrestamosPVDataSet();
            this.sistemaPrestamosPVDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvSaldadores = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosPVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosPVDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldadores)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.lblBuscar);
            this.panel1.Controls.Add(this.lblHistoricoClientes);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 247);
            this.panel1.TabIndex = 2;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.BackColor = System.Drawing.Color.Transparent;
            this.lblBuscar.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(529, 218);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(144, 19);
            this.lblBuscar.TabIndex = 17;
            this.lblBuscar.Text = "Buscar cliente:";
            // 
            // lblHistoricoClientes
            // 
            this.lblHistoricoClientes.AutoSize = true;
            this.lblHistoricoClientes.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoricoClientes.Location = new System.Drawing.Point(491, 75);
            this.lblHistoricoClientes.Name = "lblHistoricoClientes";
            this.lblHistoricoClientes.Size = new System.Drawing.Size(450, 32);
            this.lblHistoricoClientes.TabIndex = 8;
            this.lblHistoricoClientes.Text = "HISTORICO - CLIENTES SALDADOS";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtBuscar.Location = new System.Drawing.Point(679, 217);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(218, 20);
            this.txtBuscar.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtBuscar, "Escriba el nombre de algun cliente que desea consultar");
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProyectoPV.Properties.Resources.Historico;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(343, 242);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sistemaPrestamosPVDataSet
            // 
            this.sistemaPrestamosPVDataSet.DataSetName = "SistemaPrestamosPVDataSet";
            this.sistemaPrestamosPVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sistemaPrestamosPVDataSetBindingSource
            // 
            this.sistemaPrestamosPVDataSetBindingSource.DataSource = this.sistemaPrestamosPVDataSet;
            this.sistemaPrestamosPVDataSetBindingSource.Position = 0;
            // 
            // dgvSaldadores
            // 
            this.dgvSaldadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSaldadores.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvSaldadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaldadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSaldadores.Location = new System.Drawing.Point(0, 247);
            this.dgvSaldadores.MultiSelect = false;
            this.dgvSaldadores.Name = "dgvSaldadores";
            this.dgvSaldadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaldadores.Size = new System.Drawing.Size(941, 269);
            this.dgvSaldadores.TabIndex = 3;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Información";
            // 
            // frmHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 516);
            this.Controls.Add(this.dgvSaldadores);
            this.Controls.Add(this.panel1);
            this.Name = "frmHistorico";
            this.Text = "Historial de clientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHistorico_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosPVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosPVDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldadores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblHistoricoClientes;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.BindingSource sistemaPrestamosPVDataSetBindingSource;
        private SistemaPrestamosPVDataSet sistemaPrestamosPVDataSet;
        private System.Windows.Forms.DataGridView dgvSaldadores;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}