namespace StajOdeviIlk
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
            this.txtChickenAge = new System.Windows.Forms.TextBox();
            this.chickenPrice = new System.Windows.Forms.Label();
            this.lblChickenProductCount = new System.Windows.Forms.Label();
            this.lblChickenTitle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbChickenProduction = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChickenBuy = new System.Windows.Forms.Button();
            this.btnChickenSell = new System.Windows.Forms.Button();
            this.btnChickenFeed = new System.Windows.Forms.Button();
            this.cbChickenGender = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCowProductCount = new System.Windows.Forms.Label();
            this.txtCowAge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pbCowProduction = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCowBuy = new System.Windows.Forms.Button();
            this.btnCowSell = new System.Windows.Forms.Button();
            this.btnCowFeed = new System.Windows.Forms.Button();
            this.cbCowGender = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblSheepProductCount = new System.Windows.Forms.Label();
            this.txtSheepAge = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pbSheepProduction = new System.Windows.Forms.ProgressBar();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSheepBuy = new System.Windows.Forms.Button();
            this.btnSheepSell = new System.Windows.Forms.Button();
            this.cbSheepGender = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblGooseProductCount = new System.Windows.Forms.Label();
            this.txtGooseAge = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pbGooseProduction = new System.Windows.Forms.ProgressBar();
            this.label14 = new System.Windows.Forms.Label();
            this.btnGooseBuy = new System.Windows.Forms.Button();
            this.btnGooseSell = new System.Windows.Forms.Button();
            this.cbGooseGender = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblCash = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.istatistikbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnSheepWool = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnGooseFeed = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // txtChickenAge
            // 
            this.txtChickenAge.Location = new System.Drawing.Point(89, 156);
            this.txtChickenAge.Name = "txtChickenAge";
            this.txtChickenAge.ReadOnly = true;
            this.txtChickenAge.Size = new System.Drawing.Size(100, 22);
            this.txtChickenAge.TabIndex = 18;
            // 
            // chickenPrice
            // 
            this.chickenPrice.AutoSize = true;
            this.chickenPrice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chickenPrice.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chickenPrice.ForeColor = System.Drawing.Color.White;
            this.chickenPrice.Location = new System.Drawing.Point(120, 129);
            this.chickenPrice.Name = "chickenPrice";
            this.chickenPrice.Size = new System.Drawing.Size(135, 20);
            this.chickenPrice.TabIndex = 12;
            this.chickenPrice.Text = "Tavuk Ücreti:20₺";
            this.chickenPrice.Click += new System.EventHandler(this.chickenPrice_Click);
            // 
            // lblChickenProductCount
            // 
            this.lblChickenProductCount.AutoSize = true;
            this.lblChickenProductCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblChickenProductCount.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblChickenProductCount.ForeColor = System.Drawing.Color.Black;
            this.lblChickenProductCount.Location = new System.Drawing.Point(151, 309);
            this.lblChickenProductCount.Name = "lblChickenProductCount";
            this.lblChickenProductCount.Size = new System.Drawing.Size(12, 17);
            this.lblChickenProductCount.TabIndex = 11;
            this.lblChickenProductCount.Text = ".";
            this.lblChickenProductCount.Click += new System.EventHandler(this.lblChickenProductCount_Click);
            // 
            // lblChickenTitle
            // 
            this.lblChickenTitle.AutoSize = true;
            this.lblChickenTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblChickenTitle.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblChickenTitle.ForeColor = System.Drawing.Color.White;
            this.lblChickenTitle.Location = new System.Drawing.Point(20, 129);
            this.lblChickenTitle.Name = "lblChickenTitle";
            this.lblChickenTitle.Size = new System.Drawing.Size(94, 20);
            this.lblChickenTitle.TabIndex = 10;
            this.lblChickenTitle.Text = "Yumurta:5₺";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(-4, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Depodaki Ürün Sayısı:";
            // 
            // pbChickenProduction
            // 
            this.pbChickenProduction.Location = new System.Drawing.Point(24, 284);
            this.pbChickenProduction.Name = "pbChickenProduction";
            this.pbChickenProduction.Size = new System.Drawing.Size(205, 23);
            this.pbChickenProduction.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(4, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ürün Süreci";
            // 
            // btnChickenBuy
            // 
            this.btnChickenBuy.FlatAppearance.BorderSize = 0;
            this.btnChickenBuy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChickenBuy.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnChickenBuy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChickenBuy.Image = global::StajOdeviIlk.Properties.Resources.btn;
            this.btnChickenBuy.Location = new System.Drawing.Point(43, 362);
            this.btnChickenBuy.Name = "btnChickenBuy";
            this.btnChickenBuy.Size = new System.Drawing.Size(186, 31);
            this.btnChickenBuy.TabIndex = 7;
            this.btnChickenBuy.Text = "Yeni Hayvan Satın Al";
            this.btnChickenBuy.UseVisualStyleBackColor = true;
            this.btnChickenBuy.Click += new System.EventHandler(this.btnChickenBuy_Click);
            // 
            // btnChickenSell
            // 
            this.btnChickenSell.FlatAppearance.BorderSize = 0;
            this.btnChickenSell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChickenSell.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnChickenSell.Image = global::StajOdeviIlk.Properties.Resources.btn;
            this.btnChickenSell.Location = new System.Drawing.Point(43, 329);
            this.btnChickenSell.Name = "btnChickenSell";
            this.btnChickenSell.Size = new System.Drawing.Size(186, 28);
            this.btnChickenSell.TabIndex = 6;
            this.btnChickenSell.Text = "Ürünleri Sat";
            this.btnChickenSell.UseVisualStyleBackColor = true;
            this.btnChickenSell.Click += new System.EventHandler(this.btnChickenSell_Click);
            // 
            // btnChickenFeed
            // 
            this.btnChickenFeed.BackgroundImage = global::StajOdeviIlk.Properties.Resources.btn;
            this.btnChickenFeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChickenFeed.FlatAppearance.BorderSize = 0;
            this.btnChickenFeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChickenFeed.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnChickenFeed.ForeColor = System.Drawing.Color.Black;
            this.btnChickenFeed.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChickenFeed.Location = new System.Drawing.Point(52, 220);
            this.btnChickenFeed.Name = "btnChickenFeed";
            this.btnChickenFeed.Size = new System.Drawing.Size(161, 44);
            this.btnChickenFeed.TabIndex = 5;
            this.btnChickenFeed.Text = "Besle";
            this.btnChickenFeed.UseVisualStyleBackColor = true;
            this.btnChickenFeed.Click += new System.EventHandler(this.btnChickenFeed_Click);
            this.btnChickenFeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnChickenFeed_MouseDown);
            this.btnChickenFeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnChickenFeed_MouseUp);
            // 
            // cbChickenGender
            // 
            this.cbChickenGender.FormattingEnabled = true;
            this.cbChickenGender.Location = new System.Drawing.Point(89, 190);
            this.cbChickenGender.Name = "cbChickenGender";
            this.cbChickenGender.Size = new System.Drawing.Size(100, 24);
            this.cbChickenGender.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(3, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cinsiyet:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(40, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Yaş:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::StajOdeviIlk.Properties.Resources.tvk;
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblCowProductCount
            // 
            this.lblCowProductCount.AutoSize = true;
            this.lblCowProductCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCowProductCount.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCowProductCount.ForeColor = System.Drawing.Color.Black;
            this.lblCowProductCount.Location = new System.Drawing.Point(158, 309);
            this.lblCowProductCount.Name = "lblCowProductCount";
            this.lblCowProductCount.Size = new System.Drawing.Size(12, 17);
            this.lblCowProductCount.TabIndex = 11;
            this.lblCowProductCount.Text = ".";
            // 
            // txtCowAge
            // 
            this.txtCowAge.Location = new System.Drawing.Point(89, 151);
            this.txtCowAge.Name = "txtCowAge";
            this.txtCowAge.Size = new System.Drawing.Size(100, 22);
            this.txtCowAge.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(3, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Depodaki Ürün Sayısı:";
            // 
            // pbCowProduction
            // 
            this.pbCowProduction.Location = new System.Drawing.Point(24, 279);
            this.pbCowProduction.Name = "pbCowProduction";
            this.pbCowProduction.Size = new System.Drawing.Size(205, 27);
            this.pbCowProduction.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(9, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ürün Süreci";
            // 
            // btnCowBuy
            // 
            this.btnCowBuy.FlatAppearance.BorderSize = 0;
            this.btnCowBuy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCowBuy.Font = new System.Drawing.Font("Comic Sans MS", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCowBuy.Image = global::StajOdeviIlk.Properties.Resources.btn;
            this.btnCowBuy.Location = new System.Drawing.Point(34, 361);
            this.btnCowBuy.Name = "btnCowBuy";
            this.btnCowBuy.Size = new System.Drawing.Size(186, 33);
            this.btnCowBuy.TabIndex = 7;
            this.btnCowBuy.Text = "Yeni Hayvan Satın Al";
            this.btnCowBuy.UseVisualStyleBackColor = true;
            this.btnCowBuy.Click += new System.EventHandler(this.btnCowBuy_Click);
            // 
            // btnCowSell
            // 
            this.btnCowSell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCowSell.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCowSell.Image = global::StajOdeviIlk.Properties.Resources.btn;
            this.btnCowSell.Location = new System.Drawing.Point(34, 328);
            this.btnCowSell.Name = "btnCowSell";
            this.btnCowSell.Size = new System.Drawing.Size(186, 29);
            this.btnCowSell.TabIndex = 6;
            this.btnCowSell.Text = "Ürünleri Sat";
            this.btnCowSell.UseVisualStyleBackColor = true;
            this.btnCowSell.Click += new System.EventHandler(this.btnCowSell_Click);
            // 
            // btnCowFeed
            // 
            this.btnCowFeed.BackColor = System.Drawing.Color.Transparent;
            this.btnCowFeed.BackgroundImage = global::StajOdeviIlk.Properties.Resources.btn;
            this.btnCowFeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCowFeed.FlatAppearance.BorderSize = 0;
            this.btnCowFeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCowFeed.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCowFeed.ForeColor = System.Drawing.Color.Black;
            this.btnCowFeed.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCowFeed.Location = new System.Drawing.Point(50, 219);
            this.btnCowFeed.Name = "btnCowFeed";
            this.btnCowFeed.Size = new System.Drawing.Size(159, 39);
            this.btnCowFeed.TabIndex = 5;
            this.btnCowFeed.Text = "Besle";
            this.btnCowFeed.UseVisualStyleBackColor = false;
            this.btnCowFeed.Click += new System.EventHandler(this.button6_Click);
            this.btnCowFeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCowFeed_MouseDown);
            this.btnCowFeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCowFeed_MouseUp);
            // 
            // cbCowGender
            // 
            this.cbCowGender.FormattingEnabled = true;
            this.cbCowGender.Location = new System.Drawing.Point(89, 183);
            this.cbCowGender.Name = "cbCowGender";
            this.cbCowGender.Size = new System.Drawing.Size(100, 24);
            this.cbCowGender.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(3, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 21);
            this.label7.TabIndex = 3;
            this.label7.Text = "Cinsiyet:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label8.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(31, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 21);
            this.label8.TabIndex = 2;
            this.label8.Text = "Yaş:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::StajOdeviIlk.Properties.Resources.inek;
            this.pictureBox2.Location = new System.Drawing.Point(15, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(228, 114);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // lblSheepProductCount
            // 
            this.lblSheepProductCount.AutoSize = true;
            this.lblSheepProductCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblSheepProductCount.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSheepProductCount.ForeColor = System.Drawing.Color.Black;
            this.lblSheepProductCount.Location = new System.Drawing.Point(158, 306);
            this.lblSheepProductCount.Name = "lblSheepProductCount";
            this.lblSheepProductCount.Size = new System.Drawing.Size(12, 17);
            this.lblSheepProductCount.TabIndex = 11;
            this.lblSheepProductCount.Text = ".";
            this.lblSheepProductCount.Click += new System.EventHandler(this.UpdateSheepProductCountLabel_Click);
            // 
            // txtSheepAge
            // 
            this.txtSheepAge.Location = new System.Drawing.Point(88, 149);
            this.txtSheepAge.Name = "txtSheepAge";
            this.txtSheepAge.Size = new System.Drawing.Size(100, 22);
            this.txtSheepAge.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(3, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Depodaki Ürün Sayısı:";
            // 
            // pbSheepProduction
            // 
            this.pbSheepProduction.Location = new System.Drawing.Point(9, 279);
            this.pbSheepProduction.Name = "pbSheepProduction";
            this.pbSheepProduction.Size = new System.Drawing.Size(205, 23);
            this.pbSheepProduction.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label10.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(6, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Ürün Süreci";
            // 
            // btnSheepBuy
            // 
            this.btnSheepBuy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSheepBuy.Font = new System.Drawing.Font("Comic Sans MS", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSheepBuy.Image = global::StajOdeviIlk.Properties.Resources.btn;
            this.btnSheepBuy.Location = new System.Drawing.Point(28, 359);
            this.btnSheepBuy.Name = "btnSheepBuy";
            this.btnSheepBuy.Size = new System.Drawing.Size(186, 33);
            this.btnSheepBuy.TabIndex = 7;
            this.btnSheepBuy.Text = "Yeni Hayvan Satın Al";
            this.btnSheepBuy.UseVisualStyleBackColor = true;
            this.btnSheepBuy.Click += new System.EventHandler(this.btnSheepBuy_Click);
            // 
            // btnSheepSell
            // 
            this.btnSheepSell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSheepSell.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSheepSell.Image = global::StajOdeviIlk.Properties.Resources.btn;
            this.btnSheepSell.Location = new System.Drawing.Point(28, 326);
            this.btnSheepSell.Name = "btnSheepSell";
            this.btnSheepSell.Size = new System.Drawing.Size(186, 27);
            this.btnSheepSell.TabIndex = 6;
            this.btnSheepSell.Text = "Ürünleri Sat";
            this.btnSheepSell.UseVisualStyleBackColor = true;
            this.btnSheepSell.Click += new System.EventHandler(this.btnSheepSell_Click);
            // 
            // cbSheepGender
            // 
            this.cbSheepGender.FormattingEnabled = true;
            this.cbSheepGender.Location = new System.Drawing.Point(88, 186);
            this.cbSheepGender.Name = "cbSheepGender";
            this.cbSheepGender.Size = new System.Drawing.Size(100, 24);
            this.cbSheepGender.TabIndex = 4;
            this.cbSheepGender.SelectedIndexChanged += new System.EventHandler(this.cbSheepGender_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label11.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(2, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 21);
            this.label11.TabIndex = 3;
            this.label11.Text = "Cinsiyet:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label12.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(20, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 21);
            this.label12.TabIndex = 2;
            this.label12.Text = "Yaş:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::StajOdeviIlk.Properties.Resources.koyun;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(253, 118);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // lblGooseProductCount
            // 
            this.lblGooseProductCount.AutoSize = true;
            this.lblGooseProductCount.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGooseProductCount.ForeColor = System.Drawing.Color.Black;
            this.lblGooseProductCount.Location = new System.Drawing.Point(166, 305);
            this.lblGooseProductCount.Name = "lblGooseProductCount";
            this.lblGooseProductCount.Size = new System.Drawing.Size(12, 17);
            this.lblGooseProductCount.TabIndex = 11;
            this.lblGooseProductCount.Text = ".";
            // 
            // txtGooseAge
            // 
            this.txtGooseAge.Location = new System.Drawing.Point(96, 145);
            this.txtGooseAge.Name = "txtGooseAge";
            this.txtGooseAge.Size = new System.Drawing.Size(100, 22);
            this.txtGooseAge.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(0, 306);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 17);
            this.label13.TabIndex = 9;
            this.label13.Text = "Depodaki Ürün Sayısı:";
            // 
            // pbGooseProduction
            // 
            this.pbGooseProduction.Location = new System.Drawing.Point(17, 279);
            this.pbGooseProduction.Name = "pbGooseProduction";
            this.pbGooseProduction.Size = new System.Drawing.Size(205, 23);
            this.pbGooseProduction.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label14.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(11, 263);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 17);
            this.label14.TabIndex = 1;
            this.label14.Text = "Ürün Süreci";
            // 
            // btnGooseBuy
            // 
            this.btnGooseBuy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGooseBuy.Font = new System.Drawing.Font("Comic Sans MS", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGooseBuy.Image = global::StajOdeviIlk.Properties.Resources.btn;
            this.btnGooseBuy.Location = new System.Drawing.Point(36, 361);
            this.btnGooseBuy.Name = "btnGooseBuy";
            this.btnGooseBuy.Size = new System.Drawing.Size(186, 33);
            this.btnGooseBuy.TabIndex = 7;
            this.btnGooseBuy.Text = "Yeni Hayvan Satın Al";
            this.btnGooseBuy.UseVisualStyleBackColor = true;
            this.btnGooseBuy.Click += new System.EventHandler(this.btnGooseBuy_Click);
            // 
            // btnGooseSell
            // 
            this.btnGooseSell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGooseSell.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGooseSell.Image = global::StajOdeviIlk.Properties.Resources.btn;
            this.btnGooseSell.Location = new System.Drawing.Point(36, 325);
            this.btnGooseSell.Name = "btnGooseSell";
            this.btnGooseSell.Size = new System.Drawing.Size(186, 27);
            this.btnGooseSell.TabIndex = 6;
            this.btnGooseSell.Text = "Ürünleri Sat";
            this.btnGooseSell.UseVisualStyleBackColor = true;
            this.btnGooseSell.Click += new System.EventHandler(this.btnGooseSell_Click);
            // 
            // cbGooseGender
            // 
            this.cbGooseGender.FormattingEnabled = true;
            this.cbGooseGender.Location = new System.Drawing.Point(100, 187);
            this.cbGooseGender.Name = "cbGooseGender";
            this.cbGooseGender.Size = new System.Drawing.Size(100, 24);
            this.cbGooseGender.TabIndex = 4;
            this.cbGooseGender.SelectedIndexChanged += new System.EventHandler(this.cbGooseGender_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label15.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(13, 190);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 21);
            this.label15.TabIndex = 3;
            this.label15.Text = "Cinsiyet:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label16.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(37, 148);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 21);
            this.label16.TabIndex = 2;
            this.label16.Text = "Yaş:";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::StajOdeviIlk.Properties.Resources.kaz;
            this.pictureBox4.Location = new System.Drawing.Point(3, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(253, 118);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Font = new System.Drawing.Font("Franklin Gothic Medium", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblCash.Location = new System.Drawing.Point(231, 82);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(23, 36);
            this.lblCash.TabIndex = 1;
            this.lblCash.Text = ".";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label17.Font = new System.Drawing.Font("Franklin Gothic Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(241, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(175, 29);
            this.label17.TabIndex = 0;
            this.label17.Text = "Kasadaki Para:";
            // 
            // istatistikbtn
            // 
            this.istatistikbtn.FlatAppearance.BorderSize = 2;
            this.istatistikbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.istatistikbtn.Font = new System.Drawing.Font("Comic Sans MS", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.istatistikbtn.Image = global::StajOdeviIlk.Properties.Resources.btn;
            this.istatistikbtn.Location = new System.Drawing.Point(632, 471);
            this.istatistikbtn.Name = "istatistikbtn";
            this.istatistikbtn.Size = new System.Drawing.Size(378, 98);
            this.istatistikbtn.TabIndex = 15;
            this.istatistikbtn.Text = "İstatistikleri Gör";
            this.istatistikbtn.UseVisualStyleBackColor = true;
            this.istatistikbtn.Click += new System.EventHandler(this.button13_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtChickenAge);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.chickenPrice);
            this.panel1.Controls.Add(this.lblChickenProductCount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblChickenTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbChickenGender);
            this.panel1.Controls.Add(this.pbChickenProduction);
            this.panel1.Controls.Add(this.btnChickenFeed);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnChickenSell);
            this.panel1.Controls.Add(this.btnChickenBuy);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 415);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.lblCowProductCount);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.txtCowAge);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.pbCowProduction);
            this.panel2.Controls.Add(this.cbCowGender);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnCowBuy);
            this.panel2.Controls.Add(this.btnCowFeed);
            this.panel2.Controls.Add(this.btnCowSell);
            this.panel2.Location = new System.Drawing.Point(283, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 414);
            this.panel2.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(109, 126);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(134, 20);
            this.label18.TabIndex = 14;
            this.label18.Text = "İnek Ücreti:100₺";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label19.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(20, 128);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 20);
            this.label19.TabIndex = 13;
            this.label19.Text = "Süt:10₺";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.lblSheepProductCount);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.txtSheepAge);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.pbSheepProduction);
            this.panel3.Controls.Add(this.cbSheepGender);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.btnSheepWool);
            this.panel3.Controls.Add(this.btnSheepBuy);
            this.panel3.Controls.Add(this.btnSheepSell);
            this.panel3.Location = new System.Drawing.Point(570, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(263, 414);
            this.panel3.TabIndex = 12;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label20.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(105, 124);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(136, 20);
            this.label20.TabIndex = 14;
            this.label20.Text = "Koyun Ücreti:80₺";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label21.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(39, 124);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 20);
            this.label21.TabIndex = 13;
            this.label21.Text = "Yün:15₺";
            // 
            // btnSheepWool
            // 
            this.btnSheepWool.BackgroundImage = global::StajOdeviIlk.Properties.Resources.btn;
            this.btnSheepWool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSheepWool.FlatAppearance.BorderSize = 0;
            this.btnSheepWool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSheepWool.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSheepWool.Location = new System.Drawing.Point(44, 217);
            this.btnSheepWool.Name = "btnSheepWool";
            this.btnSheepWool.Size = new System.Drawing.Size(170, 41);
            this.btnSheepWool.TabIndex = 5;
            this.btnSheepWool.Text = "Besle";
            this.btnSheepWool.UseVisualStyleBackColor = true;
            this.btnSheepWool.Click += new System.EventHandler(this.btnSheepWool_Click);
            this.btnSheepWool.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSheepWool_MouseDown);
            this.btnSheepWool.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSheepWool_MouseUp);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.lblGooseProductCount);
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Controls.Add(this.txtGooseAge);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.pbGooseProduction);
            this.panel4.Controls.Add(this.cbGooseGender);
            this.panel4.Controls.Add(this.btnGooseFeed);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.btnGooseBuy);
            this.panel4.Controls.Add(this.btnGooseSell);
            this.panel4.Location = new System.Drawing.Point(840, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(263, 414);
            this.panel4.TabIndex = 17;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(117, 126);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(118, 20);
            this.label22.TabIndex = 14;
            this.label22.Text = "Kaz Ücreti:90₺";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(17, 126);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(57, 20);
            this.label23.TabIndex = 13;
            this.label23.Text = "Tüy:5₺";
            // 
            // btnGooseFeed
            // 
            this.btnGooseFeed.BackgroundImage = global::StajOdeviIlk.Properties.Resources.btn;
            this.btnGooseFeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGooseFeed.FlatAppearance.BorderSize = 0;
            this.btnGooseFeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGooseFeed.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGooseFeed.Location = new System.Drawing.Point(52, 217);
            this.btnGooseFeed.Name = "btnGooseFeed";
            this.btnGooseFeed.Size = new System.Drawing.Size(170, 43);
            this.btnGooseFeed.TabIndex = 5;
            this.btnGooseFeed.Text = "Besle";
            this.btnGooseFeed.UseVisualStyleBackColor = true;
            this.btnGooseFeed.Click += new System.EventHandler(this.btnGooseFeed_Click);
            this.btnGooseFeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnGooseFeed_MouseDown);
            this.btnGooseFeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnGooseFeed_MouseUp);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.pictureBox5);
            this.panel5.Controls.Add(this.lblCash);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Location = new System.Drawing.Point(12, 433);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(493, 173);
            this.panel5.TabIndex = 2;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::StajOdeviIlk.Properties.Resources.kasax;
            this.pictureBox5.Location = new System.Drawing.Point(-10, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(222, 163);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1115, 623);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.istatistikbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hayvan Çiftliği";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

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

