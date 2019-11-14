using BusinessLogic;
using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class UserInterface : Form
    {
        Parking MyParking { get; set; }

        public UserInterface()
        {
            InitializeComponent();
    
            MyParking = new Parking();
        }
        
        private void GoBackToWelcomeWindow()
        {
            pnlPrincipal.Controls.Add(lblWelcome);
        }

        private void CrearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            UserControl createAccount = new CreateAccount(MyParking);
            pnlPrincipal.Controls.Add(createAccount);

            GoBackToWelcomeWindow();
        }

        private void RecargaDeSaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            UserControl increaseBalance = new IncreaseBalance(MyParking);
            pnlPrincipal.Controls.Add(increaseBalance);

            GoBackToWelcomeWindow();
        }

        private void SimularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            UserControl smsSimulator = new SMSSimulator(MyParking);
            pnlPrincipal.Controls.Add(smsSimulator);

            GoBackToWelcomeWindow();
        }

        private void SetearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            UserControl costPerMinute = new CostPerMinute(MyParking);
            pnlPrincipal.Controls.Add(costPerMinute);

            GoBackToWelcomeWindow();
        }

        private void ConsultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            UserControl purchaseActive = new PurchaseActive(MyParking);
            pnlPrincipal.Controls.Add(purchaseActive);

            GoBackToWelcomeWindow();
        }


        private void CompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            UserControl purchaseReport = new PurchasingReport(MyParking);
            pnlPrincipal.Controls.Add(purchaseReport);

            GoBackToWelcomeWindow();
        }

        private void VentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            UserControl salesReport = new SalesReport(MyParking);
            pnlPrincipal.Controls.Add(salesReport);

            GoBackToWelcomeWindow();

        }

        private void ArgentinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyParking.ActiveCountry = new Argentina();
            lblActiveCountry.Text = "Argentina";
        }

        private void UruguayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyParking.ActiveCountry = new Uruguay();
            lblActiveCountry.Text = "Uruguay";
        }
   }
}