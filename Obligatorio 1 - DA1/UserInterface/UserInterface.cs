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
            CleanWindow();
            lblWelcome.Show();
            InitializateTabsSecuence();

            MyParking = new Parking();
        }

        private void CleanWindow()
        {
            CleanAllTextBox();
            HideAllPanels();
        }

        private void CleanAllTextBox()
        {
            txtBalanceToIncrease.Text = "";
            txtLicencePlate.Text = "";
            txtPhoneNumberCreateAccount.Text = "";
            txtPhoneNumberIncrease.Text = "";
            txtPhoneNumberSimulator.Text = "";
            txtPurchaseMessage.Text = "";
        }

        private void HideAllPanels()
        {
            lblWelcome.Hide();
            pnlCreateAccount.Hide();
            pnlIncreaseBalance.Hide();
            pnlSMSSimulator.Hide();
            pnlCostPerMinute.Hide();
            pnlPurchaseActive.Hide();
        }

        private void GoBackToWelcomeWindow()
        {
            CleanWindow();
            lblWelcome.Show();
        }

        private void InitializateTabsSecuence()
        {
            InitializateTabsSecuence_CreateAccount();
            InitializateTabsSecuence_IncreaseBalance();
            InitializateTabsSecuence_SMSSimulator();
            InitializateTabsSecuence_ActivePurchase();
            InitializateTabsSecuence_SetCostPerMinute();
        }

        private void InitializateTabsSecuence_CreateAccount()
        {
            txtPhoneNumberCreateAccount.TabIndex = 1;
            btnAcceptCreateAccount.TabIndex = 2;
        }

        private void InitializateTabsSecuence_IncreaseBalance()
        {
            txtPhoneNumberIncrease.TabIndex = 1;
            txtBalanceToIncrease.TabIndex = 2;
            btnAcceptIncrease.TabIndex = 3;
        }

        private void InitializateTabsSecuence_SMSSimulator()
        {
            txtPhoneNumberSimulator.TabIndex = 1;
            txtPurchaseMessage.TabIndex = 2;
            btnAcceptSimulator.TabIndex = 3;
        }

        private void InitializateTabsSecuence_ActivePurchase()
        {
            txtLicencePlate.TabIndex = 1;
            dtpActivePurchase.TabIndex = 2;
            btnAcceptActivePurchase.TabIndex = 3;
        }

        private void InitializateTabsSecuence_SetCostPerMinute()
        {
            numCostPerMinute.TabIndex = 1;
            btnAcceptCostPerMinute.TabIndex = 2;
        }

        private void CrearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanWindow();
            pnlCreateAccount.Show();
        }

        private void RecargaDeSaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanWindow();
            pnlIncreaseBalance.Show();
        }

        private void SimularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanWindow();
            pnlSMSSimulator.Show();
        }

        private void SetearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanWindow();
            pnlCostPerMinute.Show();
        }

        private void ConsultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanWindow();
            pnlPurchaseActive.Show();
        }

        private void BtnAcceptCreateAccount_Click(object sender, EventArgs e)
        {
            var phoneNumber = txtPhoneNumberCreateAccount.Text;
            if (phoneNumber != "")
            {
                try
                {
                    TryToCreateAnAccount(phoneNumber);
                }
                catch (BusinessException ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Campo vacío. Debe ingresar un teléfono.", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TryToCreateAnAccount(string phoneNumber)
        {
            if (MyParking.IsNumberPhoneValid(phoneNumber))
            {
                Account newAccount = new Account()
                {
                    Phone = MyParking.FormatPhoneNumber(phoneNumber)
                };

                if (!MyParking.IsAccountAlreadyRegistered(newAccount.Phone))
                {
                    MyParking.AddAccount(newAccount);
                }

                MessageBox.Show("Cuenta creada correctamente", "Contacto nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                GoBackToWelcomeWindow();
            }
        }

        private void BtnAcceptIncrease_Click(object sender, EventArgs e)
        {
            var phoneNumber = txtPhoneNumberIncrease.Text;
            var balanceToIncrease = txtBalanceToIncrease.Text;
            if (phoneNumber != "" && balanceToIncrease != "")
            {
                try
                {
                    TryToIncreaseBalance(phoneNumber, balanceToIncrease);
                }
                catch (BusinessException ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Campo/s vacío/s, verifique información", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TryToIncreaseBalance(string phoneNumber, string balanceToIncrease)
        {
            if (MyParking.IsNumberPhoneValid(phoneNumber))
            {
                phoneNumber = MyParking.FormatPhoneNumber(phoneNumber);
                Account newAccount = MyParking.RetrieveAccount(phoneNumber);
                newAccount.IncreaseBalance(Int32.Parse(balanceToIncrease));
            }

            MessageBox.Show("Saldo agregado correctamente", "Saldo agregado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            GoBackToWelcomeWindow();
        }

        private void BtnAcceptSimulator_Click(object sender, EventArgs e)
        {
            var phoneNumber = txtPhoneNumberSimulator.Text;
            var purchaseMessage = txtPurchaseMessage.Text;
            if (phoneNumber != "" && purchaseMessage != "")
            {
                try
                {
                    TryToMakeAPurchase(phoneNumber, purchaseMessage);
                }
                catch (BusinessException ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Campo/s vacío/s, verifique información", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TryToMakeAPurchase(string phoneNumber, string purchaseMessage)
        {
            if (MyParking.IsNumberPhoneValid(phoneNumber))
            {
                phoneNumber = MyParking.FormatPhoneNumber(phoneNumber);
                Purchase newPurchase = new Purchase();
                newPurchase.SetPurchaseProperties(purchaseMessage);

                MyParking.MakePurchase(phoneNumber, newPurchase);
            }

            MessageBox.Show("Compra realizada con éxito", "Compra",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            GoBackToWelcomeWindow();
        }

        private void BtnAcceptActivePurchase_Click(object sender, EventArgs e)
        {
            var licencePlate = txtLicencePlate.Text;
            DateTime dateTimeChosen = dtpActivePurchase.Value;
            if (licencePlate != "")
            {
                try
                {
                    TryToProveIfAPurchaseIsActive(licencePlate, dateTimeChosen);
                }
                catch (BusinessException ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Campo/s vacío/s, verifique información", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TryToProveIfAPurchaseIsActive(string licencePlate, DateTime dateTimeChosen)
        {
            if (MyParking.IsPurchaseActive(licencePlate, dateTimeChosen))
            {
                MessageBox.Show("Existe compra activa", "Cuenta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No existe compra activa", "Cuenta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            GoBackToWelcomeWindow();
        }

        private void BtnAcceptCostPerMinute_Click(object sender, EventArgs e)
        {
            int newCostPerMinute = Convert.ToInt32(
                Math.Round(numCostPerMinute.Value, 0));

            MyParking.CostPerMinute = newCostPerMinute;
            MessageBox.Show("Costo seteado con éxito", "Parking",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            GoBackToWelcomeWindow();
        }
    }
}