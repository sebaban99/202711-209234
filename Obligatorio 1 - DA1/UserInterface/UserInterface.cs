using BusinessLogic;
using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Domain;
using BusinessLogic.Persistance;
using BusinessLogic.Logic;

namespace UserInterface
{
    public partial class UserInterface : Form
    {
        Parking MyParking { get; set; }

        private CostPerMinute costPerMinute;

        public UserInterface()
        {
            InitializeComponent();
            ParkingContext context = new ParkingContext();
            ParkingRepository<Purchase> purchaseRepository =
                new PurchaseRepository(context);
            ParkingRepository<Account> accountRepository =
                new AccountRepository(context);
            ParkingRepository<BusinessLogic.Domain.CostPerMinute> costRepository =
                new CostRepository(context);

            MyParking = new Parking(purchaseRepository,
                accountRepository, costRepository);

            costPerMinute = new CostPerMinute(MyParking);
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
            costPerMinute = new CostPerMinute(MyParking);
            pnlPrincipal.Controls.Add(costPerMinute);

            GoBackToWelcomeWindow();
        }

        private void ConsultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            UserControl activePurchase = new ActivePurchase(MyParking);
            pnlPrincipal.Controls.Add(activePurchase);

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
            MyParking.ActualCountry = new Argentina();
            lblActiveCountry.Text = "Argentina";
            costPerMinute.GetNumericUpDown().Value = MyParking.GetActualCost().Value;
        }

        private void UruguayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyParking.ActualCountry = new Uruguay();
            lblActiveCountry.Text = "Uruguay";
            costPerMinute.GetNumericUpDown().Value = MyParking.GetActualCost().Value;
        }
    }
}