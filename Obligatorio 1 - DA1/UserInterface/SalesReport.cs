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
            MakeReport();
            pnlReport.Show();
        }

        private void MakeReport()
        {
            var licensePlate = txtLicensePlate.Text;
            if (licensePlate != "")
            {
                try
                {
                    TryToListPurchases(licensePlate);
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
                this.Dispose();
            }
        }

        private void TryToListPurchases(string licensePlate)
        {
            if (MyParking.ActualCountry.IsLicensePlateValid(
                MyParking.ActualCountry.MessageToArray(licensePlate)))
            {
                licensePlate = MyParking.ActualCountry.FormatLicensePlate(licensePlate);
                foreach (Purchase p in MyParking.GetAllPurchases())
                {
                    if (p.LicensePlate.Equals(licensePlate))
                    {
                        dgReport.Rows.Add(p.LicensePlate, p.StartingHour.Day
                            + "/" + p.StartingHour.Month + "/" + p.StartingHour.Year,
                            p.StartingHour.ToString("HH:mm"), p.FinishingHour.ToString("HH:mm"), p.CountryTag);
                    }
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
