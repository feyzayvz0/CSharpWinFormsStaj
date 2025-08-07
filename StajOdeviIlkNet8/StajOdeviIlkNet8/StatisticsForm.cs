
using StajOdeviIlkNet8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajOdeviIlkNet8 
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();

            dataGridViewStatistics.AutoGenerateColumns = true;
            dataGridViewStatistics.ReadOnly = true;
            dataGridViewStatistics.AllowUserToAddRows = false;
            dataGridViewStatistics.AllowUserToDeleteRows = false;
            dataGridViewStatistics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void StatisticsForm_Load(object sender, EventArgs e)
        {

        }

        public void LoadStatistics(List<StatisticsViewModel> statisticsList)
        {
            dataGridViewStatistics.DataSource = statisticsList;


            if (dataGridViewStatistics.Columns["AnimalType"] != null)
                dataGridViewStatistics.Columns["AnimalType"].HeaderText = "Hayvan Türü";

            if (dataGridViewStatistics.Columns["DeadAnimals"] != null)
                dataGridViewStatistics.Columns["DeadAnimals"].HeaderText = "Ölen Hayvan Sayısı";

            if (dataGridViewStatistics.Columns["EggsInStock"] != null)
                dataGridViewStatistics.Columns["EggsInStock"].HeaderText = "Yumurta Stoğu";

            if (dataGridViewStatistics.Columns["EggsSold"] != null)
                dataGridViewStatistics.Columns["EggsSold"].HeaderText = "Satılan Yumurta";

            if (dataGridViewStatistics.Columns["MilkInStock"] != null)
                dataGridViewStatistics.Columns["MilkInStock"].HeaderText = "Süt Stoğu";

            if (dataGridViewStatistics.Columns["MilkSold"] != null)
                dataGridViewStatistics.Columns["MilkSold"].HeaderText = "Satılan Süt";

            if (dataGridViewStatistics.Columns["WoolInStock"] != null)
                dataGridViewStatistics.Columns["WoolInStock"].HeaderText = "Yün Stoğu";

            if (dataGridViewStatistics.Columns["WoolSold"] != null)
                dataGridViewStatistics.Columns["WoolSold"].HeaderText = "Satılan Yün";

            if (dataGridViewStatistics.Columns["FeathersInStock"] != null)
                dataGridViewStatistics.Columns["FeathersInStock"].HeaderText = "Tüy Stoğu";

            if (dataGridViewStatistics.Columns["FeathersSold"] != null)
                dataGridViewStatistics.Columns["FeathersSold"].HeaderText = "Satılan Tüy";

            if (dataGridViewStatistics.Columns["TotalEarnedCash"] != null)
                dataGridViewStatistics.Columns["TotalEarnedCash"].HeaderText = "Kazanılan Toplam Para";

            dataGridViewStatistics.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewStatistics_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
