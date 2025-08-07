using StajOdeviIlkNet8.Controllers;
using StajOdeviIlkNet8.Models;
using StajOdeviIlkNet8.Repositories;
using StajOdeviIlkNet8.Repository;
using StajOdeviIlkNet8.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StajOdeviIlkNet8
{
    public partial class Form1 : Form
    {
        private readonly FarmController _farmController;
        private readonly System.Windows.Forms.Timer chickenBuyBlinkTimer = new();
        private readonly System.Windows.Forms.Timer cowBuyBlinkTimer = new();
        private readonly System.Windows.Forms.Timer sheepBuyBlinkTimer = new();
        private readonly System.Windows.Forms.Timer gooseBuyBlinkTimer = new();

        private bool isBlinking = false;
        private readonly StatisticsRepository _statisticsRepository;


        
        private Point btnChickenFeedOriginalLocation;
        private Point btnCowFeedOriginalLocation;
        private Point btnSheepWoolOriginalLocation;
        private Point btnGooseFeedOriginalLocation;

        public Form1()
        {
            InitializeComponent();

            var dbContext = new FarmDbContext();

            var animalRepo = new AnimalRepository(dbContext);
            var productRepo = new ProductRepository(dbContext);
            var cashRepo = new CashRepository(dbContext);
            var chickenRepo = new ChickenRepository(dbContext);
            var chickenService = new ChickenService(chickenRepo, productRepo, cashRepo);

            var cowRepo = new CowRepository(dbContext);
            var cowService = new CowService(cowRepo, productRepo, cashRepo);

            var sheepRepo = new SheepRepository(dbContext);
            var sheepService = new SheepService(sheepRepo, productRepo, cashRepo);

            var gooseRepo = new GooseRepository(dbContext);
            var gooseService = new GooseService(gooseRepo, productRepo, cashRepo);

            var statisticsRepository = new StatisticsRepository(dbContext);
            _statisticsRepository = statisticsRepository; 




            _farmController = new FarmController(
          chickenService,
          cowService,
          sheepService,
          gooseService
      );

            btnChickenFeed.MouseDown += btnChickenFeed_MouseDown;
            btnChickenFeed.MouseUp += btnChickenFeed_MouseUp;

            InitializeSheepGenderComboBox();
            InitializeGooseGenderComboBox();

           
            LoadSheepInfo();
            LoadGooseInfo();
            UpdateCashLabel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSheepInfo();
            LoadGooseInfo();

            btnChickenFeedOriginalLocation = btnChickenFeed.Location;
            btnCowFeedOriginalLocation = btnCowFeed.Location;
            btnSheepWoolOriginalLocation = btnSheepWool.Location;
            btnGooseFeedOriginalLocation = btnGooseFeed.Location;

          
            pictureBox1.Image = Properties.Resources.tvk;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Properties.Resources.inek;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = Properties.Resources.koyun;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Image = Properties.Resources.kaz;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

            UpdateGooseAgeLabel();
            UpdateCowProductCountLabel();
            LoadSheepInfo();
            UpdateCowAgeLabel();

            cbCowGender.Items.Clear();
            cbCowGender.Items.Add("Dişi");
            cbCowGender.SelectedIndex = 0;
            cbCowGender.Enabled = false;

            cbChickenGender.Items.Clear();
            cbChickenGender.Items.Add("Dişi");
            cbChickenGender.SelectedIndex = 0;
            cbChickenGender.Enabled = false;

          
            int? sheepId = _farmController.GetAliveSheepId();
            if (sheepId.HasValue)
            {
                int age = _farmController.GetSheepAgeById(sheepId.Value);
                string? gender = _farmController.GetSheepGenderById(sheepId.Value);
                if (!string.IsNullOrEmpty(gender))
                {
                    int index = cbSheepGender.Items.IndexOf(gender);
                    if (index >= 0)
                        cbSheepGender.SelectedIndex = index;
                }
            }

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

            sheepBuyBlinkTimer.Interval = 500;
            sheepBuyBlinkTimer.Tick += (sender3, args3) =>
            {
                btnSheepBuy.BackColor = isBlinking ? Color.LightGreen : SystemColors.Control;
                isBlinking = !isBlinking;
            };

            gooseBuyBlinkTimer.Interval = 500;
            gooseBuyBlinkTimer.Tick += (sender3, args3) =>
            {
                btnGooseBuy.BackColor = isBlinking ? Color.LightGreen : SystemColors.Control;
                isBlinking = !isBlinking;
            };

            btnSheepSell.Enabled = _farmController.HasAnyAliveSheep();





            

            UpdateProductCountLabel();
            UpdateCashLabel();
            UpdateChickenAgeLabel();

            btnChickenFeed.Enabled = _farmController.HasAnyAliveChicken();
        }
    
        private void Label2_Click(object sender, EventArgs e)
        {

        }
        private async void btnChickenFeed_Click(object sender, EventArgs e)
        {
           
            btnChickenFeed.Enabled = false;

            if (!_farmController.HasAliveChicken())
            {
                MessageBox.Show("Canlı tavuk yok!! Lütfen yeni bir tavuk satın alın.");
                chickenBuyBlinkTimer.Start();
                return;
            }

            pbChickenProduction.Value = 0;
            for (int i = 0; i <= 100; i++)
            {
                pbChickenProduction.Value = i;
                await Task.Delay(30);
            }

            bool alive = _farmController.FeedChicken();

            if (!alive)
            {
                MessageBox.Show("Tavuk 5 yaşına ulaştı ve öldü. Yeni tavuk almanız gerekiyor...");
                txtChickenAge.Text = "Yok";
                chickenBuyBlinkTimer.Start();
            }

            UpdateChickenProductCountLabel();
            UpdateChickenAgeLabel();

            
            btnChickenFeed.Enabled = _farmController.HasAliveChicken();
        }

        private void btnChickenSell_Click(object sender, EventArgs e)
        {
            int unsoldCount = _farmController.GetUnsoldEggCount();

            if (unsoldCount == 0)
            {
                MessageBox.Show("Satılacak yumurta yok!");
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Depoda {unsoldCount} yumurta var. Kaç tane satmak istersiniz?",
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

            try
            {
                int sold = _farmController.SellEggs(quantityToSell, unitPrice);
                decimal totalEarned = sold * unitPrice;

                UpdateChickenProductCountLabel();
                UpdateChickenCashLabel();

                MessageBox.Show($"{sold} yumurta satıldı. Kasaya {totalEarned:C} eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void btnChickenBuy_Click(object sender, EventArgs e)
        {
            if (_farmController.HasAliveChicken())
            {
                MessageBox.Show("Zaten canlı bir tavuğunuz var! Yeni bir tavuk satın alamazsınız.");
                return;
            }

            decimal chickenPrice = 20;

            if (_farmController.GetChickenCash() < chickenPrice)
            {
                MessageBox.Show("Yetersiz bakiye!");
                return;
            }

            try
            {
                _farmController.BuyChicken(chickenPrice);

                UpdateChickenCashLabel();
                UpdateChickenAgeLabel();

                MessageBox.Show("Yeni tavuk satın alındı!");
                btnChickenFeed.Enabled = true;

                chickenBuyBlinkTimer.Stop();
                btnChickenBuy.BackColor = SystemColors.Control;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void UpdateChickenProductCountLabel()
        {
            int count = _farmController.GetUnsoldEggCount();
            lblChickenProductCount.Text = $"Yumurta: {count}";
        }

        private void UpdateChickenCashLabel()
        {
            decimal cash = _farmController.GetChickenCash();
            lblCash.Text = $"Kasa: {cash:C}";
        }
        private void UpdateCashLabel()
        {
            decimal totalCash = _farmController.GetCash();
            lblCash.Text = $"Kasa: {totalCash:C}";
        }
        private void UpdateProductCountLabel()
        {
            int count = _farmController.GetChickenUnsoldProductCount();
            lblChickenProductCount.Text = $"Yumurta: {count}";
        }
        private void UpdateChickenAgeLabel()
        {
            int age = _farmController.GetChickenAge();
            txtChickenAge.Text = age > 0 ? age.ToString() : "Tavuk Yok";
            btnChickenFeed.Enabled = age > 0;
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
            btnCowFeed.Enabled = false;

            if (!_farmController.HasAliveCow())
            {
                MessageBox.Show("Canlı inek yok!");
                return;
            }

            pbCowProduction.Value = 0;
            for (int i = 0; i <= 100; i++)
            {
                pbCowProduction.Value = i;
                await Task.Delay(30);
            }

            bool alive = _farmController.FeedCow();

            int age = _farmController.GetCowAge();
            txtCowAge.Text = alive ? age.ToString() : "İnek Yok";

            if (!alive)
            {
                MessageBox.Show("İnek yaşlandı ve öldü. Yeni inek almalısınız.");
            }

            UpdateCowProductCountLabel();

           
            btnCowFeed.Enabled = _farmController.HasAliveCow();
        }


        private void UpdateCowAgeLabel()
        {
            int age = _farmController.GetCowAge();
            txtCowAge.Text = age > 0 ? age.ToString() : "İnek Yok";
            btnCowFeed.Enabled = age > 0;
        }


        private void UpdateCowProductCountLabel()
        {
            int count = _farmController.GetUnsoldMilkCount();
            lblCowProductCount.Text = $"Süt: {count}";
        }

        private void btnCowSell_Click(object sender, EventArgs e)
        {
            int unsoldCount = _farmController.GetUnsoldMilkCount();
            if (unsoldCount == 0)
            {
                MessageBox.Show("Satılacak süt yok!");
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Depoda {unsoldCount} süt var. Kaç tane satmak istersiniz?",
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

            decimal unitPrice = 10; 
            int soldCount = _farmController.SellMilk(quantityToSell, unitPrice);
            decimal totalEarned = soldCount * unitPrice;

            UpdateCowProductCountLabel();
            UpdateCowCashLabel(); 

            MessageBox.Show($"{soldCount} süt satıldı. Kasaya {totalEarned:C} eklendi.");
        }

        private void btnCowBuy_Click(object sender, EventArgs e)
        {
            if (_farmController.HasAliveCow())
            {
                MessageBox.Show("Zaten canlı bir ineğiniz var! Yeni bir inek satın alamazsınız.");
                return;
            }

            decimal cowPrice = 300;
            string? gender = cbCowGender.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Lütfen cinsiyet seçin.");
                return;
            }

           
            if (_farmController.GetCowCash() < cowPrice)
            {
                MessageBox.Show("Yetersiz bakiye!");
                return;
            }

            try
            {
                _farmController.BuyCow(gender, cowPrice);
                MessageBox.Show("Yeni inek satın alındı!");
                UpdateCowAgeLabel();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void UpdateCowCashLabel()
        {
            decimal cash = _farmController.GetCowCash();
            lblCash.Text = $"Kasa: {cash:C}";
        }

        private void btnSheepBuy_Click(object sender, EventArgs e)
        {
            if (_farmController.HasAliveSheep())
            {
                MessageBox.Show("Zaten canlı bir koyununuz var. Yeni bir koyun satın alamazsınız.");
                sheepBuyBlinkTimer.Stop();
                btnSheepBuy.BackColor = SystemColors.Control;
                LoadSheepInfo();
                return;
            }

            var selectedItem = cbSheepGender.SelectedItem;
            string? selectedGender = selectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedGender) || selectedGender == "Seçiniz")
            {
                MessageBox.Show("Lütfen koyunun cinsiyetini seçin.");
                return;
            }


            decimal sheepPrice = 80;

            try
            {
                _farmController.BuySheep(selectedGender, sheepPrice);

                sheepBuyBlinkTimer.Stop();
                btnSheepBuy.BackColor = SystemColors.Control;

                MessageBox.Show("Yeni koyun başarıyla satın alındı.");
                LoadSheepInfo();
                UpdateCashLabel();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateSheepAgeLabel()
        {
            int age = _farmController.GetSheepAge();
            txtSheepAge.Text = age > 0 ? age.ToString() : "Koyun Yok";
        }

        private async void btnSheepWool_Click(object sender, EventArgs e)
        {
            btnSheepWool.Enabled = false;

            string selectedGender = cbSheepGender.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(selectedGender) || selectedGender == "Seçiniz")
            {
                MessageBox.Show("Lütfen koyunun cinsiyetini seçin, yün kırpma yapılamaz.");
                btnSheepBuy.Enabled = true;
                sheepBuyBlinkTimer.Start();
                btnSheepBuy.BackColor = Color.Red;
                return;
            }

            if (!_farmController.HasAliveSheep())
            {
                MessageBox.Show("Canlı koyun yok! Lütfen yeni bir koyun satın alın.");
                sheepBuyBlinkTimer.Start();
                InitializeSheepGenderComboBox();
                cbSheepGender.Enabled = true;
                btnSheepBuy.Enabled = true;
                btnSheepBuy.BackColor = Color.Red;
                return;
            }

            pbSheepProduction.Value = 0;
            for (int i = 0; i <= 100; i++)
            {
                pbSheepProduction.Value = i;
                await Task.Delay(70);
            }

            bool sheepAlive = !_farmController.FeedSheep();
            if (!sheepAlive)
            {
                MessageBox.Show("Koyun 10 yaşına ulaştı ve öldü. Yeni koyun almanız gerekiyor.");
                txtSheepAge.Text = "Koyun Yok";
                btnSheepWool.Enabled = false;
                btnSheepSell.Enabled = false;
                cbSheepGender.Enabled = true;
                InitializeSheepGenderComboBox();
                sheepBuyBlinkTimer.Start();
                btnSheepBuy.BackColor = Color.Red;
                return;
            }

            UpdateSheepProductCountLabel();
            UpdateSheepAgeLabel();

            btnSheepWool.Enabled = _farmController.HasAliveSheep();
        }

        private void UpdateSheepProductCountLabel()
        {
            int count = _farmController.GetUnsoldWoolCount();
            lblSheepProductCount.Text = $"Yün: {count}";
        }

        private void btnSheepSell_Click(object sender, EventArgs e)
        {
            int unsoldCount = _farmController.GetUnsoldWoolCount();
            if (unsoldCount == 0)
            {
                MessageBox.Show("Satılacak yün yok!");
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Depoda {unsoldCount} yün var. Kaç tane satmak istersiniz?",
                "Yün Sat", "1");

            if (string.IsNullOrWhiteSpace(input)) return;

            if (!int.TryParse(input, out int quantityToSell))
            {
                MessageBox.Show("Geçerli bir sayı giriniz.");
                return;
            }

            if (quantityToSell > unsoldCount)
            {
                MessageBox.Show("Stokta bu kadar yün yok!");
                return;
            }

            decimal unitPrice = 15;
            int soldCount = _farmController.SellWool(quantityToSell, unitPrice);
            decimal totalEarned = soldCount * unitPrice;

            UpdateSheepProductCountLabel();
            UpdateCashLabel();

            MessageBox.Show($"{soldCount} yün satıldı. Kasaya {totalEarned:C} eklendi.");
        }

        private void UpdateSheepProductCountLabel_Click(object sender, EventArgs e)
        {
            int count = _farmController.GetUnsoldWoolCount();
            lblSheepProductCount.Text = $"Yün: {count}";
        }

        private void cbSheepGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSheepGender.Enabled)
            {
                string selectedGender = cbSheepGender.SelectedItem?.ToString() ?? string.Empty;
                btnSheepWool.Enabled = !string.IsNullOrEmpty(selectedGender) && selectedGender != "Seçiniz";
            }
        }

        private void LoadSheepInfo()
        {
            cbSheepGender.Items.Clear();
            cbSheepGender.Items.Add("Seçiniz");
            cbSheepGender.Items.Add("Dişi");
            cbSheepGender.Items.Add("Erkek");
            cbSheepGender.DropDownStyle = ComboBoxStyle.DropDownList;

            int? sheepId = _farmController.GetAliveSheepId();
            if (sheepId.HasValue)
            {
                int age = _farmController.GetSheepAgeById(sheepId.Value);
                string? gender = _farmController.GetSheepGenderById(sheepId.Value);
                txtSheepAge.Text = age.ToString();
                if (gender?.ToLower() == "erkek" || gender?.ToLower() == "male")
                    cbSheepGender.SelectedItem = "Erkek";
                else if (gender?.ToLower() == "dişi" || gender?.ToLower() == "disi" || gender?.ToLower() == "female")
                    cbSheepGender.SelectedItem = "Dişi";
                else
                    cbSheepGender.SelectedIndex = 0;

                cbSheepGender.Enabled = false;
                btnSheepWool.Enabled = true;
                btnSheepSell.Enabled = true;

                btnSheepBuy.Enabled = true;
                sheepBuyBlinkTimer.Stop();
                btnSheepBuy.BackColor = SystemColors.Control;
            }
            else
            {
                txtSheepAge.Text = "Koyun Yok";
                cbSheepGender.SelectedIndex = 0;
                cbSheepGender.Enabled = true;
                btnSheepWool.Enabled = false;
                btnSheepSell.Enabled = false;

                btnSheepBuy.Enabled = true;
                sheepBuyBlinkTimer.Start();
                btnSheepBuy.BackColor = Color.Red;
            }

            UpdateSheepProductCountLabel();
        }

        private void InitializeSheepGenderComboBox()
        {
            cbSheepGender.Items.Clear();
            cbSheepGender.Items.Add("Seçiniz");
            cbSheepGender.Items.Add("Dişi");
            cbSheepGender.Items.Add("Erkek");
            cbSheepGender.SelectedIndex = 0;
            cbSheepGender.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void btnGooseBuy_Click(object sender, EventArgs e)
        {
            if (_farmController.HasAliveGoose())
            {
                MessageBox.Show("Zaten canlı bir kazınız var. Yeni bir kaz satın alamazsınız.");
                gooseBuyBlinkTimer.Stop();
                btnGooseBuy.BackColor = SystemColors.Control;
                return;
            }

            string selectedGender = cbGooseGender.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrEmpty(selectedGender) || selectedGender == "Seçiniz")
            {
                MessageBox.Show("Lütfen kazın cinsiyetini seçin.");
                return;
            }


            decimal goosePrice = 90;

            try
            {
                _farmController.BuyGoose(selectedGender, goosePrice);

                UpdateCashLabel();
                UpdateGooseProductCountLabel();

                cbGooseGender.Enabled = false;
                btnGooseFeed.Enabled = true;
                btnGooseSell.Enabled = true;

                btnGooseBuy.Enabled = true;
                gooseBuyBlinkTimer.Stop();
                btnGooseBuy.BackColor = SystemColors.Control;

                MessageBox.Show("Yeni kaz başarıyla satın alındı.");

                LoadGooseInfo();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbGooseGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGender = cbGooseGender.SelectedItem?.ToString() ?? "";
            if (!string.IsNullOrEmpty(selectedGender) && selectedGender != "Seçiniz")
            {
                int? gooseId = _farmController.GetAliveGooseId();
                if (gooseId.HasValue)
                {
                    _farmController.UpdateGooseGender(gooseId.Value, selectedGender);
                    btnGooseFeed.Enabled = true;
                }
            }
            else
            {
                btnGooseFeed.Enabled = false;
            }
        }

        private void UpdateGooseAgeLabel()
        {
            int age = _farmController.GetGooseAge();
            txtGooseAge.Text = age > 0 ? age.ToString() : "Kaz Yok";
        }

        private void GooseBuyBlinkTimer_Tick(object sender, EventArgs e)
        {
            btnGooseSell.BackColor = btnGooseSell.BackColor == Color.Red ? SystemColors.Control : Color.Red;
        }

        private async void btnGooseFeed_Click(object sender, EventArgs e)
        {
            btnGooseFeed.Enabled = false;

            string selectedGender = cbGooseGender.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrEmpty(selectedGender) || selectedGender == "Seçiniz")
            {
                MessageBox.Show("Lütfen kazın cinsiyetini seçin, besleme yapılamaz.");
                btnGooseBuy.Enabled = true;
                gooseBuyBlinkTimer.Start();
                btnGooseBuy.BackColor = Color.Red;
                return;
            }

            if (!_farmController.HasAliveGoose())
            {
                MessageBox.Show("Canlı kaz yok! Lütfen yeni bir kaz satın alın.");
                gooseBuyBlinkTimer.Start();
                InitializeGooseGenderComboBox();
                cbGooseGender.Enabled = true;
                btnGooseBuy.Enabled = true;
                btnGooseBuy.BackColor = Color.Red;
                return;
            }

            pbGooseProduction.Value = 0;
            for (int i = 0; i <= 100; i++)
            {
                pbGooseProduction.Value = i;
                await Task.Delay(100);
            }

            bool gooseAlive = !_farmController.FeedGoose();
            if (!gooseAlive)
            {
                MessageBox.Show("Kaz 10 yaşına ulaştı ve öldü. Yeni kaz almanız gerekiyor.");

                txtGooseAge.Text = "Kaz Yok";
                btnGooseFeed.Enabled = false;
                btnGooseSell.Enabled = false;

                gooseBuyBlinkTimer.Start();
                btnGooseBuy.Enabled = true;
                btnGooseBuy.BackColor = Color.Red;

                InitializeGooseGenderComboBox();
                cbGooseGender.Enabled = true;

                return;
            }

            UpdateGooseAgeLabel();
            UpdateGooseProductCountLabel();

            btnGooseFeed.Enabled = _farmController.HasAliveGoose();
        }

        private void InitializeGooseGenderComboBox()
        {
            cbGooseGender.Items.Clear();
            cbGooseGender.Items.Add("Seçiniz");
            cbGooseGender.Items.Add("Dişi");
            cbGooseGender.Items.Add("Erkek");
            cbGooseGender.SelectedIndex = 0;
            cbGooseGender.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void UpdateGooseProductCountLabel()
        {
            int count = _farmController.GetUnsoldFeatherCount();  
            lblGooseProductCount.Text = $"Tüy: {count}";
        }
        private void LoadGooseInfo()
        {
            cbGooseGender.Items.Clear();
            cbGooseGender.Items.Add("Seçiniz");
            cbGooseGender.Items.Add("Erkek");
            cbGooseGender.Items.Add("Dişi");
            cbGooseGender.DropDownStyle = ComboBoxStyle.DropDownList;

           
            var goose = _farmController.GetAliveGoose();
            if (goose != null)
            {
                txtGooseAge.Text = goose.Age.ToString();

                string gender = (goose.Gender ?? "").Trim().ToLowerInvariant();

                if (gender == "erkek" || gender == "male")
                    cbGooseGender.SelectedItem = "Erkek";
                else if (gender == "dişi" || gender == "disi" || gender == "female")
                    cbGooseGender.SelectedItem = "Dişi";
                else
                    cbGooseGender.SelectedIndex = 0;

                cbGooseGender.Enabled = false;
                btnGooseFeed.Enabled = true;
                btnGooseSell.Enabled = true;

                btnGooseBuy.Enabled = true;
                gooseBuyBlinkTimer.Stop();
                btnGooseBuy.BackColor = SystemColors.Control;
            }
            else
            {
                txtGooseAge.Text = "Kaz Yok";
                cbGooseGender.SelectedIndex = 0;
                cbGooseGender.Enabled = true;
                btnGooseFeed.Enabled = false;
                btnGooseSell.Enabled = false;

                btnGooseBuy.Enabled = true;
                gooseBuyBlinkTimer.Start();
                btnGooseBuy.BackColor = Color.Red;
            }

            UpdateGooseProductCountLabel();
        }







        private void btnChickenFeed_MouseDown(object? sender, MouseEventArgs e)
        {
            btnChickenFeed.Location = new Point(
                btnChickenFeedOriginalLocation.X + 1,
                btnChickenFeedOriginalLocation.Y + 1
            );
        }

        private void btnChickenFeed_MouseUp(object? sender, MouseEventArgs e)
        {
            btnChickenFeed.Location = btnChickenFeedOriginalLocation;
        }


        private void btnCowFeed_MouseDown(object sender, MouseEventArgs e)
        {
            btnCowFeed.Location = new Point(
               btnCowFeedOriginalLocation.X + 1,
               btnCowFeedOriginalLocation.Y + 1
           );
        }

        private void btnCowFeed_MouseUp(object sender, MouseEventArgs e)
        {
            btnCowFeed.Location = btnCowFeedOriginalLocation;
        }

        private void btnSheepWool_MouseDown(object sender, MouseEventArgs e)
        {
            btnSheepWool.Location = new Point(
                 btnSheepWoolOriginalLocation.X + 1,
                btnSheepWoolOriginalLocation.Y + 1
            );
        }

        private void btnSheepWool_MouseUp(object sender, MouseEventArgs e)
        {
            btnSheepWool.Location = btnSheepWoolOriginalLocation;

        }

        private void btnGooseFeed_MouseDown(object sender, MouseEventArgs e)
        {
            btnGooseFeed.Location = new Point(
               btnGooseFeedOriginalLocation.X + 1,
                btnGooseFeedOriginalLocation.Y + 1
            );
        }

        private void btnGooseFeed_MouseUp(object sender, MouseEventArgs e)
        {
            btnGooseFeed.Location = btnGooseFeedOriginalLocation;

        }


        private void btnGooseSell_Click(object sender, EventArgs e)
        {
            int unsoldCount = _farmController.GetUnsoldFeatherCount();

            if (unsoldCount == 0)
            {
                MessageBox.Show("Satılacak kaz ürünü yok!");
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Depoda {unsoldCount} tüy var. Kaç tane satmak istersiniz?",
                "Tüy Sat", "1");

            if (string.IsNullOrWhiteSpace(input)) return;

            if (!int.TryParse(input, out int quantityToSell))
            {
                MessageBox.Show("Geçerli bir sayı giriniz.");
                return;
            }

            if (quantityToSell > unsoldCount)
            {
                MessageBox.Show("Stokta bu kadar tüy yok!");
                return;
            }

            decimal unitPrice = 5;
            int soldCount = _farmController.SellFeather(quantityToSell, unitPrice);
            decimal totalEarned = soldCount * unitPrice;

            UpdateGooseProductCountLabel();
            UpdateCashLabel();

            MessageBox.Show($"{soldCount} tüy satıldı. Kasaya {totalEarned:C} eklendi.");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
               
                var statisticsList = _statisticsRepository.GetStatistics();

                StatisticsForm statsForm = new();
                statsForm.LoadStatistics(statisticsList); 
                statsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İstatistikler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void lblChickenProductCount_Click(object sender, EventArgs e)
        {

        }
    }
}





    


