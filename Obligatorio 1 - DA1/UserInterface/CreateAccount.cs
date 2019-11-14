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
    public partial class CreateAccount : UserControl
    {
        Parking MyParking { get; set; }

        public CreateAccount(Parking activeParking)
        {
            InitializeComponent();
            InitializateTabsSecuence();
            MyParking = activeParking;
        }

        private void CleanFields()
        {
            txtPhoneNumberCreateAccount.Text = "";
        }

        private void InitializateTabsSecuence()
        {
            txtPhoneNumberCreateAccount.TabIndex = 1;
            btnAcceptCreateAccount.TabIndex = 2;
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
            if (MyParking.ActualCountry.IsPhoneNumberValid(phoneNumber))
            {
                Account newAccount = new Account()
                {
                    Phone = MyParking.ActualCountry.FormatPhoneNumber(phoneNumber)
                };

                if (!MyParking.IsAccountAlreadyRegistered(newAccount.Phone))
                {
                    MyParking.AddAccount(newAccount);
                }

                MessageBox.Show("Cuenta creada correctamente", "Contacto nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CleanFields();
                this.Hide();
            }
        }
    }
}
