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
        private Timer cowBuyBlinkTimer = new Timer();

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
            DatabaseHelper.IncrementEggCount(chickenId); // 1 yumurta daha eklendi

            int eggCount = DatabaseHelper.GetEggCount(chickenId); // toplam kaç yumurta oldu

            // 2 yumurtada 1 yaş artışı kontrolü
            if (eggCount % 2 == 0)
            {
                DatabaseHelper.IncrementAnimalAge(chickenId); // yaş bir arttı
            }

            // Yeni yaşa göre ölüm kontrolü
            int age = DatabaseHelper.GetAnimalAge(chickenId);
            if (age >= 5)
            {
                DatabaseHelper.KillAnimal(chickenId); // Tavuk öldü
                MessageBox.Show("Tavuk 5 yaşına ulaştı ve öldü. Yeni tavuk almanız gerekiyor.");
                btnChickenFeed.Enabled = false;
                txtChickenAge.Text = "Yok";
                chickenBuyBlinkTimer.Start();
            }

            UpdateProductCountLabel();
            UpdateChickenAgeLabel();
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
            UpdateCowAgeLabel();
            cbCowGender.Items.Clear();
            cbCowGender.Items.Add("Dişi");
            cbCowGender.SelectedIndex = 0;
            cbCowGender.Enabled = false;

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

            cowBuyBlinkTimer.Interval = 500;
            cowBuyBlinkTimer.Tick += (sender2, args2) =>
            {
                btnCowBuy.BackColor = isBlinking ? Color.LightGreen : SystemColors.Control;
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

        private async void button6_Click(object sender, EventArgs e)
        {
            {
                int cowId = DatabaseHelper.GetAliveCowId();

                if (cowId == -1)
                {
                    MessageBox.Show("Canlı inek yok! Lütfen yeni bir inek satın alın.");
                    btnCowFeed.Enabled = false;
                    cowBuyBlinkTimer.Start();
                    return;
                }

                pbCowProduction.Value = 0;
                for (int i = 0; i <= 100; i++)
                {
                    pbCowProduction.Value = i;
                    await Task.Delay(50); // Tavuktan daha yavaş (tavuk 30 ms idi)
                }

                DatabaseHelper.AddProduct(cowId, 2); // Sütü üret
                DatabaseHelper.IncrementMilkCount(cowId); // 1 süt daha eklendi

                int milkCount = DatabaseHelper.GetMilkCount(cowId); // toplam kaç süt oldu

                // 3 süt üretiminde 1 yaş artışı kontrolü
                if (milkCount % 3 == 0)
                {
                    DatabaseHelper.IncrementAnimalAge(cowId); // yaş bir arttı
                }

                // Yeni yaşa göre ölüm kontrolü
                int age = DatabaseHelper.GetAnimalAge(cowId);
                if (age >= 15) // İnek 15 yaşında ölür diyelim
                {
                    DatabaseHelper.KillAnimal(cowId);
                    MessageBox.Show("İnek 15 yaşına ulaştı ve öldü. Yeni inek almanız gerekiyor.");
                    btnCowFeed.Enabled = false;
                    txtCowAge.Text = "Yok";
                    cowBuyBlinkTimer.Start();
                }

                UpdateCowProductCountLabel();
                UpdateCowAgeLabel();
            }
        }
        private void UpdateCowAgeLabel()
        {
            int cowId = DatabaseHelper.GetAliveCowId();
            if (cowId != -1)
            {
                int age = DatabaseHelper.GetAnimalAge(cowId);
                txtCowAge.Text = age.ToString();
            }
            else
            {
                txtCowAge.Text = "Yok";
            }
        }

        private void UpdateCowProductCountLabel()
        {
            int count = DatabaseHelper.GetUnsoldProductCount(2); // Diyelim 2 = süt
            lblCowProductCount.Text = $"Süt: {count}";
        }

        
        private void btnCowSell_Click(object sender, EventArgs e)
        {
            {
                int productTypeId = 2; // 2 = Süt (ProductTypes tablosundaki süt ID'si)
                int unsoldCount = DatabaseHelper.GetUnsoldProductCount(productTypeId);

                if (unsoldCount == 0)
                {
                    MessageBox.Show("Satılacak süt yok!");
                    return;
                }

                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Kasada {unsoldCount} süt var. Kaç litre satmak istersiniz?",
                    "Süt Sat", "1");

                if (string.IsNullOrWhiteSpace(input)) return;

                if (!int.TryParse(input, out int quantityToSell))
                {
                    MessageBox.Show("Geçerli bir sayı giriniz.");
                    return;
                }

                if (quantityToSell > unsoldCount)
                {
                    MessageBox.Show("Stokta bu kadar süt yok!");
                    return;
                }

                decimal unitPrice = 10; // Örnek birim fiyat
                int soldCount = DatabaseHelper.SellProducts(productTypeId, quantityToSell);
                decimal totalEarned = soldCount * unitPrice;

                DatabaseHelper.AddCash(totalEarned);
                UpdateCowProductCountLabel();
                UpdateCashLabel();

                MessageBox.Show($"{soldCount} litre süt satıldı. Kasaya {totalEarned:C} eklendi.");
            }

        }

        private void btnCowBuy_Click(object sender, EventArgs e)
        {
            if (DatabaseHelper.HasAnyAliveCow())
            {
                MessageBox.Show("Zaten canlı bir ineğiniz var! Önce onun ölmesini bekleyin.");
                return;
            }

            decimal cowPrice = 100;

            if (!DatabaseHelper.HasEnoughCash(cowPrice))
            {
                MessageBox.Show("Yetersiz bakiye!");
                return;
            }

            Cow cow = new Cow
            {
                Age = 1,
                Gender = "Dişi",  // BURADA SADECE DİŞİ OLACAK
                SpeciesId = 3,    // İnek türü ID'si
                Lifespan = 200
            };

            DatabaseHelper.AddAnimal(cow);
            DatabaseHelper.DeductCash(cowPrice);

            UpdateCashLabel();
            UpdateCowAgeLabel();

            MessageBox.Show("Yeni inek satın alındı!");
            //btnCowMilk.Enabled = true;

            cowBuyBlinkTimer.Stop();
            btnCowBuy.BackColor = SystemColors.Control;
        }
        private void btnSheepBuy_Click(object sender, EventArgs e)
        {
            if (DatabaseHelper.HasAnyAliveSheep())
            {
                MessageBox.Show("Zaten canlı bir koyununuz var! Önce onun ölmesini bekleyin.");
                return;
            }

            decimal sheepPrice = 80;

            if (!DatabaseHelper.HasEnoughCash(sheepPrice))
            {
                MessageBox.Show("Yetersiz bakiye!");
                return;
            }

            Sheep sheep = new Sheep
            {
                Age = 1,
                Gender = "Dişi",
                SpeciesId = 4,
                Lifespan = 150
            };

            DatabaseHelper.AddAnimal(sheep);
            DatabaseHelper.DeductCash(sheepPrice);

            UpdateCashLabel();
            UpdateSheepAgeLabel();

            MessageBox.Show("Yeni koyun satın alındı!");
            btnSheepWool.Enabled = true;

            sheepBuyBlinkTimer.Stop();
            btnSheepWool.BackColor = SystemColors.Control;
        }
        private void UpdateSheepAgeLabel()
        {
            int? sheepId = DatabaseHelper.GetAliveSheepId();
            if (sheepId.HasValue)
            {
                int age = DatabaseHelper.GetAnimalAge(sheepId.Value);
                txtSheepAge.Text = $"Koyun Yaşı: {age}";
            }
            else
            {
                txtSheepAge.Text = "Koyun Yok";
            }
        }





    }
}
