namespace prueba
{
    partial class Ver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ver));
            this.plano1 = new prueba.Plano();
            this.labelHora = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDia = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Mesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Libre = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Sillas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // plano1
            // 
            this.plano1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.plano1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.plano1.Location = new System.Drawing.Point(290, 13);
            this.plano1.Name = "plano1";
            this.plano1.Size = new System.Drawing.Size(480, 400);
            this.plano1.TabIndex = 0;
            this.plano1.Load += new System.EventHandler(this.plano1_Load);
            // 
            // labelHora
            // 
            this.labelHora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHora.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.labelHora.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHora.Font = new System.Drawing.Font("Arial Rounded MT Bold", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labelHora.Location = new System.Drawing.Point(3, 10);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(266, 74);
            this.labelHora.TabIndex = 1;
            this.labelHora.Text = "11:25:04";
            this.labelHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelHora.Click += new System.EventHandler(this.labelHora_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelDia);
            this.panel1.Controls.Add(this.labelFecha);
            this.panel1.Controls.Add(this.labelHora);
            this.panel1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 146);
            this.panel1.TabIndex = 2;
            // 
            // labelDia
            // 
            this.labelDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDia.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDia.Location = new System.Drawing.Point(146, 95);
            this.labelDia.Name = "labelDia";
            this.labelDia.Size = new System.Drawing.Size(123, 32);
            this.labelDia.TabIndex = 1;
            this.labelDia.Text = "Domingo";
            this.labelDia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFecha
            // 
            this.labelFecha.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(-1, 95);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(154, 32);
            this.labelFecha.TabIndex = 1;
            this.labelFecha.Text = "30/12/2019";
            this.labelFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mesa,
            this.Libre,
            this.Sillas});
            this.dataGridView1.Location = new System.Drawing.Point(12, 169);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(274, 243);
            this.dataGridView1.TabIndex = 4;
            // 
            // Mesa
            // 
            this.Mesa.HeaderText = "Numero Mesa";
            this.Mesa.Name = "Mesa";
            // 
            // Libre
            // 
            this.Libre.HeaderText = "Libre?";
            this.Libre.Name = "Libre";
            // 
            // Sillas
            // 
            this.Sillas.HeaderText = "Sillas";
            this.Sillas.Name = "Sillas";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Editar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Ver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 491);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.plano1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ver";
            this.Text = "Ver";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelHora;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelDia;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mesa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Libre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sillas;
        private System.Windows.Forms.Button button1;
        public Plano plano1;
    }
}