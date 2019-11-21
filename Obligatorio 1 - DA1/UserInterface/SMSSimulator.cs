using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Domain;
using BusinessLogic.Logic;
using BusinessLogic.Exceptions;

namespace UserInterface
{
    public partial class SMSSimulator : UserControl
    {
        Parking MyParking { get; set; }

        public SMSSimulator(Parking activeParking)
        {
            InitializeComponent();
            InitializateTabsSecuence();
            MyParking = activeParking;
        }

        private void InitializateTabsSecuence()
        {
            txtPhoneNumberSimulator.TabIndex = 1;
            txtPurchaseMessage.TabIndex = 2;
            btnAcceptSimulator.TabIndex = 3;
        }

        private void CleanFields()
        {
            txtPhoneNumberSimulator.Text = "";
            txtPurchaseMessage.Text = "";
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
                catch(DatabaseException ex)
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
            if (MyParking.ActualCountry.IsPhoneNumberValid(phoneNumber) &&
                MyParking.ActualCountry.IsMessageValid(purchaseMessage))
            {
                phoneNumber =
                    MyParking.ActualCountry.FormatPhoneNumber(phoneNumber);
                Purchase newPurchase = new Purchase()
                {
                    StartingHour =
                    MyParking.ActualCountry.ExtractStartingHour(purchaseMessage),
                    FinishingHour =
                    MyParking.ActualCountry.ExtractFinishingHour(purchaseMessage),
                    AmountOfMinutes =
                    MyParking.ActualCountry.ExtractMinutes(purchaseMessage),
                    CountryTag =
                    MyParking.ActualCountry.GetCountryTag(),
                    LicensePlate =
                    MyParking.ActualCountry.ExtractLicensePlate(purchaseMessage)
                };

                MyParking.MakePurchase(phoneNumber, newPurchase);
            }

            MessageBox.Show("Compra realizada con éxito", "Compra",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            CleanFields();
            this.Hide();
        }
    }
}
