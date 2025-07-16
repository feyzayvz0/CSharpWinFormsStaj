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
        private Timer chickenBuyBlinkTimer = new Timer();
        private bool isBlinking = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btnChickenFeed_Click(object sender, EventArgs e)
        {
            int chickenId = DatabaseHelper.GetAliveChickenId();

            if (chickenId == -1)
            {
                MessageBox.Show("Canlı tavuk yok! Lütfen yeni bir tavuk satın alın.");
                btnChickenFeed.Enabled = false;
                chickenBuyBlinkTimer.Start();
                return;
            }

            pbChickenProduction.Value = 0;
            for (int i = 0; i <= 100; i++)
            {
                pbChickenProduction.Value = i;
                await Task.Delay(30);
            }

            DatabaseHelper.AddProduct(chickenId, 1); // Yumurtayı üret

            UpdateProductCountLabel();
            UpdateChickenAgeLabel();

            if (!DatabaseHelper.HasAnyAliveChicken())
            {
                MessageBox.Show("Tavuk 6 yaşına ulaştı ve öldü. Yeni tavuk almanız gerekiyor.");
                btnChickenFeed.Enabled = false;
                txtChickenAge.Text = "Yok";
                chickenBuyBlinkTimer.Start();
            }
        }


        private void btnChickenSell_Click(object sender, EventArgs e)
        {
            int productTypeId = 1;
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
            if (DatabaseHelper.HasAnyAliveChicken())
            {
                MessageBox.Show("Zaten canlı bir tavuğunuz var! Önce onun ölmesini bekleyin.");
                return;
            }

            decimal chickenPrice = 20;

            if (!DatabaseHelper.HasEnoughCash(chickenPrice))
            {
                MessageBox.Show("Yetersiz bakiye!");
                return;
            }

            Chicken chicken = new Chicken
            {
                Age = 1,
                Gender = "Dişi",
                SpeciesId = 2,
                Lifespan = 100
            };

            DatabaseHelper.AddAnimal(chicken);
            DatabaseHelper.DeductCash(chickenPrice);

            UpdateCashLabel();
            UpdateChickenAgeLabel();

            MessageBox.Show("Yeni tavuk satın alındı!");
            btnChickenFeed.Enabled = true;

            chickenBuyBlinkTimer.Stop();
            btnChickenBuy.BackColor = SystemColors.Control;
        }

        private void UpdateProductCountLabel()
        {
            int count = DatabaseHelper.GetUnsoldProductCount(1); // 1 = Egg
            lblChickenProductCount.Text = $"Yumurta: {count}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbChickenGender.Items.Clear();
            cbChickenGender.Items.Add("Dişi");
            cbChickenGender.SelectedIndex = 0;
            cbChickenGender.Enabled = false;

            chickenBuyBlinkTimer.Interval = 500;
            chickenBuyBlinkTimer.Tick += (sender2, args2) =>
            {
                btnChickenBuy.BackColor = isBlinking ? Color.LightGreen : SystemColors.Control;
                isBlinking = !isBlinking;
            };

            if (!DatabaseHelper.HasAnyAliveChicken())
            {
                Chicken chicken = new Chicken
                {
                    Age = 1,
                    Gender = "Dişi",
                    SpeciesId = 2,
                    Lifespan = 100
                };
                DatabaseHelper.AddAnimal(chicken);
            }

            UpdateProductCountLabel();
            UpdateCashLabel();
            UpdateChickenAgeLabel();
            btnChickenFeed.Enabled = DatabaseHelper.HasAnyAliveChicken();
        }

        private void UpdateCashLabel()
        {
            decimal totalCash = DatabaseHelper.GetTotalCash();
            lblCash.Text = $"Kasa: {totalCash:C}";
        }

        private void UpdateChickenAgeLabel()
        {
            int chickenId = DatabaseHelper.GetAliveChickenId();
            if (chickenId != -1)
            {
                int age = DatabaseHelper.GetAnimalAge(chickenId);
                txtChickenAge.Text = age.ToString();
            }
            else
            {
                txtChickenAge.Text = "Yok";
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
