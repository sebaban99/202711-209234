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
using BusinessLogic.Domain;

namespace UserInterface
{
    public partial class PurchasingReport : UserControl
    {
        Parking MyParking { get; set; }
        ReportDate myReportDate;

        public PurchasingReport(Parking principalParking)
        {
            InitializeComponent();
            dtpFinishingHour.ResetText();
            dtpStartingHour.ResetText();
            lblTitleTable.Hide();
            pnlReport.Hide();
            MyParking = principalParking;
            myReportDate = new ReportDate();
        }

        private void HideAllComponents()
        {
            lblCountry.Hide();
            lblFinishingDate.Hide();
            lblFinishingHour.Hide();
            lblStartingDay.Hide();
            lblStartingHour.Hide();
            lblTitle.Hide();
            dtpFinishingDate.Hide();
            dtpFinishingHour.Hide();
            dtpStartingDate.Hide();
            dtpStartingHour.Hide();
            cbCountry.Hide();
            btnAccept.Hide();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            HideAllComponents();
            MakeReport();
            lblTitleTable.Show();
            pnlReport.Show();
        }

        private void MakeReport()
        {
            myReportDate.StartingDate = dtpStartingDate.Value;
            myReportDate.FinishingDate = dtpFinishingDate.Value;
            myReportDate.StartingHour = dtpStartingHour.Value;
            myReportDate.FinishingHour = dtpFinishingHour.Value;

            if (MyParking.IsChosenSDateEarlierThanChosenFDate(myReportDate)
                && MyParking.AreChosenHoursInParkingHourRange(myReportDate.StartingHour)
                && MyParking.AreChosenHoursInParkingHourRange(myReportDate.FinishingHour)
                && MyParking.IsChosenSHEarlierThanChosenFH(myReportDate))
            {
                var countryText = cbCountry.Text;

                if (countryText == "")
                {
                    GenerateTable("");
                }
                else
                {
                    string country = MapCountryFromOptions(countryText);
                    GenerateTable(country);
                }
            }
            else
            {
                MessageBox.Show("Error en las casillas, verifique información",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }

        }

        private string MapCountryFromOptions(string countryText)
        {
            string countryTag = "";

            if (countryText.Equals("Argentina"))
            {
                countryTag = "AR";
            }
            else if (countryText.Equals("Uruguay"))
            {
                countryTag = "UY";
            }

            return countryTag;
        }

        private void GenerateTable(string countryID)
        {
            foreach (Purchase p in MyParking.GetAllPurchases())
            {
                if (countryID.Equals("") || p.CountryTag.Equals(countryID))
                {
                    if (MyParking.IsPurchaseDateInRangeForReport(myReportDate, p.StartingHour)
                        && MyParking.ArePurchaseHoursInRangeForReport(myReportDate, p.StartingHour, p.FinishingHour))
                    {
                        AddRowOnReportTable(p);
                    }
                }
            }
        }

        private void AddRowOnReportTable(Purchase p)
        {
            dgReport.Rows.Add(p.LicensePlate, p.StartingHour.Day
                            + "/" + p.StartingHour.Month + "/" + p.StartingHour.Year,
                            p.StartingHour.ToString("HH:mm"), p.FinishingHour.ToString("HH:mm"), p.CountryTag);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
