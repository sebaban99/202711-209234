namespace UserInterface
{
    partial class UserInterface
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recargaDeSaldoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valorCostoPorMinutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlCreateAccount = new System.Windows.Forms.Panel();
            this.lblCreateAccount = new System.Windows.Forms.Label();
            this.btnAcceptCreateAccount = new System.Windows.Forms.Button();
            this.lblPhoneNumberCreateAccount = new System.Windows.Forms.Label();
            this.txtPhoneNumberCreateAccount = new System.Windows.Forms.TextBox();
            this.pnlIncreaseBalance = new System.Windows.Forms.Panel();
            this.lblBalanceToIncrease = new System.Windows.Forms.Label();
            this.txtBalanceToIncrease = new System.Windows.Forms.TextBox();
            this.lblIncreaseBalance = new System.Windows.Forms.Label();
            this.btnAcceptIncrease = new System.Windows.Forms.Button();
            this.lblPhoneNumberIncrease = new System.Windows.Forms.Label();
            this.txtPhoneNumberIncrease = new System.Windows.Forms.TextBox();
            this.pnlSMSSimulator = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.Label();
            this.txtPurchaseMessage = new System.Windows.Forms.TextBox();
            this.lblSMSSimulator = new System.Windows.Forms.Label();
            this.btnAcceptSimulator = new System.Windows.Forms.Button();
            this.lblPhoneNumberSimulator = new System.Windows.Forms.Label();
            this.txtPhoneNumberSimulator = new System.Windows.Forms.TextBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlCostPerMinute = new System.Windows.Forms.Panel();
            this.numCostPerMinute = new System.Windows.Forms.NumericUpDown();
            this.lblSetCostPerMinute = new System.Windows.Forms.Label();
            this.btnAcceptCostPerMinute = new System.Windows.Forms.Button();
            this.pnlPurchaseActive = new System.Windows.Forms.Panel();
            this.dtpActivePurchase = new System.Windows.Forms.DateTimePicker();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.lblLicencePlate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAcceptActivePurchase = new System.Windows.Forms.Button();
            this.txtLicencePlate = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.pnlCreateAccount.SuspendLayout();
            this.pnlIncreaseBalance.SuspendLayout();
            this.pnlSMSSimulator.SuspendLayout();
            this.pnlCostPerMinute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCostPerMinute)).BeginInit();
            this.pnlPurchaseActive.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentasToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.valorCostoPorMinutoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cuentasToolStripMenuItem
            // 
            this.cuentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearToolStripMenuItem,
            this.recargaDeSaldoToolStripMenuItem});
            this.cuentasToolStripMenuItem.Name = "cuentasToolStripMenuItem";
            this.cuentasToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.cuentasToolStripMenuItem.Text = "Cuentas";
            // 
            // crearToolStripMenuItem
            // 
            this.crearToolStripMenuItem.Name = "crearToolStripMenuItem";
            this.crearToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.crearToolStripMenuItem.Text = "Crear";
            this.crearToolStripMenuItem.Click += new System.EventHandler(this.CrearToolStripMenuItem_Click);
            // 
            // recargaDeSaldoToolStripMenuItem
            // 
            this.recargaDeSaldoToolStripMenuItem.Name = "recargaDeSaldoToolStripMenuItem";
            this.recargaDeSaldoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.recargaDeSaldoToolStripMenuItem.Text = "Recarga de saldo";
            this.recargaDeSaldoToolStripMenuItem.Click += new System.EventHandler(this.RecargaDeSaldoToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simularToolStripMenuItem,
            this.consultarToolStripMenuItem});
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // simularToolStripMenuItem
            // 
            this.simularToolStripMenuItem.Name = "simularToolStripMenuItem";
            this.simularToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.simularToolStripMenuItem.Text = "Simular";
            this.simularToolStripMenuItem.Click += new System.EventHandler(this.SimularToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.consultarToolStripMenuItem.Text = "Consultar";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.ConsultarToolStripMenuItem_Click);
            // 
            // valorCostoPorMinutoToolStripMenuItem
            // 
            this.valorCostoPorMinutoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setearToolStripMenuItem});
            this.valorCostoPorMinutoToolStripMenuItem.Name = "valorCostoPorMinutoToolStripMenuItem";
            this.valorCostoPorMinutoToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.valorCostoPorMinutoToolStripMenuItem.Text = "Valor costo por minuto";
            // 
            // setearToolStripMenuItem
            // 
            this.setearToolStripMenuItem.Name = "setearToolStripMenuItem";
            this.setearToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.setearToolStripMenuItem.Text = "Setear";
            this.setearToolStripMenuItem.Click += new System.EventHandler(this.SetearToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlCreateAccount
            // 
            this.pnlCreateAccount.Controls.Add(this.lblCreateAccount);
            this.pnlCreateAccount.Controls.Add(this.btnAcceptCreateAccount);
            this.pnlCreateAccount.Controls.Add(this.lblPhoneNumberCreateAccount);
            this.pnlCreateAccount.Controls.Add(this.txtPhoneNumberCreateAccount);
            this.pnlCreateAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCreateAccount.Location = new System.Drawing.Point(0, 0);
            this.pnlCreateAccount.Name = "pnlCreateAccount";
            this.pnlCreateAccount.Size = new System.Drawing.Size(800, 450);
            this.pnlCreateAccount.TabIndex = 2;
            // 
            // lblCreateAccount
            // 
            this.lblCreateAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCreateAccount.AutoSize = true;
            this.lblCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateAccount.Location = new System.Drawing.Point(320, 119);
            this.lblCreateAccount.Name = "lblCreateAccount";
            this.lblCreateAccount.Size = new System.Drawing.Size(171, 31);
            this.lblCreateAccount.TabIndex = 7;
            this.lblCreateAccount.Text = "Crear cuenta";
            // 
            // btnAcceptCreateAccount
            // 
            this.btnAcceptCreateAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcceptCreateAccount.Location = new System.Drawing.Point(442, 283);
            this.btnAcceptCreateAccount.Name = "btnAcceptCreateAccount";
            this.btnAcceptCreateAccount.Size = new System.Drawing.Size(102, 36);
            this.btnAcceptCreateAccount.TabIndex = 6;
            this.btnAcceptCreateAccount.Text = "Aceptar";
            this.btnAcceptCreateAccount.UseVisualStyleBackColor = true;
            this.btnAcceptCreateAccount.Click += new System.EventHandler(this.BtnAcceptCreateAccount_Click);
            // 
            // lblPhoneNumberCreateAccount
            // 
            this.lblPhoneNumberCreateAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPhoneNumberCreateAccount.AutoSize = true;
            this.lblPhoneNumberCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumberCreateAccount.Location = new System.Drawing.Point(245, 205);
            this.lblPhoneNumberCreateAccount.Name = "lblPhoneNumberCreateAccount";
            this.lblPhoneNumberCreateAccount.Size = new System.Drawing.Size(133, 24);
            this.lblPhoneNumberCreateAccount.TabIndex = 5;
            this.lblPhoneNumberCreateAccount.Text = "Número móvil:";
            // 
            // txtPhoneNumberCreateAccount
            // 
            this.txtPhoneNumberCreateAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPhoneNumberCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumberCreateAccount.Location = new System.Drawing.Point(384, 205);
            this.txtPhoneNumberCreateAccount.Name = "txtPhoneNumberCreateAccount";
            this.txtPhoneNumberCreateAccount.Size = new System.Drawing.Size(160, 29);
            this.txtPhoneNumberCreateAccount.TabIndex = 4;
            this.txtPhoneNumberCreateAccount.Tag = "";
            // 
            // pnlIncreaseBalance
            // 
            this.pnlIncreaseBalance.Controls.Add(this.lblBalanceToIncrease);
            this.pnlIncreaseBalance.Controls.Add(this.txtBalanceToIncrease);
            this.pnlIncreaseBalance.Controls.Add(this.lblIncreaseBalance);
            this.pnlIncreaseBalance.Controls.Add(this.btnAcceptIncrease);
            this.pnlIncreaseBalance.Controls.Add(this.lblPhoneNumberIncrease);
            this.pnlIncreaseBalance.Controls.Add(this.txtPhoneNumberIncrease);
            this.pnlIncreaseBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIncreaseBalance.Location = new System.Drawing.Point(0, 0);
            this.pnlIncreaseBalance.Name = "pnlIncreaseBalance";
            this.pnlIncreaseBalance.Size = new System.Drawing.Size(800, 450);
            this.pnlIncreaseBalance.TabIndex = 8;
            // 
            // lblBalanceToIncrease
            // 
            this.lblBalanceToIncrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBalanceToIncrease.AutoSize = true;
            this.lblBalanceToIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceToIncrease.Location = new System.Drawing.Point(240, 235);
            this.lblBalanceToIncrease.Name = "lblBalanceToIncrease";
            this.lblBalanceToIncrease.Size = new System.Drawing.Size(148, 24);
            this.lblBalanceToIncrease.TabIndex = 9;
            this.lblBalanceToIncrease.Text = "Saldo a agregar:";
            // 
            // txtBalanceToIncrease
            // 
            this.txtBalanceToIncrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBalanceToIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceToIncrease.Location = new System.Drawing.Point(397, 235);
            this.txtBalanceToIncrease.Name = "txtBalanceToIncrease";
            this.txtBalanceToIncrease.Size = new System.Drawing.Size(160, 29);
            this.txtBalanceToIncrease.TabIndex = 8;
            this.txtBalanceToIncrease.Tag = "";
            // 
            // lblIncreaseBalance
            // 
            this.lblIncreaseBalance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIncreaseBalance.AutoSize = true;
            this.lblIncreaseBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncreaseBalance.Location = new System.Drawing.Point(315, 102);
            this.lblIncreaseBalance.Name = "lblIncreaseBalance";
            this.lblIncreaseBalance.Size = new System.Drawing.Size(182, 31);
            this.lblIncreaseBalance.TabIndex = 7;
            this.lblIncreaseBalance.Text = "Agregar saldo";
            // 
            // btnAcceptIncrease
            // 
            this.btnAcceptIncrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcceptIncrease.Location = new System.Drawing.Point(455, 283);
            this.btnAcceptIncrease.Name = "btnAcceptIncrease";
            this.btnAcceptIncrease.Size = new System.Drawing.Size(102, 36);
            this.btnAcceptIncrease.TabIndex = 6;
            this.btnAcceptIncrease.Text = "Aceptar";
            this.btnAcceptIncrease.UseVisualStyleBackColor = true;
            this.btnAcceptIncrease.Click += new System.EventHandler(this.BtnAcceptIncrease_Click);
            // 
            // lblPhoneNumberIncrease
            // 
            this.lblPhoneNumberIncrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPhoneNumberIncrease.AutoSize = true;
            this.lblPhoneNumberIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumberIncrease.Location = new System.Drawing.Point(240, 188);
            this.lblPhoneNumberIncrease.Name = "lblPhoneNumberIncrease";
            this.lblPhoneNumberIncrease.Size = new System.Drawing.Size(133, 24);
            this.lblPhoneNumberIncrease.TabIndex = 5;
            this.lblPhoneNumberIncrease.Text = "Número móvil:";
            // 
            // txtPhoneNumberIncrease
            // 
            this.txtPhoneNumberIncrease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPhoneNumberIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumberIncrease.Location = new System.Drawing.Point(397, 188);
            this.txtPhoneNumberIncrease.Name = "txtPhoneNumberIncrease";
            this.txtPhoneNumberIncrease.Size = new System.Drawing.Size(160, 29);
            this.txtPhoneNumberIncrease.TabIndex = 4;
            this.txtPhoneNumberIncrease.Tag = "";
            // 
            // pnlSMSSimulator
            // 
            this.pnlSMSSimulator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSMSSimulator.Controls.Add(this.lblText);
            this.pnlSMSSimulator.Controls.Add(this.txtPurchaseMessage);
            this.pnlSMSSimulator.Controls.Add(this.lblSMSSimulator);
            this.pnlSMSSimulator.Controls.Add(this.btnAcceptSimulator);
            this.pnlSMSSimulator.Controls.Add(this.lblPhoneNumberSimulator);
            this.pnlSMSSimulator.Controls.Add(this.txtPhoneNumberSimulator);
            this.pnlSMSSimulator.Location = new System.Drawing.Point(0, -10);
            this.pnlSMSSimulator.Name = "pnlSMSSimulator";
            this.pnlSMSSimulator.Size = new System.Drawing.Size(800, 450);
            this.pnlSMSSimulator.TabIndex = 10;
            // 
            // lblText
            // 
            this.lblText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(233, 244);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(63, 24);
            this.lblText.TabIndex = 9;
            this.lblText.Text = "Texto:";
            // 
            // txtPurchaseMessage
            // 
            this.txtPurchaseMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPurchaseMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseMessage.Location = new System.Drawing.Point(390, 244);
            this.txtPurchaseMessage.Name = "txtPurchaseMessage";
            this.txtPurchaseMessage.Size = new System.Drawing.Size(160, 29);
            this.txtPurchaseMessage.TabIndex = 8;
            this.txtPurchaseMessage.Tag = "";
            // 
            // lblSMSSimulator
            // 
            this.lblSMSSimulator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSMSSimulator.AutoSize = true;
            this.lblSMSSimulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMSSimulator.Location = new System.Drawing.Point(307, 108);
            this.lblSMSSimulator.Name = "lblSMSSimulator";
            this.lblSMSSimulator.Size = new System.Drawing.Size(200, 31);
            this.lblSMSSimulator.TabIndex = 7;
            this.lblSMSSimulator.Text = "Simulador SMS";
            // 
            // btnAcceptSimulator
            // 
            this.btnAcceptSimulator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcceptSimulator.Location = new System.Drawing.Point(448, 295);
            this.btnAcceptSimulator.Name = "btnAcceptSimulator";
            this.btnAcceptSimulator.Size = new System.Drawing.Size(102, 36);
            this.btnAcceptSimulator.TabIndex = 6;
            this.btnAcceptSimulator.Text = "Aceptar";
            this.btnAcceptSimulator.UseVisualStyleBackColor = true;
            this.btnAcceptSimulator.Click += new System.EventHandler(this.BtnAcceptSimulator_Click);
            // 
            // lblPhoneNumberSimulator
            // 
            this.lblPhoneNumberSimulator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPhoneNumberSimulator.AutoSize = true;
            this.lblPhoneNumberSimulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumberSimulator.Location = new System.Drawing.Point(233, 197);
            this.lblPhoneNumberSimulator.Name = "lblPhoneNumberSimulator";
            this.lblPhoneNumberSimulator.Size = new System.Drawing.Size(133, 24);
            this.lblPhoneNumberSimulator.TabIndex = 5;
            this.lblPhoneNumberSimulator.Text = "Número móvil:";
            // 
            // txtPhoneNumberSimulator
            // 
            this.txtPhoneNumberSimulator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPhoneNumberSimulator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumberSimulator.Location = new System.Drawing.Point(390, 197);
            this.txtPhoneNumberSimulator.Name = "txtPhoneNumberSimulator";
            this.txtPhoneNumberSimulator.Size = new System.Drawing.Size(160, 29);
            this.txtPhoneNumberSimulator.TabIndex = 4;
            this.txtPhoneNumberSimulator.Tag = "";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(96, 185);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(603, 55);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "¡Bienvenido a Parking App!";
            // 
            // pnlCostPerMinute
            // 
            this.pnlCostPerMinute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCostPerMinute.Controls.Add(this.numCostPerMinute);
            this.pnlCostPerMinute.Controls.Add(this.lblSetCostPerMinute);
            this.pnlCostPerMinute.Controls.Add(this.btnAcceptCostPerMinute);
            this.pnlCostPerMinute.Location = new System.Drawing.Point(0, 0);
            this.pnlCostPerMinute.Name = "pnlCostPerMinute";
            this.pnlCostPerMinute.Size = new System.Drawing.Size(800, 450);
            this.pnlCostPerMinute.TabIndex = 10;
            // 
            // numCostPerMinute
            // 
            this.numCostPerMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCostPerMinute.Location = new System.Drawing.Point(253, 218);
            this.numCostPerMinute.Maximum = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            0});
            this.numCostPerMinute.Name = "numCostPerMinute";
            this.numCostPerMinute.Size = new System.Drawing.Size(120, 29);
            this.numCostPerMinute.TabIndex = 8;
            // 
            // lblSetCostPerMinute
            // 
            this.lblSetCostPerMinute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSetCostPerMinute.AutoSize = true;
            this.lblSetCostPerMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetCostPerMinute.Location = new System.Drawing.Point(247, 132);
            this.lblSetCostPerMinute.Name = "lblSetCostPerMinute";
            this.lblSetCostPerMinute.Size = new System.Drawing.Size(301, 31);
            this.lblSetCostPerMinute.TabIndex = 7;
            this.lblSetCostPerMinute.Text = "Setear costo por minuto";
            // 
            // btnAcceptCostPerMinute
            // 
            this.btnAcceptCostPerMinute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcceptCostPerMinute.Location = new System.Drawing.Point(442, 211);
            this.btnAcceptCostPerMinute.Name = "btnAcceptCostPerMinute";
            this.btnAcceptCostPerMinute.Size = new System.Drawing.Size(102, 36);
            this.btnAcceptCostPerMinute.TabIndex = 6;
            this.btnAcceptCostPerMinute.Text = "Aceptar";
            this.btnAcceptCostPerMinute.UseVisualStyleBackColor = true;
            this.btnAcceptCostPerMinute.Click += new System.EventHandler(this.BtnAcceptCostPerMinute_Click);
            // 
            // pnlPurchaseActive
            // 
            this.pnlPurchaseActive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlPurchaseActive.Controls.Add(this.dtpActivePurchase);
            this.pnlPurchaseActive.Controls.Add(this.lblPurchaseDate);
            this.pnlPurchaseActive.Controls.Add(this.lblLicencePlate);
            this.pnlPurchaseActive.Controls.Add(this.label1);
            this.pnlPurchaseActive.Controls.Add(this.btnAcceptActivePurchase);
            this.pnlPurchaseActive.Controls.Add(this.txtLicencePlate);
            this.pnlPurchaseActive.Location = new System.Drawing.Point(0, 0);
            this.pnlPurchaseActive.Name = "pnlPurchaseActive";
            this.pnlPurchaseActive.Size = new System.Drawing.Size(800, 450);
            this.pnlPurchaseActive.TabIndex = 11;
            // 
            // dtpActivePurchase
            // 
            this.dtpActivePurchase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpActivePurchase.Checked = false;
            this.dtpActivePurchase.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpActivePurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpActivePurchase.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActivePurchase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpActivePurchase.Location = new System.Drawing.Point(336, 240);
            this.dtpActivePurchase.Name = "dtpActivePurchase";
            this.dtpActivePurchase.Size = new System.Drawing.Size(212, 26);
            this.dtpActivePurchase.TabIndex = 10;
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseDate.Location = new System.Drawing.Point(240, 240);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(69, 24);
            this.lblPurchaseDate.TabIndex = 9;
            this.lblPurchaseDate.Text = "Fecha:";
            // 
            // lblLicencePlate
            // 
            this.lblLicencePlate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLicencePlate.AutoSize = true;
            this.lblLicencePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicencePlate.Location = new System.Drawing.Point(240, 191);
            this.lblLicencePlate.Name = "lblLicencePlate";
            this.lblLicencePlate.Size = new System.Drawing.Size(90, 24);
            this.lblLicencePlate.TabIndex = 8;
            this.lblLicencePlate.Text = "Matrícula:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(222, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Consulta de compra activa";
            // 
            // btnAcceptActivePurchase
            // 
            this.btnAcceptActivePurchase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcceptActivePurchase.Location = new System.Drawing.Point(464, 296);
            this.btnAcceptActivePurchase.Name = "btnAcceptActivePurchase";
            this.btnAcceptActivePurchase.Size = new System.Drawing.Size(84, 36);
            this.btnAcceptActivePurchase.TabIndex = 6;
            this.btnAcceptActivePurchase.Text = "Aceptar";
            this.btnAcceptActivePurchase.UseVisualStyleBackColor = true;
            this.btnAcceptActivePurchase.Click += new System.EventHandler(this.BtnAcceptActivePurchase_Click);
            // 
            // txtLicencePlate
            // 
            this.txtLicencePlate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLicencePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicencePlate.Location = new System.Drawing.Point(336, 188);
            this.txtLicencePlate.Name = "txtLicencePlate";
            this.txtLicencePlate.Size = new System.Drawing.Size(212, 29);
            this.txtLicencePlate.TabIndex = 4;
            this.txtLicencePlate.Tag = "";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pnlCreateAccount);
            this.Controls.Add(this.pnlIncreaseBalance);
            this.Controls.Add(this.pnlSMSSimulator);
            this.Controls.Add(this.pnlPurchaseActive);
            this.Controls.Add(this.pnlCostPerMinute);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserInterface";
            this.Text = "ParkingApp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlCreateAccount.ResumeLayout(false);
            this.pnlCreateAccount.PerformLayout();
            this.pnlIncreaseBalance.ResumeLayout(false);
            this.pnlIncreaseBalance.PerformLayout();
            this.pnlSMSSimulator.ResumeLayout(false);
            this.pnlSMSSimulator.PerformLayout();
            this.pnlCostPerMinute.ResumeLayout(false);
            this.pnlCostPerMinute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCostPerMinute)).EndInit();
            this.pnlPurchaseActive.ResumeLayout(false);
            this.pnlPurchaseActive.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cuentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recargaDeSaldoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valorCostoPorMinutoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel pnlCreateAccount;
        private System.Windows.Forms.Label lblCreateAccount;
        private System.Windows.Forms.Button btnAcceptCreateAccount;
        private System.Windows.Forms.Label lblPhoneNumberCreateAccount;
        private System.Windows.Forms.TextBox txtPhoneNumberCreateAccount;
        private System.Windows.Forms.Panel pnlIncreaseBalance;
        private System.Windows.Forms.Label lblBalanceToIncrease;
        private System.Windows.Forms.TextBox txtBalanceToIncrease;
        private System.Windows.Forms.Label lblIncreaseBalance;
        private System.Windows.Forms.Button btnAcceptIncrease;
        private System.Windows.Forms.Label lblPhoneNumberIncrease;
        private System.Windows.Forms.TextBox txtPhoneNumberIncrease;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlSMSSimulator;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtPurchaseMessage;
        private System.Windows.Forms.Label lblSMSSimulator;
        private System.Windows.Forms.Button btnAcceptSimulator;
        private System.Windows.Forms.TextBox txtPhoneNumberSimulator;
        private System.Windows.Forms.Label lblPhoneNumberSimulator;
        private System.Windows.Forms.Panel pnlCostPerMinute;
        private System.Windows.Forms.Label lblSetCostPerMinute;
        private System.Windows.Forms.Button btnAcceptCostPerMinute;
        private System.Windows.Forms.ToolStripMenuItem setearToolStripMenuItem;
        private System.Windows.Forms.Panel pnlPurchaseActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAcceptActivePurchase;
        private System.Windows.Forms.TextBox txtLicencePlate;
        private System.Windows.Forms.Label lblLicencePlate;
        private System.Windows.Forms.DateTimePicker dtpActivePurchase;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.NumericUpDown numCostPerMinute;
    }
}

