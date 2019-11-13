﻿using System;
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
    public partial class PurchaseActive : UserControl
    {
        Parking MyParking { get; set; }

        public PurchaseActive(Parking principalParking)
        {
            InitializeComponent();
            InitializateTabsSecuence();
            MyParking = principalParking;
        }

        private void CleanFields()
        {
            txtLicencePlate.Text = "";
        }

        private void InitializateTabsSecuence()
        {
            txtLicencePlate.TabIndex = 1;
            dtpActivePurchase.TabIndex = 2;
            btnAcceptActivePurchase.TabIndex = 3;
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

            CleanFields();
            this.Hide();
        }
    }
}
