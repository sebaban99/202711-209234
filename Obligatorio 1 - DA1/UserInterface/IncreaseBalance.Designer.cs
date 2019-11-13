namespace UserInterface
{
    partial class IncreaseBalance
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
            this.lblBalanceToIncrease = new System.Windows.Forms.Label();
            this.txtBalanceToIncrease = new System.Windows.Forms.TextBox();
            this.lblIncreaseBalance = new System.Windows.Forms.Label();
            this.btnAcceptIncrease = new System.Windows.Forms.Button();
            this.lblPhoneNumberIncrease = new System.Windows.Forms.Label();
            this.txtPhoneNumberIncrease = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblBalanceToIncrease
            // 
            this.lblBalanceToIncrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBalanceToIncrease.AutoSize = true;
            this.lblBalanceToIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceToIncrease.Location = new System.Drawing.Point(75, 170);
            this.lblBalanceToIncrease.Name = "lblBalanceToIncrease";
            this.lblBalanceToIncrease.Size = new System.Drawing.Size(148, 24);
            this.lblBalanceToIncrease.TabIndex = 15;
            this.lblBalanceToIncrease.Text = "Saldo a agregar:";
            // 
            // txtBalanceToIncrease
            // 
            this.txtBalanceToIncrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBalanceToIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceToIncrease.Location = new System.Drawing.Point(230, 170);
            this.txtBalanceToIncrease.Name = "txtBalanceToIncrease";
            this.txtBalanceToIncrease.Size = new System.Drawing.Size(160, 29);
            this.txtBalanceToIncrease.TabIndex = 14;
            this.txtBalanceToIncrease.Tag = "";
            // 
            // lblIncreaseBalance
            // 
            this.lblIncreaseBalance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIncreaseBalance.AutoSize = true;
            this.lblIncreaseBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncreaseBalance.Location = new System.Drawing.Point(145, 60);
            this.lblIncreaseBalance.Name = "lblIncreaseBalance";
            this.lblIncreaseBalance.Size = new System.Drawing.Size(182, 31);
            this.lblIncreaseBalance.TabIndex = 13;
            this.lblIncreaseBalance.Text = "Agregar saldo";
            // 
            // btnAcceptIncrease
            // 
            this.btnAcceptIncrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcceptIncrease.Location = new System.Drawing.Point(280, 230);
            this.btnAcceptIncrease.Name = "btnAcceptIncrease";
            this.btnAcceptIncrease.Size = new System.Drawing.Size(100, 35);
            this.btnAcceptIncrease.TabIndex = 12;
            this.btnAcceptIncrease.Text = "Aceptar";
            this.btnAcceptIncrease.UseVisualStyleBackColor = true;
            this.btnAcceptIncrease.Click += new System.EventHandler(this.BtnAcceptIncrease_Click);
            // 
            // lblPhoneNumberIncrease
            // 
            this.lblPhoneNumberIncrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPhoneNumberIncrease.AutoSize = true;
            this.lblPhoneNumberIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumberIncrease.Location = new System.Drawing.Point(75, 130);
            this.lblPhoneNumberIncrease.Name = "lblPhoneNumberIncrease";
            this.lblPhoneNumberIncrease.Size = new System.Drawing.Size(133, 24);
            this.lblPhoneNumberIncrease.TabIndex = 11;
            this.lblPhoneNumberIncrease.Text = "Número móvil:";
            // 
            // txtPhoneNumberIncrease
            // 
            this.txtPhoneNumberIncrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPhoneNumberIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumberIncrease.Location = new System.Drawing.Point(230, 130);
            this.txtPhoneNumberIncrease.Name = "txtPhoneNumberIncrease";
            this.txtPhoneNumberIncrease.Size = new System.Drawing.Size(160, 29);
            this.txtPhoneNumberIncrease.TabIndex = 10;
            this.txtPhoneNumberIncrease.Tag = "";
            // 
            // IncreaseBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBalanceToIncrease);
            this.Controls.Add(this.txtBalanceToIncrease);
            this.Controls.Add(this.lblIncreaseBalance);
            this.Controls.Add(this.btnAcceptIncrease);
            this.Controls.Add(this.lblPhoneNumberIncrease);
            this.Controls.Add(this.txtPhoneNumberIncrease);
            this.Name = "IncreaseBalance";
            this.Size = new System.Drawing.Size(464, 324);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBalanceToIncrease;
        private System.Windows.Forms.TextBox txtBalanceToIncrease;
        private System.Windows.Forms.Label lblIncreaseBalance;
        private System.Windows.Forms.Button btnAcceptIncrease;
        private System.Windows.Forms.Label lblPhoneNumberIncrease;
        private System.Windows.Forms.TextBox txtPhoneNumberIncrease;
    }
}
