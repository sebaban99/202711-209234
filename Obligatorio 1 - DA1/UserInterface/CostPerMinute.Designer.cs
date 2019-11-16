namespace UserInterface
{
    partial class CostPerMinute
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numCostPerMinute = new System.Windows.Forms.NumericUpDown();
            this.lblSetCostPerMinute = new System.Windows.Forms.Label();
            this.btnAcceptCostPerMinute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCostPerMinute)).BeginInit();
            this.SuspendLayout();
            // 
            // numCostPerMinute
            // 
            this.numCostPerMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCostPerMinute.Location = new System.Drawing.Point(350, 279);
            this.numCostPerMinute.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numCostPerMinute.Maximum = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            0});
            this.numCostPerMinute.Name = "numCostPerMinute";
            this.numCostPerMinute.Size = new System.Drawing.Size(240, 51);
            this.numCostPerMinute.TabIndex = 11;
            // 
            // lblSetCostPerMinute
            // 
            this.lblSetCostPerMinute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSetCostPerMinute.AutoSize = true;
            this.lblSetCostPerMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetCostPerMinute.Location = new System.Drawing.Point(166, 115);
            this.lblSetCostPerMinute.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSetCostPerMinute.Name = "lblSetCostPerMinute";
            this.lblSetCostPerMinute.Size = new System.Drawing.Size(598, 63);
            this.lblSetCostPerMinute.TabIndex = 10;
            this.lblSetCostPerMinute.Text = "Setear costo por minuto";
            // 
            // btnAcceptCostPerMinute
            // 
            this.btnAcceptCostPerMinute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcceptCostPerMinute.Location = new System.Drawing.Point(560, 442);
            this.btnAcceptCostPerMinute.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAcceptCostPerMinute.Name = "btnAcceptCostPerMinute";
            this.btnAcceptCostPerMinute.Size = new System.Drawing.Size(200, 67);
            this.btnAcceptCostPerMinute.TabIndex = 9;
            this.btnAcceptCostPerMinute.Text = "Aceptar";
            this.btnAcceptCostPerMinute.UseVisualStyleBackColor = true;
            this.btnAcceptCostPerMinute.Click += new System.EventHandler(this.BtnAcceptCostPerMinute_Click);
            // 
            // CostPerMinute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numCostPerMinute);
            this.Controls.Add(this.lblSetCostPerMinute);
            this.Controls.Add(this.btnAcceptCostPerMinute);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "CostPerMinute";
            this.Size = new System.Drawing.Size(928, 623);
            ((System.ComponentModel.ISupportInitialize)(this.numCostPerMinute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numCostPerMinute;
        private System.Windows.Forms.Label lblSetCostPerMinute;
        private System.Windows.Forms.Button btnAcceptCostPerMinute;
    }
}
