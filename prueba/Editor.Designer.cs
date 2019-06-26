namespace prueba
{
    partial class Editor
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.labelBool = new System.Windows.Forms.Label();
            this.selector = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.panel = new prueba.Plano();
            this.selector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 428);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 13);
            this.label.TabIndex = 2;
            this.label.Text = "label1";
            // 
            // labelBool
            // 
            this.labelBool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelBool.AutoSize = true;
            this.labelBool.Location = new System.Drawing.Point(12, 444);
            this.labelBool.Name = "labelBool";
            this.labelBool.Size = new System.Drawing.Size(35, 13);
            this.labelBool.TabIndex = 3;
            this.labelBool.Text = "label1";
            // 
            // selector
            // 
            this.selector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selector.AutoScroll = true;
            this.selector.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.selector.BackColor = System.Drawing.SystemColors.GrayText;
            this.selector.Controls.Add(this.pictureBox1);
            this.selector.Controls.Add(this.pictureBox4);
            this.selector.Controls.Add(this.pictureBox5);
            this.selector.Controls.Add(this.pictureBox2);
            this.selector.Controls.Add(this.pictureBox7);
            this.selector.Controls.Add(this.pictureBox8);
            this.selector.Controls.Add(this.pictureBox3);
            this.selector.Controls.Add(this.pictureBox6);
            this.selector.Controls.Add(this.pictureBox9);
            this.selector.Location = new System.Drawing.Point(12, 13);
            this.selector.Name = "selector";
            this.selector.Size = new System.Drawing.Size(233, 412);
            this.selector.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::prueba.Properties.Resources.mesa_negra;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "Mesa";
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.item_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.item_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.item_MouseUp);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Image = global::prueba.Properties.Resources.mesa_redonda_normal;
            this.pictureBox4.Location = new System.Drawing.Point(105, 0);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(105, 105);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "Mesa";
            this.pictureBox4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.item_MouseDown);
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.item_MouseMove);
            this.pictureBox4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.item_MouseUp);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox5.Image = global::prueba.Properties.Resources.mesa_cuadrada;
            this.pictureBox5.Location = new System.Drawing.Point(0, 105);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(105, 105);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Tag = "Mesa";
            this.pictureBox5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.item_MouseDown);
            this.pictureBox5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.item_MouseMove);
            this.pictureBox5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.item_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = global::prueba.Properties.Resources.mesa_grande_negra_recorte;
            this.pictureBox2.Location = new System.Drawing.Point(105, 105);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(105, 105);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "Mesa Grande";
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.item_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.item_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.item_MouseUp);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox7.Image = global::prueba.Properties.Resources.pared_roja;
            this.pictureBox7.InitialImage = global::prueba.Properties.Resources._5f6acd2ede815a125e954977821f8ed3;
            this.pictureBox7.Location = new System.Drawing.Point(0, 210);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(105, 105);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 0;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Tag = "Pared";
            this.pictureBox7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.item_MouseDown);
            this.pictureBox7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.item_MouseMove);
            this.pictureBox7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.item_MouseUp);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox8.Image = global::prueba.Properties.Resources._5f6acd2ede815a125e954977821f8ed3;
            this.pictureBox8.Location = new System.Drawing.Point(105, 210);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(105, 105);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 0;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.item_MouseDown);
            this.pictureBox8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.item_MouseMove);
            this.pictureBox8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.item_MouseUp);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Image = global::prueba.Properties.Resources._5f6acd2ede815a125e954977821f8ed3;
            this.pictureBox3.Location = new System.Drawing.Point(0, 315);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(105, 105);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.item_MouseDown);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.item_MouseMove);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.item_MouseUp);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox6.Image = global::prueba.Properties.Resources._5f6acd2ede815a125e954977821f8ed3;
            this.pictureBox6.Location = new System.Drawing.Point(105, 315);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(105, 105);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.item_MouseDown);
            this.pictureBox6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.item_MouseMove);
            this.pictureBox6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.item_MouseUp);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox9.Image = global::prueba.Properties.Resources._5f6acd2ede815a125e954977821f8ed3;
            this.pictureBox9.Location = new System.Drawing.Point(0, 420);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(105, 105);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 0;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.item_MouseDown);
            this.pictureBox9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.item_MouseMove);
            this.pictureBox9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.item_MouseUp);
            // 
            // panel
            // 
            this.panel.AllowDrop = true;
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoSize = true;
            this.panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Location = new System.Drawing.Point(284, 13);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(486, 412);
            this.panel.TabIndex = 1;
            this.panel.TabStop = false;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.selector);
            this.Controls.Add(this.labelBool);
            this.Controls.Add(this.label);
            this.Controls.Add(this.panel);
            this.Name = "Editor";
            this.Size = new System.Drawing.Size(783, 489);
            this.Tag = "Mesa";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rotar);
            this.selector.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelBool;
        public Plano panel;
        private System.Windows.Forms.FlowLayoutPanel selector;
    }
}
