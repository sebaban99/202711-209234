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

namespace UserInterface
{
    public partial class PurchasingReport : UserControl
    {
        Parking MyParking { get; set; }

        public PurchasingReport(Parking principalParking)
        {
            InitializeComponent();
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
            pnlReport.Show();

            dgReport.Rows.Add("sbt4505", DateTimePicker.MinimumDateTime.Day +
                "/" + DateTimePicker.MinimumDateTime.Month + "/" +
                DateTimePicker.MinimumDateTime.Year, 10, 11, "Uruguay");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
