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
    public partial class PurchasingReport : UserControl
    {
        Parking MyParking { get; set; }
        private readonly DateTime MINIMUM_STARTING_HOUR = DateTime.Today.AddHours(10);
        private readonly DateTime MAXIMUM_HOUR = DateTime.Today.AddHours(18);


        public PurchasingReport(Parking principalParking)
        {
            InitializeComponent();
            dtpFinishingHour.ResetText();
            dtpStartingHour.ResetText();
            pnlReport.Hide();
            MyParking = principalParking;
        }

        private void HideAllComponents()
        {
            lblCountry.Hide();
            lblFinishingDate.Hide();
            lblFinishingHour.Hide();
            lblStartingDay.Hide();
            lblStartingHour.Hide();
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
            pnlReport.Show();
        }

        private void MakeReport()
        {
            var startingDate = dtpStartingDate.Value;
            var finishingDate = dtpFinishingDate.Value;
            var startingHour = dtpStartingHour.Value;
            var finishingHour = dtpFinishingHour.Value;

            if (ValidateRangeOfDays(startingDate, finishingDate)
                && ValidateHourInRange(startingHour)
                && ValidateHourInRange(finishingHour)
                && ValidateRangeOfHours(startingHour, finishingHour))
            {
                try
                {
                    var countryText = cbCountry.Text;

                    if (countryText == "")
                    {
                        MakeReportWithAllCountries();
                    }
                    else
                    {
                        //var country = GetCountryByCode(cbCountry.Text); 
                        //TODO: database
                        int countryID = 0;
                        if (countryText == "Argentina")
                        {
                            countryID = 2;
                        }
                        else
                        {
                            countryID = 1;
                        }


                        MakeReportWithACountry(countryID);
                    }
                }
                catch (BusinessException ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error en las casillas, verifique información", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }

        }

        private bool ValidateRangeOfHours(DateTime startingHour, DateTime finishingHour)
        {
            return startingHour.TimeOfDay <= finishingHour.TimeOfDay;
        }

        private bool ValidateHourInRange(DateTime hour)
        {
            return hour.TimeOfDay >= MINIMUM_STARTING_HOUR.TimeOfDay
                && hour.TimeOfDay <= MAXIMUM_HOUR.TimeOfDay;
        }

        private bool ValidateRangeOfDays(DateTime startingDate, DateTime finishingDate)
        {
            return startingDate.Date <= finishingDate.Date;
        }

        private void MakeReportWithACountry(int countryID)
        {
            var startingDate = dtpStartingDate.Value;
            var finishingDate = dtpFinishingDate.Value;
            var startingHour = dtpStartingHour.Value;
            var finishingHour = dtpFinishingHour.Value;

            foreach (Purchase p in MyParking.GetAllPurchases())
            {
                if (p.CountryID == countryID)
                {
                    if (IsInRangeOfDays(startingDate, finishingDate, p.StartingHour)
                        && IsInRangeOfHours(startingHour, finishingHour, p.StartingHour))
                    {
                        dgReport.Rows.Add(p.LicensePlate, p.StartingHour.Day
                            + "/" + p.StartingHour.Month + "/" + p.StartingHour.Year,
                            p.StartingHour.Hour, p.FinishingHour.Hour,
                            MyParking.HashIDtoCountry(p.CountryID));
                    }
                }
            }
        }

        private void MakeReportWithAllCountries()
        {
            var startingDate = dtpStartingDate.Value;
            var finishingDate = dtpFinishingDate.Value;
            var startingHour = dtpStartingHour.Value;
            var finishingHour = dtpFinishingHour.Value;

            foreach (Purchase p in MyParking.GetAllPurchases())
            {
                if (IsInRangeOfDays(startingDate, finishingDate, p.StartingHour)
                    && IsInRangeOfHours(startingHour, finishingHour, p.StartingHour))
                {
                    dgReport.Rows.Add(p.LicensePlate, p.StartingHour.Day
                        + "/" + p.StartingHour.Month + "/" + p.StartingHour.Year,
                        p.StartingHour.Hour, p.FinishingHour.Hour,
                        MyParking.HashIDtoCountry(p.CountryID));
                }
            }
        }

        private bool IsInRangeOfHours(DateTime startingHour, DateTime finishingHour, DateTime theHour)
        {
            return theHour.TimeOfDay >= startingHour.TimeOfDay
                && theHour.TimeOfDay <= finishingHour.TimeOfDay;
        }

        private bool IsInRangeOfDays(DateTime startingDate, DateTime finishingDate, DateTime theDay)
        {
            return theDay.Date >= startingDate.Date
                && theDay.Date <= finishingDate.Date;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
