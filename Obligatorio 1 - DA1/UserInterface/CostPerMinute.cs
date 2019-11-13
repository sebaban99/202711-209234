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
    public partial class CostPerMinute : UserControl
    {
        Parking MyParking { get; set; }

        public CostPerMinute(Parking principalParking)
        {
            InitializeComponent();
            MyParking = principalParking;
            InitializateTabsSecuence();
        }

        private void InitializateTabsSecuence()
        {
            numCostPerMinute.TabIndex = 1;
            btnAcceptCostPerMinute.TabIndex = 2;
        }

        private void BtnAcceptCostPerMinute_Click(object sender, EventArgs e)
        {
            int newCostPerMinute = Convert.ToInt32(
                Math.Round(numCostPerMinute.Value, 0));

            MyParking.CostPerMinute = newCostPerMinute;
            MessageBox.Show("Costo seteado con éxito", "Parking",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
        }
    }
}
