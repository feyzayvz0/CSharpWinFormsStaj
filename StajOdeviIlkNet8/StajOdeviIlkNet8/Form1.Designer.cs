namespace StajOdeviIlkNet8
{
    partial class Form1
    {
        
        private System.ComponentModel.IContainer components = null;

        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtChickenAge = new TextBox();
            chickenPrice = new Label();
            lblChickenProductCount = new Label();
            lblChickenTitle = new Label();
            label4 = new Label();
            pbChickenProduction = new ProgressBar();
            label3 = new Label();
            btnChickenBuy = new Button();
            btnChickenSell = new Button();
            btnChickenFeed = new Button();
            cbChickenGender = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblCowProductCount = new Label();
            txtCowAge = new TextBox();
            label5 = new Label();
            pbCowProduction = new ProgressBar();
            label6 = new Label();
            btnCowBuy = new Button();
            btnCowSell = new Button();
            btnCowFeed = new Button();
            cbCowGender = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            pictureBox2 = new PictureBox();
            lblSheepProductCount = new Label();
            txtSheepAge = new TextBox();
            label9 = new Label();
            pbSheepProduction = new ProgressBar();
            label10 = new Label();
            btnSheepBuy = new Button();
            btnSheepSell = new Button();
            cbSheepGender = new ComboBox();
            label11 = new Label();
            label12 = new Label();
            pictureBox3 = new PictureBox();
            lblGooseProductCount = new Label();
            txtGooseAge = new TextBox();
            label13 = new Label();
            pbGooseProduction = new ProgressBar();
            label14 = new Label();
            btnGooseBuy = new Button();
            btnGooseSell = new Button();
            cbGooseGender = new ComboBox();
            label15 = new Label();
            label16 = new Label();
            pictureBox4 = new PictureBox();
            lblCash = new Label();
            label17 = new Label();
            istatistikbtn = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            label18 = new Label();
            label19 = new Label();
            panel3 = new Panel();
            label20 = new Label();
            label21 = new Label();
            btnSheepWool = new Button();
            panel4 = new Panel();
            label22 = new Label();
            label23 = new Label();
            btnGooseFeed = new Button();
            panel5 = new Panel();
            pictureBox5 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // txtChickenAge
            // 
            txtChickenAge.Location = new Point(89, 195);
            txtChickenAge.Margin = new Padding(3, 4, 3, 4);
            txtChickenAge.Name = "txtChickenAge";
            txtChickenAge.ReadOnly = true;
            txtChickenAge.Size = new Size(100, 27);
            txtChickenAge.TabIndex = 18;
            // 
            // chickenPrice
            // 
            chickenPrice.AutoSize = true;
            chickenPrice.FlatStyle = FlatStyle.Popup;
            chickenPrice.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            chickenPrice.ForeColor = Color.White;
            chickenPrice.Location = new Point(120, 161);
            chickenPrice.Name = "chickenPrice";
            chickenPrice.Size = new Size(135, 20);
            chickenPrice.TabIndex = 12;
            chickenPrice.Text = "Tavuk Ücreti:20₺";
            chickenPrice.Click += chickenPrice_Click;
            // 
            // lblChickenProductCount
            // 
            lblChickenProductCount.AutoSize = true;
            lblChickenProductCount.FlatStyle = FlatStyle.Popup;
            lblChickenProductCount.Font = new Font("Franklin Gothic Medium", 7.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblChickenProductCount.ForeColor = Color.Black;
            lblChickenProductCount.Location = new Point(151, 386);
            lblChickenProductCount.Name = "lblChickenProductCount";
            lblChickenProductCount.Size = new Size(11, 16);
            lblChickenProductCount.TabIndex = 11;
            lblChickenProductCount.Text = ".";
            lblChickenProductCount.Click += lblChickenProductCount_Click;
            // 
            // lblChickenTitle
            // 
            lblChickenTitle.AutoSize = true;
            lblChickenTitle.FlatStyle = FlatStyle.Popup;
            lblChickenTitle.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblChickenTitle.ForeColor = Color.White;
            lblChickenTitle.Location = new Point(20, 161);
            lblChickenTitle.Name = "lblChickenTitle";
            lblChickenTitle.Size = new Size(94, 20);
            lblChickenTitle.TabIndex = 10;
            lblChickenTitle.Text = "Yumurta:5₺";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Popup;
            label4.Font = new Font("Franklin Gothic Medium", 7.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.ForeColor = Color.FromArgb(64, 0, 0);
            label4.Location = new Point(-4, 388);
            label4.Name = "label4";
            label4.Size = new Size(136, 16);
            label4.TabIndex = 9;
            label4.Text = "Depodaki Ürün Sayısı:";
            // 
            // pbChickenProduction
            // 
            pbChickenProduction.Location = new Point(24, 355);
            pbChickenProduction.Margin = new Padding(3, 4, 3, 4);
            pbChickenProduction.Name = "pbChickenProduction";
            pbChickenProduction.Size = new Size(205, 29);
            pbChickenProduction.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Popup;
            label3.Font = new Font("Franklin Gothic Medium", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.ForeColor = Color.FromArgb(64, 0, 0);
            label3.Location = new Point(4, 330);
            label3.Name = "label3";
            label3.Size = new Size(82, 17);
            label3.TabIndex = 1;
            label3.Text = "Ürün Süreci";
            // 
            // btnChickenBuy
            // 
            btnChickenBuy.FlatAppearance.BorderSize = 0;
            btnChickenBuy.FlatStyle = FlatStyle.Popup;
            btnChickenBuy.Font = new Font("Comic Sans MS", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnChickenBuy.ForeColor = SystemColors.ControlText;
            btnChickenBuy.Image = Properties.Resources.btn;
            btnChickenBuy.Location = new Point(43, 452);
            btnChickenBuy.Margin = new Padding(3, 4, 3, 4);
            btnChickenBuy.Name = "btnChickenBuy";
            btnChickenBuy.Size = new Size(186, 39);
            btnChickenBuy.TabIndex = 7;
            btnChickenBuy.Text = "Yeni Hayvan Satın Al";
            btnChickenBuy.UseVisualStyleBackColor = true;
            btnChickenBuy.Click += btnChickenBuy_Click;
            // 
            // btnChickenSell
            // 
            btnChickenSell.FlatAppearance.BorderSize = 0;
            btnChickenSell.FlatStyle = FlatStyle.Popup;
            btnChickenSell.Font = new Font("Comic Sans MS", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnChickenSell.Image = Properties.Resources.btn;
            btnChickenSell.Location = new Point(43, 411);
            btnChickenSell.Margin = new Padding(3, 4, 3, 4);
            btnChickenSell.Name = "btnChickenSell";
            btnChickenSell.Size = new Size(186, 35);
            btnChickenSell.TabIndex = 6;
            btnChickenSell.Text = "Ürünleri Sat";
            btnChickenSell.UseVisualStyleBackColor = true;
            btnChickenSell.Click += btnChickenSell_Click;
            // 
            // btnChickenFeed
            // 
            btnChickenFeed.BackgroundImage = Properties.Resources.btn;
            btnChickenFeed.BackgroundImageLayout = ImageLayout.Stretch;
            btnChickenFeed.FlatAppearance.BorderSize = 0;
            btnChickenFeed.FlatStyle = FlatStyle.Flat;
            btnChickenFeed.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnChickenFeed.ForeColor = Color.Black;
            btnChickenFeed.ImageAlign = ContentAlignment.TopCenter;
            btnChickenFeed.Location = new Point(52, 275);
            btnChickenFeed.Margin = new Padding(3, 4, 3, 4);
            btnChickenFeed.Name = "btnChickenFeed";
            btnChickenFeed.Size = new Size(161, 55);
            btnChickenFeed.TabIndex = 5;
            btnChickenFeed.Text = "Besle";
            btnChickenFeed.UseVisualStyleBackColor = true;
            btnChickenFeed.Click += btnChickenFeed_Click;
            btnChickenFeed.MouseDown += btnChickenFeed_MouseDown;
            btnChickenFeed.MouseUp += btnChickenFeed_MouseUp;
            // 
            // cbChickenGender
            // 
            cbChickenGender.FormattingEnabled = true;
            cbChickenGender.Location = new Point(89, 238);
            cbChickenGender.Margin = new Padding(3, 4, 3, 4);
            cbChickenGender.Name = "cbChickenGender";
            cbChickenGender.Size = new Size(100, 28);
            cbChickenGender.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DarkSeaGreen;
            label2.Font = new Font("Franklin Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.FromArgb(64, 0, 0);
            label2.Location = new Point(3, 238);
            label2.Name = "label2";
            label2.Size = new Size(80, 21);
            label2.TabIndex = 3;
            label2.Text = "Cinsiyet:";
            label2.Click += Label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkSeaGreen;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Franklin Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.FromArgb(64, 0, 0);
            label1.Location = new Point(40, 195);
            label1.Name = "label1";
            label1.Size = new Size(44, 21);
            label1.TabIndex = 2;
            label1.Text = "Yaş:";
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = Properties.Resources.tvk;
            pictureBox1.Location = new Point(13, 4);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(225, 154);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblCowProductCount
            // 
            lblCowProductCount.AutoSize = true;
            lblCowProductCount.FlatStyle = FlatStyle.Popup;
            lblCowProductCount.Font = new Font("Franklin Gothic Medium", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblCowProductCount.ForeColor = Color.Black;
            lblCowProductCount.Location = new Point(158, 386);
            lblCowProductCount.Name = "lblCowProductCount";
            lblCowProductCount.Size = new Size(12, 17);
            lblCowProductCount.TabIndex = 11;
            lblCowProductCount.Text = ".";
            // 
            // txtCowAge
            // 
            txtCowAge.Location = new Point(89, 189);
            txtCowAge.Margin = new Padding(3, 4, 3, 4);
            txtCowAge.Name = "txtCowAge";
            txtCowAge.Size = new Size(100, 27);
            txtCowAge.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Popup;
            label5.Font = new Font("Franklin Gothic Medium", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.ForeColor = Color.FromArgb(64, 0, 0);
            label5.Location = new Point(3, 386);
            label5.Name = "label5";
            label5.Size = new Size(149, 17);
            label5.TabIndex = 9;
            label5.Text = "Depodaki Ürün Sayısı:";
            // 
            // pbCowProduction
            // 
            pbCowProduction.Location = new Point(24, 349);
            pbCowProduction.Margin = new Padding(3, 4, 3, 4);
            pbCowProduction.Name = "pbCowProduction";
            pbCowProduction.Size = new Size(205, 34);
            pbCowProduction.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Franklin Gothic Medium", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.ForeColor = Color.FromArgb(64, 0, 0);
            label6.Location = new Point(9, 324);
            label6.Name = "label6";
            label6.Size = new Size(82, 17);
            label6.TabIndex = 1;
            label6.Text = "Ürün Süreci";
            // 
            // btnCowBuy
            // 
            btnCowBuy.FlatAppearance.BorderSize = 0;
            btnCowBuy.FlatStyle = FlatStyle.Popup;
            btnCowBuy.Font = new Font("Comic Sans MS", 7.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnCowBuy.Image = Properties.Resources.btn;
            btnCowBuy.Location = new Point(34, 451);
            btnCowBuy.Margin = new Padding(3, 4, 3, 4);
            btnCowBuy.Name = "btnCowBuy";
            btnCowBuy.Size = new Size(186, 41);
            btnCowBuy.TabIndex = 7;
            btnCowBuy.Text = "Yeni Hayvan Satın Al";
            btnCowBuy.UseVisualStyleBackColor = true;
            btnCowBuy.Click += btnCowBuy_Click;
            // 
            // btnCowSell
            // 
            btnCowSell.FlatStyle = FlatStyle.Popup;
            btnCowSell.Font = new Font("Comic Sans MS", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnCowSell.Image = Properties.Resources.btn;
            btnCowSell.Location = new Point(34, 410);
            btnCowSell.Margin = new Padding(3, 4, 3, 4);
            btnCowSell.Name = "btnCowSell";
            btnCowSell.Size = new Size(186, 36);
            btnCowSell.TabIndex = 6;
            btnCowSell.Text = "Ürünleri Sat";
            btnCowSell.UseVisualStyleBackColor = true;
            btnCowSell.Click += btnCowSell_Click;
            // 
            // btnCowFeed
            // 
            btnCowFeed.BackColor = Color.Transparent;
            btnCowFeed.BackgroundImage = Properties.Resources.btn;
            btnCowFeed.BackgroundImageLayout = ImageLayout.Stretch;
            btnCowFeed.FlatAppearance.BorderSize = 0;
            btnCowFeed.FlatStyle = FlatStyle.Flat;
            btnCowFeed.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnCowFeed.ForeColor = Color.Black;
            btnCowFeed.ImageAlign = ContentAlignment.TopCenter;
            btnCowFeed.Location = new Point(50, 274);
            btnCowFeed.Margin = new Padding(3, 4, 3, 4);
            btnCowFeed.Name = "btnCowFeed";
            btnCowFeed.Size = new Size(159, 49);
            btnCowFeed.TabIndex = 5;
            btnCowFeed.Text = "Besle";
            btnCowFeed.UseVisualStyleBackColor = false;
            btnCowFeed.Click += button6_Click;
            btnCowFeed.MouseDown += btnCowFeed_MouseDown;
            btnCowFeed.MouseUp += btnCowFeed_MouseUp;
            // 
            // cbCowGender
            // 
            cbCowGender.FormattingEnabled = true;
            cbCowGender.Location = new Point(89, 229);
            cbCowGender.Margin = new Padding(3, 4, 3, 4);
            cbCowGender.Name = "cbCowGender";
            cbCowGender.Size = new Size(100, 28);
            cbCowGender.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.DarkSeaGreen;
            label7.FlatStyle = FlatStyle.Popup;
            label7.Font = new Font("Franklin Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.ForeColor = Color.FromArgb(64, 0, 0);
            label7.Location = new Point(3, 232);
            label7.Name = "label7";
            label7.Size = new Size(80, 21);
            label7.TabIndex = 3;
            label7.Text = "Cinsiyet:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.DarkSeaGreen;
            label8.FlatStyle = FlatStyle.Popup;
            label8.Font = new Font("Franklin Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label8.ForeColor = Color.FromArgb(64, 0, 0);
            label8.Location = new Point(31, 189);
            label8.Name = "label8";
            label8.Size = new Size(44, 21);
            label8.TabIndex = 2;
            label8.Text = "Yaş:";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.inek;
            pictureBox2.Location = new Point(15, 9);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(228, 142);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // lblSheepProductCount
            // 
            lblSheepProductCount.AutoSize = true;
            lblSheepProductCount.FlatStyle = FlatStyle.Popup;
            lblSheepProductCount.Font = new Font("Franklin Gothic Medium", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblSheepProductCount.ForeColor = Color.Black;
            lblSheepProductCount.Location = new Point(158, 382);
            lblSheepProductCount.Name = "lblSheepProductCount";
            lblSheepProductCount.Size = new Size(12, 17);
            lblSheepProductCount.TabIndex = 11;
            lblSheepProductCount.Text = ".";
            lblSheepProductCount.Click += UpdateSheepProductCountLabel_Click;
            // 
            // txtSheepAge
            // 
            txtSheepAge.Location = new Point(88, 186);
            txtSheepAge.Margin = new Padding(3, 4, 3, 4);
            txtSheepAge.Name = "txtSheepAge";
            txtSheepAge.Size = new Size(100, 27);
            txtSheepAge.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Franklin Gothic Medium", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label9.ForeColor = Color.FromArgb(64, 0, 0);
            label9.Location = new Point(3, 382);
            label9.Name = "label9";
            label9.Size = new Size(149, 17);
            label9.TabIndex = 9;
            label9.Text = "Depodaki Ürün Sayısı:";
            // 
            // pbSheepProduction
            // 
            pbSheepProduction.Location = new Point(9, 349);
            pbSheepProduction.Margin = new Padding(3, 4, 3, 4);
            pbSheepProduction.Name = "pbSheepProduction";
            pbSheepProduction.Size = new Size(205, 29);
            pbSheepProduction.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.FlatStyle = FlatStyle.Popup;
            label10.Font = new Font("Franklin Gothic Medium", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label10.ForeColor = Color.FromArgb(64, 0, 0);
            label10.Location = new Point(6, 325);
            label10.Name = "label10";
            label10.Size = new Size(82, 17);
            label10.TabIndex = 1;
            label10.Text = "Ürün Süreci";
            // 
            // btnSheepBuy
            // 
            btnSheepBuy.FlatStyle = FlatStyle.Popup;
            btnSheepBuy.Font = new Font("Comic Sans MS", 7.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSheepBuy.Image = Properties.Resources.btn;
            btnSheepBuy.Location = new Point(28, 449);
            btnSheepBuy.Margin = new Padding(3, 4, 3, 4);
            btnSheepBuy.Name = "btnSheepBuy";
            btnSheepBuy.Size = new Size(186, 41);
            btnSheepBuy.TabIndex = 7;
            btnSheepBuy.Text = "Yeni Hayvan Satın Al";
            btnSheepBuy.UseVisualStyleBackColor = true;
            btnSheepBuy.Click += btnSheepBuy_Click;
            // 
            // btnSheepSell
            // 
            btnSheepSell.FlatStyle = FlatStyle.Popup;
            btnSheepSell.Font = new Font("Comic Sans MS", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSheepSell.Image = Properties.Resources.btn;
            btnSheepSell.Location = new Point(28, 408);
            btnSheepSell.Margin = new Padding(3, 4, 3, 4);
            btnSheepSell.Name = "btnSheepSell";
            btnSheepSell.Size = new Size(186, 34);
            btnSheepSell.TabIndex = 6;
            btnSheepSell.Text = "Ürünleri Sat";
            btnSheepSell.UseVisualStyleBackColor = true;
            btnSheepSell.Click += btnSheepSell_Click;
            // 
            // cbSheepGender
            // 
            cbSheepGender.FormattingEnabled = true;
            cbSheepGender.Location = new Point(88, 232);
            cbSheepGender.Margin = new Padding(3, 4, 3, 4);
            cbSheepGender.Name = "cbSheepGender";
            cbSheepGender.Size = new Size(100, 28);
            cbSheepGender.TabIndex = 4;
            cbSheepGender.SelectedIndexChanged += cbSheepGender_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.DarkSeaGreen;
            label11.FlatStyle = FlatStyle.Popup;
            label11.Font = new Font("Franklin Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label11.ForeColor = Color.FromArgb(64, 0, 0);
            label11.Location = new Point(2, 232);
            label11.Name = "label11";
            label11.Size = new Size(80, 21);
            label11.TabIndex = 3;
            label11.Text = "Cinsiyet:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.DarkSeaGreen;
            label12.FlatStyle = FlatStyle.Popup;
            label12.Font = new Font("Franklin Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label12.ForeColor = Color.FromArgb(64, 0, 0);
            label12.Location = new Point(20, 185);
            label12.Name = "label12";
            label12.Size = new Size(44, 21);
            label12.TabIndex = 2;
            label12.Text = "Yaş:";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.koyun;
            pictureBox3.Location = new Point(3, 4);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(253, 148);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // lblGooseProductCount
            // 
            lblGooseProductCount.AutoSize = true;
            lblGooseProductCount.Font = new Font("Franklin Gothic Medium", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblGooseProductCount.ForeColor = Color.Black;
            lblGooseProductCount.Location = new Point(166, 381);
            lblGooseProductCount.Name = "lblGooseProductCount";
            lblGooseProductCount.Size = new Size(12, 17);
            lblGooseProductCount.TabIndex = 11;
            lblGooseProductCount.Text = ".";
            // 
            // txtGooseAge
            // 
            txtGooseAge.Location = new Point(96, 181);
            txtGooseAge.Margin = new Padding(3, 4, 3, 4);
            txtGooseAge.Name = "txtGooseAge";
            txtGooseAge.Size = new Size(100, 27);
            txtGooseAge.TabIndex = 10;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Franklin Gothic Medium", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label13.ForeColor = Color.FromArgb(64, 0, 0);
            label13.Location = new Point(0, 382);
            label13.Name = "label13";
            label13.Size = new Size(149, 17);
            label13.TabIndex = 9;
            label13.Text = "Depodaki Ürün Sayısı:";
            // 
            // pbGooseProduction
            // 
            pbGooseProduction.Location = new Point(17, 349);
            pbGooseProduction.Margin = new Padding(3, 4, 3, 4);
            pbGooseProduction.Name = "pbGooseProduction";
            pbGooseProduction.Size = new Size(205, 29);
            pbGooseProduction.TabIndex = 8;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.FlatStyle = FlatStyle.Popup;
            label14.Font = new Font("Franklin Gothic Medium", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label14.ForeColor = Color.FromArgb(64, 0, 0);
            label14.Location = new Point(11, 329);
            label14.Name = "label14";
            label14.Size = new Size(82, 17);
            label14.TabIndex = 1;
            label14.Text = "Ürün Süreci";
            // 
            // btnGooseBuy
            // 
            btnGooseBuy.FlatStyle = FlatStyle.Popup;
            btnGooseBuy.Font = new Font("Comic Sans MS", 7.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGooseBuy.Image = Properties.Resources.btn;
            btnGooseBuy.Location = new Point(36, 451);
            btnGooseBuy.Margin = new Padding(3, 4, 3, 4);
            btnGooseBuy.Name = "btnGooseBuy";
            btnGooseBuy.Size = new Size(186, 41);
            btnGooseBuy.TabIndex = 7;
            btnGooseBuy.Text = "Yeni Hayvan Satın Al";
            btnGooseBuy.UseVisualStyleBackColor = true;
            btnGooseBuy.Click += btnGooseBuy_Click;
            // 
            // btnGooseSell
            // 
            btnGooseSell.FlatStyle = FlatStyle.Popup;
            btnGooseSell.Font = new Font("Comic Sans MS", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGooseSell.Image = Properties.Resources.btn;
            btnGooseSell.Location = new Point(36, 406);
            btnGooseSell.Margin = new Padding(3, 4, 3, 4);
            btnGooseSell.Name = "btnGooseSell";
            btnGooseSell.Size = new Size(186, 34);
            btnGooseSell.TabIndex = 6;
            btnGooseSell.Text = "Ürünleri Sat";
            btnGooseSell.UseVisualStyleBackColor = true;
            btnGooseSell.Click += btnGooseSell_Click;
            // 
            // cbGooseGender
            // 
            cbGooseGender.FormattingEnabled = true;
            cbGooseGender.Location = new Point(100, 234);
            cbGooseGender.Margin = new Padding(3, 4, 3, 4);
            cbGooseGender.Name = "cbGooseGender";
            cbGooseGender.Size = new Size(100, 28);
            cbGooseGender.TabIndex = 4;
            cbGooseGender.SelectedIndexChanged += cbGooseGender_SelectedIndexChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.DarkSeaGreen;
            label15.Font = new Font("Franklin Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label15.Location = new Point(13, 238);
            label15.Name = "label15";
            label15.Size = new Size(80, 21);
            label15.TabIndex = 3;
            label15.Text = "Cinsiyet:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.DarkSeaGreen;
            label16.FlatStyle = FlatStyle.Popup;
            label16.Font = new Font("Franklin Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label16.ForeColor = Color.FromArgb(64, 0, 0);
            label16.Location = new Point(37, 185);
            label16.Name = "label16";
            label16.Size = new Size(44, 21);
            label16.TabIndex = 2;
            label16.Text = "Yaş:";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.kaz;
            pictureBox4.Location = new Point(3, 4);
            pictureBox4.Margin = new Padding(3, 4, 3, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(253, 148);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // lblCash
            // 
            lblCash.AutoSize = true;
            lblCash.Font = new Font("Franklin Gothic Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblCash.ForeColor = Color.FromArgb(255, 128, 0);
            lblCash.Location = new Point(231, 102);
            lblCash.Name = "lblCash";
            lblCash.Size = new Size(23, 36);
            lblCash.TabIndex = 1;
            lblCash.Text = ".";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.FlatStyle = FlatStyle.Popup;
            label17.Font = new Font("Franklin Gothic Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label17.ForeColor = Color.FromArgb(64, 0, 0);
            label17.Location = new Point(241, 45);
            label17.Name = "label17";
            label17.Size = new Size(175, 29);
            label17.TabIndex = 0;
            label17.Text = "Kasadaki Para:";
            // 
            // istatistikbtn
            // 
            istatistikbtn.FlatAppearance.BorderSize = 2;
            istatistikbtn.FlatStyle = FlatStyle.Flat;
            istatistikbtn.Font = new Font("Comic Sans MS", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            istatistikbtn.Image = Properties.Resources.btn;
            istatistikbtn.Location = new Point(632, 589);
            istatistikbtn.Margin = new Padding(3, 4, 3, 4);
            istatistikbtn.Name = "istatistikbtn";
            istatistikbtn.Size = new Size(378, 122);
            istatistikbtn.TabIndex = 15;
            istatistikbtn.Text = "İstatistikleri Gör";
            istatistikbtn.UseVisualStyleBackColor = true;
            istatistikbtn.Click += button13_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(txtChickenAge);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(chickenPrice);
            panel1.Controls.Add(lblChickenProductCount);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblChickenTitle);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbChickenGender);
            panel1.Controls.Add(pbChickenProduction);
            panel1.Controls.Add(btnChickenFeed);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnChickenSell);
            panel1.Controls.Add(btnChickenBuy);
            panel1.Location = new Point(11, 15);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(266, 518);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label18);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(lblCowProductCount);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(txtCowAge);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(pbCowProduction);
            panel2.Controls.Add(cbCowGender);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(btnCowBuy);
            panel2.Controls.Add(btnCowFeed);
            panel2.Controls.Add(btnCowSell);
            panel2.Location = new Point(283, 16);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(263, 516);
            panel2.TabIndex = 16;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label18.ForeColor = Color.White;
            label18.Location = new Point(109, 158);
            label18.Name = "label18";
            label18.Size = new Size(134, 20);
            label18.TabIndex = 14;
            label18.Text = "İnek Ücreti:100₺";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.FlatStyle = FlatStyle.Popup;
            label19.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label19.ForeColor = Color.White;
            label19.Location = new Point(20, 160);
            label19.Name = "label19";
            label19.Size = new Size(68, 20);
            label19.TabIndex = 13;
            label19.Text = "Süt:10₺";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(label20);
            panel3.Controls.Add(label21);
            panel3.Controls.Add(lblSheepProductCount);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(txtSheepAge);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(pbSheepProduction);
            panel3.Controls.Add(cbSheepGender);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(btnSheepWool);
            panel3.Controls.Add(btnSheepBuy);
            panel3.Controls.Add(btnSheepSell);
            panel3.Location = new Point(570, 16);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(263, 516);
            panel3.TabIndex = 12;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.FlatStyle = FlatStyle.Popup;
            label20.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label20.ForeColor = Color.White;
            label20.Location = new Point(105, 155);
            label20.Name = "label20";
            label20.Size = new Size(136, 20);
            label20.TabIndex = 14;
            label20.Text = "Koyun Ücreti:80₺";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.FlatStyle = FlatStyle.Popup;
            label21.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label21.ForeColor = Color.White;
            label21.Location = new Point(39, 155);
            label21.Name = "label21";
            label21.Size = new Size(70, 20);
            label21.TabIndex = 13;
            label21.Text = "Yün:15₺";
            // 
            // btnSheepWool
            // 
            btnSheepWool.BackgroundImage = Properties.Resources.btn;
            btnSheepWool.BackgroundImageLayout = ImageLayout.Stretch;
            btnSheepWool.FlatAppearance.BorderSize = 0;
            btnSheepWool.FlatStyle = FlatStyle.Flat;
            btnSheepWool.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSheepWool.Location = new Point(44, 271);
            btnSheepWool.Margin = new Padding(3, 4, 3, 4);
            btnSheepWool.Name = "btnSheepWool";
            btnSheepWool.Size = new Size(170, 51);
            btnSheepWool.TabIndex = 5;
            btnSheepWool.Text = "Besle";
            btnSheepWool.UseVisualStyleBackColor = true;
            btnSheepWool.Click += btnSheepWool_Click;
            btnSheepWool.MouseDown += btnSheepWool_MouseDown;
            btnSheepWool.MouseUp += btnSheepWool_MouseUp;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(label22);
            panel4.Controls.Add(label23);
            panel4.Controls.Add(lblGooseProductCount);
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(txtGooseAge);
            panel4.Controls.Add(label16);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(pbGooseProduction);
            panel4.Controls.Add(cbGooseGender);
            panel4.Controls.Add(btnGooseFeed);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(btnGooseBuy);
            panel4.Controls.Add(btnGooseSell);
            panel4.Location = new Point(840, 16);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(263, 516);
            panel4.TabIndex = 17;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label22.ForeColor = Color.White;
            label22.Location = new Point(117, 158);
            label22.Name = "label22";
            label22.Size = new Size(118, 20);
            label22.TabIndex = 14;
            label22.Text = "Kaz Ücreti:90₺";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label23.ForeColor = Color.White;
            label23.Location = new Point(17, 158);
            label23.Name = "label23";
            label23.Size = new Size(57, 20);
            label23.TabIndex = 13;
            label23.Text = "Tüy:5₺";
            // 
            // btnGooseFeed
            // 
            btnGooseFeed.BackgroundImage = Properties.Resources.btn;
            btnGooseFeed.BackgroundImageLayout = ImageLayout.Stretch;
            btnGooseFeed.FlatAppearance.BorderSize = 0;
            btnGooseFeed.FlatStyle = FlatStyle.Flat;
            btnGooseFeed.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGooseFeed.Location = new Point(52, 271);
            btnGooseFeed.Margin = new Padding(3, 4, 3, 4);
            btnGooseFeed.Name = "btnGooseFeed";
            btnGooseFeed.Size = new Size(170, 54);
            btnGooseFeed.TabIndex = 5;
            btnGooseFeed.Text = "Besle";
            btnGooseFeed.UseVisualStyleBackColor = true;
            btnGooseFeed.Click += btnGooseFeed_Click;
            btnGooseFeed.MouseDown += btnGooseFeed_MouseDown;
            btnGooseFeed.MouseUp += btnGooseFeed_MouseUp;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.Controls.Add(pictureBox5);
            panel5.Controls.Add(lblCash);
            panel5.Controls.Add(label17);
            panel5.Location = new Point(12, 541);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(493, 215);
            panel5.TabIndex = 2;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.kasax;
            pictureBox5.Location = new Point(-10, 4);
            pictureBox5.Margin = new Padding(3, 4, 3, 4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(222, 204);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 2;
            pictureBox5.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1115, 779);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(istatistikbtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hayvan Çiftliği";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pbChickenProduction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChickenBuy;
        private System.Windows.Forms.Button btnChickenSell;
        private System.Windows.Forms.Button btnChickenFeed;
        private System.Windows.Forms.ComboBox cbChickenGender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar pbCowProduction;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCowBuy;
        private System.Windows.Forms.Button btnCowFeed;
        private System.Windows.Forms.ComboBox cbCowGender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar pbSheepProduction;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSheepBuy;
        private System.Windows.Forms.Button btnSheepSell;
        private System.Windows.Forms.ComboBox cbSheepGender;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ProgressBar pbGooseProduction;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnGooseBuy;
        private System.Windows.Forms.Button btnGooseSell;
        private System.Windows.Forms.ComboBox cbGooseGender;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button istatistikbtn;
        private System.Windows.Forms.Label lblChickenTitle;
        private System.Windows.Forms.Label lblChickenProductCount;
        private System.Windows.Forms.Label chickenPrice;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.TextBox txtChickenAge;
        private System.Windows.Forms.TextBox txtCowAge;
        private System.Windows.Forms.Label lblCowProductCount;
        private System.Windows.Forms.TextBox txtSheepAge;
        private System.Windows.Forms.Label lblSheepProductCount;
        private System.Windows.Forms.Label lblGooseProductCount;
        private System.Windows.Forms.TextBox txtGooseAge;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnGooseFeed;
        private System.Windows.Forms.Button btnSheepWool;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnCowSell;
    }
}

