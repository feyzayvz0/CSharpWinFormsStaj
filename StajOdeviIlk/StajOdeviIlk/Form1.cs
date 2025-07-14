using StajOdeviIlk.Helpers;
using StajOdeviIlk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajOdeviIlk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btnChickenFeed_Click(object sender, EventArgs e)
        {
            pbChickenProduction.Value = 0;
            btnChickenFeed.Enabled = false;

            for (int i = 0; i <= 100; i++)
            {
                pbChickenProduction.Value = i;
                await Task.Delay(30);
            }

            int chickenId = DatabaseHelper.GetAliveChickenId();
            if (chickenId == -1)
            {
                MessageBox.Show("Canlı tavuk bulunamadı!");
                return;
            }

            DatabaseHelper.AddProduct(chickenId, 1); // 1 = Egg
            UpdateProductCountLabel();
            

            btnChickenFeed.Enabled = true;
        }
        private void btnChickenSell_Click(object sender, EventArgs e)
        {
            int productTypeId = 1; // Yumurtanın tipi
            int unsoldCount = DatabaseHelper.GetUnsoldProductCount(productTypeId);

            if (unsoldCount == 0)
            {
                MessageBox.Show("Satılacak yumurta yok!");
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Kasada {unsoldCount} yumurta var. Kaç tane satmak istersiniz?",
                "Yumurta Sat", "1");

            if (string.IsNullOrWhiteSpace(input)) return;

            if (!int.TryParse(input, out int quantityToSell))
            {
                MessageBox.Show("Geçerli bir sayı giriniz.");
                return;
            }

            if (quantityToSell > unsoldCount)
            {
                MessageBox.Show("Stokta bu kadar yumurta yok!");
                return;
            }

            decimal unitPrice = 5;
            int soldCount = DatabaseHelper.SellProducts(productTypeId, quantityToSell);
            decimal totalEarned = soldCount * unitPrice;

            DatabaseHelper.AddCash(totalEarned);
            UpdateProductCountLabel();
            UpdateCashLabel();

            MessageBox.Show($"{soldCount} yumurta satıldı. Kasaya {totalEarned:C} eklendi.");
        }

        private void btnChickenBuy_Click(object sender, EventArgs e)
        {
            decimal chickenPrice = 20;

            if (!DatabaseHelper.HasEnoughCash(chickenPrice))
            {
                MessageBox.Show("Yetersiz bakiye!");
                return;
            }

            // Yeni tavuk oluştur
            Chicken chicken = new Chicken
            {
                Age = (int)nudChickenAge.Value,
                Gender = cbChickenGender.SelectedItem.ToString(),
                SpeciesId = 2, // Tavuk türü ID'si (veritabanındaki sıra)
                Lifespan = 100 // örnek yaşam süresi
            };

            DatabaseHelper.AddAnimal(chicken);
            DatabaseHelper.DeductCash(chickenPrice);
            MessageBox.Show("Yeni tavuk satın alındı!");
        }
        private void UpdateProductCountLabel()
        {
            int count = DatabaseHelper.GetUnsoldProductCount(1); // 1 = Egg
            lblChickenProductCount.Text = $"Yumurta: {count}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbChickenGender.Items.Clear();               // Önce varsa temizle
            cbChickenGender.Items.Add("Dişi");           // Sadece Dişi ekle
            cbChickenGender.SelectedIndex = 0;           // Otomatik seçili olsun
            cbChickenGender.Enabled = false;

            if (!DatabaseHelper.HasAnyAliveChicken())
            {
                Chicken chicken = new Chicken
                {
                    Age = 1,
                    Gender = "Dişi",
                    SpeciesId = 2, // Tavuk ID
                    Lifespan = 100
                };

                DatabaseHelper.AddAnimal(chicken);
            }

            UpdateProductCountLabel(); // varsa ürünleri yaz
            cbChickenGender.Enabled = false;
        }
        private void UpdateCashLabel()
        {
            decimal totalCash = DatabaseHelper.GetTotalCash();
            lblCash.Text = $"Kasa: {totalCash:C}";
        }

        public static decimal GetTotalCash()
        {
            using (var conn = DatabaseHelper.GetConnection()) // << düzeltme burada
            {
                conn.Open();
                string query = "SELECT ISNULL(SUM(Amount), 0) FROM CashRegister";

                using (var cmd = new SqlCommand(query, conn))
                {
                    return (decimal)cmd.ExecuteScalar();
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void chickenPrice_Click(object sender, EventArgs e)
        {

        }
    }
}
