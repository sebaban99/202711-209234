namespace UserInterface
{
    partial class SMSSimulator
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
            this.lblText = new System.Windows.Forms.Label();
            this.txtPurchaseMessage = new System.Windows.Forms.TextBox();
            this.lblSMSSimulator = new System.Windows.Forms.Label();
            this.btnAcceptSimulator = new System.Windows.Forms.Button();
            this.lblPhoneNumberSimulator = new System.Windows.Forms.Label();
            this.txtPhoneNumberSimulator = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(75, 170);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(63, 24);
            this.lblText.TabIndex = 15;
            this.lblText.Text = "Texto:";
            // 
            // txtPurchaseMessage
            // 
            this.txtPurchaseMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPurchaseMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseMessage.Location = new System.Drawing.Point(230, 170);
            this.txtPurchaseMessage.Name = "txtPurchaseMessage";
            this.txtPurchaseMessage.Size = new System.Drawing.Size(160, 29);
            this.txtPurchaseMessage.TabIndex = 14;
            this.txtPurchaseMessage.Tag = "";
            // 
            // lblSMSSimulator
            // 
            this.lblSMSSimulator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSMSSimulator.AutoSize = true;
            this.lblSMSSimulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMSSimulator.Location = new System.Drawing.Point(145, 60);
            this.lblSMSSimulator.Name = "lblSMSSimulator";
            this.lblSMSSimulator.Size = new System.Drawing.Size(200, 31);
            this.lblSMSSimulator.TabIndex = 13;
            this.lblSMSSimulator.Text = "Simulador SMS";
            // 
            // btnAcceptSimulator
            // 
            this.btnAcceptSimulator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcceptSimulator.Location = new System.Drawing.Point(280, 230);
            this.btnAcceptSimulator.Name = "btnAcceptSimulator";
            this.btnAcceptSimulator.Size = new System.Drawing.Size(100, 35);
            this.btnAcceptSimulator.TabIndex = 12;
            this.btnAcceptSimulator.Text = "Aceptar";
            this.btnAcceptSimulator.UseVisualStyleBackColor = true;
            this.btnAcceptSimulator.Click += new System.EventHandler(this.BtnAcceptSimulator_Click);
            // 
            // lblPhoneNumberSimulator
            // 
            this.lblPhoneNumberSimulator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPhoneNumberSimulator.AutoSize = true;
            this.lblPhoneNumberSimulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumberSimulator.Location = new System.Drawing.Point(75, 130);
            this.lblPhoneNumberSimulator.Name = "lblPhoneNumberSimulator";
            this.lblPhoneNumberSimulator.Size = new System.Drawing.Size(133, 24);
            this.lblPhoneNumberSimulator.TabIndex = 11;
            this.lblPhoneNumberSimulator.Text = "Número móvil:";
            // 
            // txtPhoneNumberSimulator
            // 
            this.txtPhoneNumberSimulator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPhoneNumberSimulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumberSimulator.Location = new System.Drawing.Point(230, 130);
            this.txtPhoneNumberSimulator.Name = "txtPhoneNumberSimulator";
            this.txtPhoneNumberSimulator.Size = new System.Drawing.Size(160, 29);
            this.txtPhoneNumberSimulator.TabIndex = 10;
            this.txtPhoneNumberSimulator.Tag = "";
            // 
            // SMSSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtPurchaseMessage);
            this.Controls.Add(this.lblSMSSimulator);
            this.Controls.Add(this.btnAcceptSimulator);
            this.Controls.Add(this.lblPhoneNumberSimulator);
            this.Controls.Add(this.txtPhoneNumberSimulator);
            this.Name = "SMSSimulator";
            this.Size = new System.Drawing.Size(464, 324);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtPurchaseMessage;
        private System.Windows.Forms.Label lblSMSSimulator;
        private System.Windows.Forms.Button btnAcceptSimulator;
        private System.Windows.Forms.Label lblPhoneNumberSimulator;
        private System.Windows.Forms.TextBox txtPhoneNumberSimulator;
    }
}
