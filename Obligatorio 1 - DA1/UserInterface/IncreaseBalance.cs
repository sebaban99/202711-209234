using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace UserInterface
{
    public partial class IncreaseBalance : UserControl
    {
        Parking MyParking { get; set; }

        public IncreaseBalance(Parking principalParking)
        {
            InitializeComponent();
            InitializateTabsSecuence();
            MyParking = principalParking;
        }

        private void CleanFields()
        {
            txtPhoneNumberIncrease.Text = "";
            txtBalanceToIncrease.Text = "";
        }

        private void InitializateTabsSecuence()
        {
            txtPhoneNumberIncrease.TabIndex = 1;
            txtBalanceToIncrease.TabIndex = 2;
            btnAcceptIncrease.TabIndex = 3;
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

            CleanFields();
            this.Hide();
        }
    }
}
