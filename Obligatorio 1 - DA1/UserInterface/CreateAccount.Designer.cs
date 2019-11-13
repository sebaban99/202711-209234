namespace UserInterface
{
    partial class CreateAccount
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
            this.lblCreateAccount = new System.Windows.Forms.Label();
            this.btnAcceptCreateAccount = new System.Windows.Forms.Button();
            this.lblPhoneNumberCreateAccount = new System.Windows.Forms.Label();
            this.txtPhoneNumberCreateAccount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCreateAccount
            // 
            this.lblCreateAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCreateAccount.AutoSize = true;
            this.lblCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateAccount.Location = new System.Drawing.Point(149, 60);
            this.lblCreateAccount.Name = "lblCreateAccount";
            this.lblCreateAccount.Size = new System.Drawing.Size(171, 31);
            this.lblCreateAccount.TabIndex = 11;
            this.lblCreateAccount.Text = "Crear cuenta";
            // 
            // btnAcceptCreateAccount
            // 
            this.btnAcceptCreateAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcceptCreateAccount.Location = new System.Drawing.Point(280, 230);
            this.btnAcceptCreateAccount.Name = "btnAcceptCreateAccount";
            this.btnAcceptCreateAccount.Size = new System.Drawing.Size(100, 35);
            this.btnAcceptCreateAccount.TabIndex = 10;
            this.btnAcceptCreateAccount.Text = "Aceptar";
            this.btnAcceptCreateAccount.UseVisualStyleBackColor = true;
            this.btnAcceptCreateAccount.Click += new System.EventHandler(this.BtnAcceptCreateAccount_Click);
            // 
            // lblPhoneNumberCreateAccount
            // 
            this.lblPhoneNumberCreateAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPhoneNumberCreateAccount.AutoSize = true;
            this.lblPhoneNumberCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumberCreateAccount.Location = new System.Drawing.Point(66, 150);
            this.lblPhoneNumberCreateAccount.Name = "lblPhoneNumberCreateAccount";
            this.lblPhoneNumberCreateAccount.Size = new System.Drawing.Size(133, 24);
            this.lblPhoneNumberCreateAccount.TabIndex = 9;
            this.lblPhoneNumberCreateAccount.Text = "Número móvil:";
            // 
            // txtPhoneNumberCreateAccount
            // 
            this.txtPhoneNumberCreateAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPhoneNumberCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumberCreateAccount.Location = new System.Drawing.Point(214, 150);
            this.txtPhoneNumberCreateAccount.Name = "txtPhoneNumberCreateAccount";
            this.txtPhoneNumberCreateAccount.Size = new System.Drawing.Size(160, 29);
            this.txtPhoneNumberCreateAccount.TabIndex = 8;
            this.txtPhoneNumberCreateAccount.Tag = "";
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCreateAccount);
            this.Controls.Add(this.btnAcceptCreateAccount);
            this.Controls.Add(this.lblPhoneNumberCreateAccount);
            this.Controls.Add(this.txtPhoneNumberCreateAccount);
            this.Name = "CreateAccount";
            this.Size = new System.Drawing.Size(464, 324);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCreateAccount;
        private System.Windows.Forms.Button btnAcceptCreateAccount;
        private System.Windows.Forms.Label lblPhoneNumberCreateAccount;
        private System.Windows.Forms.TextBox txtPhoneNumberCreateAccount;
    }
}
