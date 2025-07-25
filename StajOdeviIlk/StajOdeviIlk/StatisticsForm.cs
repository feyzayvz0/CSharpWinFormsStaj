using StajOdeviIlk.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajOdeviIlk 
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
            dataGridViewStatistics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunları dolduracak şekilde boyutlandır
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        {
        
        }
        private void StatisticsForm_Load(object sender, EventArgs e)
        { 
        
        }
       
        public void LoadStatistics(DataTable statisticsTable)
        {
         
            dataGridViewStatistics.DataSource = statisticsTable;


            if (dataGridViewStatistics.Columns.Contains("Animal Type"))
                dataGridViewStatistics.Columns["Animal Type"].HeaderText = "Hayvan Türü";

            if (dataGridViewStatistics.Columns.Contains("Dead Animals"))
                dataGridViewStatistics.Columns["Dead Animals"].HeaderText = "Ölen Hayvan Sayısı";

         
            if (dataGridViewStatistics.Columns.Contains("Eggs In Stock"))
                dataGridViewStatistics.Columns["Eggs In Stock"].HeaderText = "Yumurta Stoğu";

            if (dataGridViewStatistics.Columns.Contains("Eggs Sold"))
                dataGridViewStatistics.Columns["Eggs Sold"].HeaderText = "Satılan Yumurta";

            if (dataGridViewStatistics.Columns.Contains("Milk In Stock"))
                dataGridViewStatistics.Columns["Milk In Stock"].HeaderText = "Süt Stoğu";

            if (dataGridViewStatistics.Columns.Contains("Milk Sold"))
                dataGridViewStatistics.Columns["Milk Sold"].HeaderText = "Satılan Süt";

            if (dataGridViewStatistics.Columns.Contains("Wool In Stock"))
                dataGridViewStatistics.Columns["Wool In Stock"].HeaderText = "Yün Stoğu";

            if (dataGridViewStatistics.Columns.Contains("Wool Sold"))
                dataGridViewStatistics.Columns["Wool Sold"].HeaderText = "Satılan Yün";

            if (dataGridViewStatistics.Columns.Contains("Feathers In Stock"))
                dataGridViewStatistics.Columns["Feathers In Stock"].HeaderText = "Tüy Stoğu";

            if (dataGridViewStatistics.Columns.Contains("Feathers Sold"))
                dataGridViewStatistics.Columns["Feathers Sold"].HeaderText = "Satılan Tüy";

            if (dataGridViewStatistics.Columns.Contains("Total Earned Cash"))
                dataGridViewStatistics.Columns["Total Earned Cash"].HeaderText = "Kazanılan Toplam Para";

          
            dataGridViewStatistics.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }



    }
}
