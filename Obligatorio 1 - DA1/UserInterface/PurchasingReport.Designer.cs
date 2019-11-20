namespace UserInterface
{
    partial class PurchasingReport
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
            this.dtpFinishingDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartingDay = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblFinishingDate = new System.Windows.Forms.Label();
            this.dtpStartingDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartingHour = new System.Windows.Forms.DateTimePicker();
            this.lblStartingHour = new System.Windows.Forms.Label();
            this.lblFinishingHour = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.pnlReport = new System.Windows.Forms.FlowLayoutPanel();
            this.dgReport = new System.Windows.Forms.DataGridView();
            this.columnLicensePlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStartingHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFinishingHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.dtpFinishingHour = new System.Windows.Forms.DateTimePicker();
            this.lblTitleTable = new System.Windows.Forms.Label();
            this.pnlReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFinishingDate
            // 
            this.dtpFinishingDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFinishingDate.Checked = false;
            this.dtpFinishingDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFinishingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinishingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinishingDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpFinishingDate.Location = new System.Drawing.Point(330, 114);
            this.dtpFinishingDate.Name = "dtpFinishingDate";
            this.dtpFinishingDate.Size = new System.Drawing.Size(111, 26);
            this.dtpFinishingDate.TabIndex = 22;
            // 
            // lblStartingDay
            // 
            this.lblStartingDay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStartingDay.AutoSize = true;
            this.lblStartingDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartingDay.Location = new System.Drawing.Point(28, 117);
            this.lblStartingDay.Name = "lblStartingDay";
            this.lblStartingDay.Size = new System.Drawing.Size(97, 20);
            this.lblStartingDay.TabIndex = 21;
            this.lblStartingDay.Text = "Fecha inicio:";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(103, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 31);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Reporte de compras";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAccept.Location = new System.Drawing.Point(280, 230);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 35);
            this.btnAccept.TabIndex = 18;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // lblFinishingDate
            // 
            this.lblFinishingDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFinishingDate.AutoSize = true;
            this.lblFinishingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinishingDate.Location = new System.Drawing.Point(248, 117);
            this.lblFinishingDate.Name = "lblFinishingDate";
            this.lblFinishingDate.Size = new System.Drawing.Size(79, 20);
            this.lblFinishingDate.TabIndex = 23;
            this.lblFinishingDate.Text = "Fecha fin:";
            // 
            // dtpStartingDate
            // 
            this.dtpStartingDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpStartingDate.Checked = false;
            this.dtpStartingDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartingDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpStartingDate.Location = new System.Drawing.Point(128, 114);
            this.dtpStartingDate.Name = "dtpStartingDate";
            this.dtpStartingDate.Size = new System.Drawing.Size(111, 26);
            this.dtpStartingDate.TabIndex = 24;
            // 
            // dtpStartingHour
            // 
            this.dtpStartingHour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpStartingHour.Checked = false;
            this.dtpStartingHour.CustomFormat = "HH:mm";
            this.dtpStartingHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartingHour.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartingHour.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpStartingHour.Location = new System.Drawing.Point(128, 158);
            this.dtpStartingHour.Name = "dtpStartingHour";
            this.dtpStartingHour.ShowUpDown = true;
            this.dtpStartingHour.Size = new System.Drawing.Size(111, 26);
            this.dtpStartingHour.TabIndex = 26;
            this.dtpStartingHour.Value = new System.DateTime(2019, 11, 17, 15, 18, 42, 0);
            // 
            // lblStartingHour
            // 
            this.lblStartingHour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStartingHour.AutoSize = true;
            this.lblStartingHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartingHour.Location = new System.Drawing.Point(28, 161);
            this.lblStartingHour.Name = "lblStartingHour";
            this.lblStartingHour.Size = new System.Drawing.Size(87, 20);
            this.lblStartingHour.TabIndex = 25;
            this.lblStartingHour.Text = "Hora inicio:";
            // 
            // lblFinishingHour
            // 
            this.lblFinishingHour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFinishingHour.AutoSize = true;
            this.lblFinishingHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinishingHour.Location = new System.Drawing.Point(248, 161);
            this.lblFinishingHour.Name = "lblFinishingHour";
            this.lblFinishingHour.Size = new System.Drawing.Size(69, 20);
            this.lblFinishingHour.TabIndex = 27;
            this.lblFinishingHour.Text = "Hora fin:";
            // 
            // lblCountry
            // 
            this.lblCountry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(28, 205);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 20);
            this.lblCountry.TabIndex = 29;
            this.lblCountry.Text = "País:";
            // 
            // cbCountry
            // 
            this.cbCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Items.AddRange(new object[] {
            "Argentina",
            "Uruguay"});
            this.cbCountry.Location = new System.Drawing.Point(128, 202);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(111, 28);
            this.cbCountry.TabIndex = 30;
            // 
            // pnlReport
            // 
            this.pnlReport.Controls.Add(this.dgReport);
            this.pnlReport.Controls.Add(this.btnExit);
            this.pnlReport.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlReport.Location = new System.Drawing.Point(3, 34);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(458, 287);
            this.pnlReport.TabIndex = 31;
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
            // dtpFinishingHour
            // 
            this.dtpFinishingHour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFinishingHour.Checked = false;
            this.dtpFinishingHour.CustomFormat = "HH:mm";
            this.dtpFinishingHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinishingHour.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFinishingHour.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpFinishingHour.Location = new System.Drawing.Point(330, 158);
            this.dtpFinishingHour.Name = "dtpFinishingHour";
            this.dtpFinishingHour.ShowUpDown = true;
            this.dtpFinishingHour.Size = new System.Drawing.Size(111, 26);
            this.dtpFinishingHour.TabIndex = 28;
            this.dtpFinishingHour.Value = new System.DateTime(2019, 11, 17, 18, 0, 0, 0);
            // 
            // lblTitleTable
            // 
            this.lblTitleTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitleTable.AutoSize = true;
            this.lblTitleTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleTable.Location = new System.Drawing.Point(103, 0);
            this.lblTitleTable.Name = "lblTitleTable";
            this.lblTitleTable.Size = new System.Drawing.Size(259, 31);
            this.lblTitleTable.TabIndex = 32;
            this.lblTitleTable.Text = "Reporte de compras";
            // 
            // PurchasingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitleTable);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.dtpFinishingHour);
            this.Controls.Add(this.lblFinishingHour);
            this.Controls.Add(this.dtpStartingHour);
            this.Controls.Add(this.lblStartingHour);
            this.Controls.Add(this.dtpStartingDate);
            this.Controls.Add(this.lblFinishingDate);
            this.Controls.Add(this.dtpFinishingDate);
            this.Controls.Add(this.lblStartingDay);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.pnlReport);
            this.Name = "PurchasingReport";
            this.Size = new System.Drawing.Size(464, 324);
            this.pnlReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFinishingDate;
        private System.Windows.Forms.Label lblStartingDay;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblFinishingDate;
        private System.Windows.Forms.DateTimePicker dtpStartingDate;
        private System.Windows.Forms.DateTimePicker dtpStartingHour;
        private System.Windows.Forms.Label lblStartingHour;
        private System.Windows.Forms.Label lblFinishingHour;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.FlowLayoutPanel pnlReport;
        private System.Windows.Forms.DataGridView dgReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLicensePlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStartingHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFinishingHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCountry;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpFinishingHour;
        private System.Windows.Forms.Label lblTitleTable;
    }
}
