namespace StajOdeviIlkNet8
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            dataGridViewStatistics = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStatistics).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStatistics
            // 
            dataGridViewStatistics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStatistics.Location = new Point(12, 91);
            dataGridViewStatistics.Margin = new Padding(3, 4, 3, 4);
            dataGridViewStatistics.Name = "dataGridViewStatistics";
            dataGridViewStatistics.RowHeadersWidth = 51;
            dataGridViewStatistics.RowTemplate.Height = 24;
            dataGridViewStatistics.Size = new Size(1091, 180);
            dataGridViewStatistics.TabIndex = 0;
            dataGridViewStatistics.CellContentClick += dataGridViewStatistics_CellContentClick;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.arkaplan;
            ClientSize = new Size(1115, 385);
            Controls.Add(dataGridViewStatistics);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "StatisticsForm";
            Text = "İstatistikler";
            Load += StatisticsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStatistics).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStatistics;
    }
}