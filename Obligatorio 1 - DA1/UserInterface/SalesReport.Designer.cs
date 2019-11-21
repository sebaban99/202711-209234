namespace UserInterface
{
    partial class SalesReport
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlReport = new System.Windows.Forms.FlowLayoutPanel();
            this.dgReport = new System.Windows.Forms.DataGridView();
            this.columnLicensePlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStartingHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFinishingHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblLicensePlate = new System.Windows.Forms.Label();
            this.txtLicensePlate = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitleTable = new System.Windows.Forms.Label();
            this.pnlReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(113, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(236, 31);
            this.lblTitle.TabIndex = 32;
            this.lblTitle.Text = "Reporte de ventas";
            // 
            // pnlReport
            // 
            this.pnlReport.Controls.Add(this.dgReport);
            this.pnlReport.Controls.Add(this.btnExit);
            this.pnlReport.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlReport.Location = new System.Drawing.Point(3, 34);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(458, 287);
            this.pnlReport.TabIndex = 33;
            // 
            // dgReport
            // 
            this.dgReport.AllowUserToAddRows = false;
            this.dgReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnLicensePlate,
            this.columnDate,
            this.columnStartingHour,
            this.columnFinishingHour,
            this.columnCountry});
            this.dgReport.Location = new System.Drawing.Point(5, 3);
            this.dgReport.Name = "dgReport";
            this.dgReport.RowHeadersVisible = false;
            this.dgReport.RowHeadersWidth = 53;
            this.dgReport.Size = new System.Drawing.Size(450, 236);
            this.dgReport.TabIndex = 0;
            // 
            // columnLicensePlate
            // 
            this.columnLicensePlate.HeaderText = "Matrícula";
            this.columnLicensePlate.Name = "columnLicensePlate";
            this.columnLicensePlate.Width = 92;
            // 
            // columnDate
            // 
            this.columnDate.HeaderText = "Fecha";
            this.columnDate.Name = "columnDate";
            this.columnDate.Width = 92;
            // 
            // columnStartingHour
            // 
            this.columnStartingHour.HeaderText = "Hora inicio";
            this.columnStartingHour.Name = "columnStartingHour";
            this.columnStartingHour.Width = 85;
            // 
            // columnFinishingHour
            // 
            this.columnFinishingHour.HeaderText = "Hora fin";
            this.columnFinishingHour.Name = "columnFinishingHour";
            this.columnFinishingHour.Width = 85;
            // 
            // columnCountry
            // 
            this.columnCountry.HeaderText = "País";
            this.columnCountry.Name = "columnCountry";
            this.columnCountry.Width = 92;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(355, 245);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 35);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Aceptar";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // lblLicensePlate
            // 
            this.lblLicensePlate.AutoSize = true;
            this.lblLicensePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicensePlate.Location = new System.Drawing.Point(111, 150);
            this.lblLicensePlate.Name = "lblLicensePlate";
            this.lblLicensePlate.Size = new System.Drawing.Size(77, 20);
            this.lblLicensePlate.TabIndex = 34;
            this.lblLicensePlate.Text = "Matrícula:";
            // 
            // txtLicensePlate
            // 
            this.txtLicensePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicensePlate.Location = new System.Drawing.Point(203, 148);
            this.txtLicensePlate.Name = "txtLicensePlate";
            this.txtLicensePlate.Size = new System.Drawing.Size(148, 26);
            this.txtLicensePlate.TabIndex = 35;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAccept.Location = new System.Drawing.Point(280, 230);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 35);
            this.btnAccept.TabIndex = 36;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // lblTitleTable
            // 
            this.lblTitleTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitleTable.AutoSize = true;
            this.lblTitleTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleTable.Location = new System.Drawing.Point(113, 0);
            this.lblTitleTable.Name = "lblTitleTable";
            this.lblTitleTable.Size = new System.Drawing.Size(236, 31);
            this.lblTitleTable.TabIndex = 37;
            this.lblTitleTable.Text = "Reporte de ventas";
            // 
            // SalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitleTable);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtLicensePlate);
            this.Controls.Add(this.lblLicensePlate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlReport);
            this.Name = "SalesReport";
            this.Size = new System.Drawing.Size(464, 324);
            this.pnlReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel pnlReport;
        private System.Windows.Forms.DataGridView dgReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLicensePlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStartingHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFinishingHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCountry;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblLicensePlate;
        private System.Windows.Forms.TextBox txtLicensePlate;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblTitleTable;
    }
}
