using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajOdeviIlk // Projenizin namespace'i, sizinkine göre kontrol edin
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
            // DataGridView ayarlarını burada yapabiliriz
            dataGridViewStatistics.AutoGenerateColumns = true; // Sütunları otomatik oluştur
            dataGridViewStatistics.ReadOnly = true; // Sadece okunur yap
            dataGridViewStatistics.AllowUserToAddRows = false; // Kullanıcının yeni satır eklemesini engelle
            dataGridViewStatistics.AllowUserToDeleteRows = false; // Kullanıcının satır silmesini engelle
            dataGridViewStatistics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunları dolduracak şekilde boyutlandır
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        {
        
        }
        private void StatisticsForm_Load(object sender, EventArgs e)
        { 
        
        }
        // İstatistik verisini dışarıdan almak için bir metot
        public void LoadStatistics(DataTable statisticsTable)
        {
            dataGridViewStatistics.DataSource = statisticsTable;

            // DataGridView sütun başlıklarını Türkçeleştirme
            // SQL sorgusundaki AS [AliasName] ile gelen kolon isimlerini burada kullanıyoruz
            if (dataGridViewStatistics.Columns.Contains("Animal Type"))
                dataGridViewStatistics.Columns["Animal Type"].HeaderText = "Hayvan Türü";

            if (dataGridViewStatistics.Columns.Contains("Alive Animals"))
                dataGridViewStatistics.Columns["Alive Animals"].HeaderText = "Canlı Hayvan Sayısı";

            if (dataGridViewStatistics.Columns.Contains("Dead Animals"))
                dataGridViewStatistics.Columns["Dead Animals"].HeaderText = "Ölen Hayvan Sayısı";

            if (dataGridViewStatistics.Columns.Contains("Total Eggs Produced"))
                dataGridViewStatistics.Columns["Total Eggs Produced"].HeaderText = "Toplam Üretilen Yumurta";

            if (dataGridViewStatistics.Columns.Contains("Total Milk Produced"))
                dataGridViewStatistics.Columns["Total Milk Produced"].HeaderText = "Toplam Üretilen Süt";

            if (dataGridViewStatistics.Columns.Contains("Total Wool Produced"))
                dataGridViewStatistics.Columns["Total Wool Produced"].HeaderText = "Toplam Üretilen Yün";

            if (dataGridViewStatistics.Columns.Contains("Total Feathers Produced"))
                dataGridViewStatistics.Columns["Total Feathers Produced"].HeaderText = "Toplam Üretilen Tüy";

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

            // Sütun başlıklarını otomatik boyutlandır (isteğe bağlı)
            dataGridViewStatistics.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
