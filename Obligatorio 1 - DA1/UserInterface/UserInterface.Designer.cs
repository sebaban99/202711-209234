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
            this.cambiarPaísToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uruguayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.argentinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblActiveCountry = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentasToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.valorCostoPorMinutoToolStripMenuItem,
            this.cambiarPaísToolStripMenuItem,
            this.reportesToolStripMenuItem});
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
            // cambiarPaísToolStripMenuItem
            // 
            this.cambiarPaísToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uruguayToolStripMenuItem,
            this.argentinaToolStripMenuItem});
            this.cambiarPaísToolStripMenuItem.Name = "cambiarPaísToolStripMenuItem";
            this.cambiarPaísToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.cambiarPaísToolStripMenuItem.Text = "Cambiar país";
            // 
            // uruguayToolStripMenuItem
            // 
            this.uruguayToolStripMenuItem.Name = "uruguayToolStripMenuItem";
            this.uruguayToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.uruguayToolStripMenuItem.Text = "Uruguay";
            this.uruguayToolStripMenuItem.Click += new System.EventHandler(this.UruguayToolStripMenuItem_Click);
            // 
            // argentinaToolStripMenuItem
            // 
            this.argentinaToolStripMenuItem.Name = "argentinaToolStripMenuItem";
            this.argentinaToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.argentinaToolStripMenuItem.Text = "Argentina";
            this.argentinaToolStripMenuItem.Click += new System.EventHandler(this.ArgentinaToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CompraToolStripMenuItem,
            this.ventaToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // CompraToolStripMenuItem
            // 
            this.CompraToolStripMenuItem.Name = "CompraToolStripMenuItem";
            this.CompraToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.CompraToolStripMenuItem.Text = "Compra";
            this.CompraToolStripMenuItem.Click += new System.EventHandler(this.CompraToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.ventaToolStripMenuItem.Text = "Venta";
            this.ventaToolStripMenuItem.Click += new System.EventHandler(this.VentaToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(-5, 121);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(469, 42);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "¡Bienvenido a Parking App!";
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlPrincipal.Controls.Add(this.lblWelcome);
            this.pnlPrincipal.Location = new System.Drawing.Point(174, 97);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(464, 324);
            this.pnlPrincipal.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(548, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "País actual:";
            // 
            // lblActiveCountry
            // 
            this.lblActiveCountry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblActiveCountry.AutoSize = true;
            this.lblActiveCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveCountry.Location = new System.Drawing.Point(644, 50);
            this.lblActiveCountry.Name = "lblActiveCountry";
            this.lblActiveCountry.Size = new System.Drawing.Size(69, 20);
            this.lblActiveCountry.TabIndex = 6;
            this.lblActiveCountry.Text = "Uruguay";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblActiveCountry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserInterface";
            this.Text = "ParkingApp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
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
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ToolStripMenuItem setearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarPaísToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uruguayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem argentinaToolStripMenuItem;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActiveCountry;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
    }
}

