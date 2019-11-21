namespace UserInterface
{
    partial class ActivePurchase
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
            this.dtpActivePurchase = new System.Windows.Forms.DateTimePicker();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.lblLicencePlate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAcceptActivePurchase = new System.Windows.Forms.Button();
            this.txtLicencePlate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtpActivePurchase
            // 
            this.dtpActivePurchase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpActivePurchase.Checked = false;
            this.dtpActivePurchase.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpActivePurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpActivePurchase.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActivePurchase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpActivePurchase.Location = new System.Drawing.Point(200, 170);
            this.dtpActivePurchase.Name = "dtpActivePurchase";
            this.dtpActivePurchase.Size = new System.Drawing.Size(212, 26);
            this.dtpActivePurchase.TabIndex = 16;
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseDate.Location = new System.Drawing.Point(75, 170);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(69, 24);
            this.lblPurchaseDate.TabIndex = 15;
            this.lblPurchaseDate.Text = "Fecha:";
            // 
            // lblLicencePlate
            // 
            this.lblLicencePlate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLicencePlate.AutoSize = true;
            this.lblLicencePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicencePlate.Location = new System.Drawing.Point(75, 130);
            this.lblLicencePlate.Name = "lblLicencePlate";
            this.lblLicencePlate.Size = new System.Drawing.Size(90, 24);
            this.lblLicencePlate.TabIndex = 14;
            this.lblLicencePlate.Text = "Matrícula:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "Consulta de compra activa";
            // 
            // btnAcceptActivePurchase
            // 
            this.btnAcceptActivePurchase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcceptActivePurchase.Location = new System.Drawing.Point(280, 230);
            this.btnAcceptActivePurchase.Name = "btnAcceptActivePurchase";
            this.btnAcceptActivePurchase.Size = new System.Drawing.Size(100, 35);
            this.btnAcceptActivePurchase.TabIndex = 12;
            this.btnAcceptActivePurchase.Text = "Aceptar";
            this.btnAcceptActivePurchase.UseVisualStyleBackColor = true;
            this.btnAcceptActivePurchase.Click += new System.EventHandler(this.BtnAcceptActivePurchase_Click);
            // 
            // txtLicencePlate
            // 
            this.txtLicencePlate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLicencePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicencePlate.Location = new System.Drawing.Point(200, 130);
            this.txtLicencePlate.Name = "txtLicencePlate";
            this.txtLicencePlate.Size = new System.Drawing.Size(212, 29);
            this.txtLicencePlate.TabIndex = 11;
            this.txtLicencePlate.Tag = "";
            // 
            // ActivePurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpActivePurchase);
            this.Controls.Add(this.lblPurchaseDate);
            this.Controls.Add(this.lblLicencePlate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAcceptActivePurchase);
            this.Controls.Add(this.txtLicencePlate);
            this.Name = "ActivePurchase";
            this.Size = new System.Drawing.Size(464, 324);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpActivePurchase;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.Label lblLicencePlate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAcceptActivePurchase;
        private System.Windows.Forms.TextBox txtLicencePlate;
    }
}
