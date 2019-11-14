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
    partial class SalesReport : UserControl
    {
        Parking MyParking { get; set; }

        public SalesReport(Parking principalParking)
        {
            InitializeComponent();
            pnlReport.Hide();
            MyParking = principalParking;
        }

        private void HideAllComponents()
        {
            lblLicensePlate.Hide();
            txtLicensePlate.Hide();
            btnAccept.Hide();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            HideAllComponents();
            pnlReport.Show();

            ShowReports();
            dgReport.Rows.Add("sbt4505", DateTimePicker.MinimumDateTime.Day +
                "/" + DateTimePicker.MinimumDateTime.Month + "/" +
                DateTimePicker.MinimumDateTime.Year, 10, 11, "Uruguay");

        }

        private void ShowReports()
        {
            var licensePlate = txtLicensePlate.Text;
            if (licensePlate != "")
            {
                try
                {
                    TryToListPurchases(licencePlate);
                }
                catch (BusinessException ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Campo vacío, verifique información", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TryToListPurchases(string licencePlate)
        {
            throw new NotImplementedException();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
