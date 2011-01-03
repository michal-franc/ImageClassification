namespace ImageClassyfication
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnCorrelation = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.chartDistribution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBoxGeneratorType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxIloscProb = new System.Windows.Forms.TextBox();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxIloscWekt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxP2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxP1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxB2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxB1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxA2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxA1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxIloscTestowychProbek = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartDistribution)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCorrelation
            // 
            this.btnCorrelation.Location = new System.Drawing.Point(131, 212);
            this.btnCorrelation.Name = "btnCorrelation";
            this.btnCorrelation.Size = new System.Drawing.Size(75, 23);
            this.btnCorrelation.TabIndex = 0;
            this.btnCorrelation.Text = "Correlation";
            this.btnCorrelation.UseVisualStyleBackColor = true;
            this.btnCorrelation.Click += new System.EventHandler(this.btnCorrelation_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(6, 212);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // chartDistribution
            // 
            chartArea12.Name = "ChartArea1";
            this.chartDistribution.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.chartDistribution.Legends.Add(legend12);
            this.chartDistribution.Location = new System.Drawing.Point(6, 2);
            this.chartDistribution.Name = "chartDistribution";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.chartDistribution.Series.Add(series12);
            this.chartDistribution.Size = new System.Drawing.Size(603, 207);
            this.chartDistribution.TabIndex = 3;
            this.chartDistribution.Text = "chart1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(923, 285);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.textBoxIloscTestowychProbek);
            this.tabPage1.Controls.Add(this.comboBoxGeneratorType);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.textBoxIloscProb);
            this.tabPage1.Controls.Add(this.textBoxData);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.textBoxIloscWekt);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBoxP2);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.textBoxP1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBoxB2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBoxB1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBoxA2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxA1);
            this.tabPage1.Controls.Add(this.chartDistribution);
            this.tabPage1.Controls.Add(this.btnCalculate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(915, 259);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBoxGeneratorType
            // 
            this.comboBoxGeneratorType.FormattingEnabled = true;
            this.comboBoxGeneratorType.Items.AddRange(new object[] {
            "Normal",
            "Uniform"});
            this.comboBoxGeneratorType.Location = new System.Drawing.Point(6, 236);
            this.comboBoxGeneratorType.Name = "comboBoxGeneratorType";
            this.comboBoxGeneratorType.Size = new System.Drawing.Size(75, 21);
            this.comboBoxGeneratorType.TabIndex = 27;
            this.comboBoxGeneratorType.Text = "Uniform";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "ilosc prob";
            // 
            // textBoxIloscProb
            // 
            this.textBoxIloscProb.Location = new System.Drawing.Point(329, 223);
            this.textBoxIloscProb.Name = "textBoxIloscProb";
            this.textBoxIloscProb.Size = new System.Drawing.Size(53, 20);
            this.textBoxIloscProb.TabIndex = 25;
            this.textBoxIloscProb.Text = "1";
            // 
            // textBoxData
            // 
            this.textBoxData.Location = new System.Drawing.Point(641, 20);
            this.textBoxData.Multiline = true;
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(263, 194);
            this.textBoxData.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "n. wektorow";
            // 
            // textBoxIloscWekt
            // 
            this.textBoxIloscWekt.Location = new System.Drawing.Point(258, 222);
            this.textBoxIloscWekt.Name = "textBoxIloscWekt";
            this.textBoxIloscWekt.Size = new System.Drawing.Size(65, 20);
            this.textBoxIloscWekt.TabIndex = 22;
            this.textBoxIloscWekt.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "p2";
            // 
            // textBoxP2
            // 
            this.textBoxP2.Location = new System.Drawing.Point(224, 223);
            this.textBoxP2.Name = "textBoxP2";
            this.textBoxP2.Size = new System.Drawing.Size(23, 20);
            this.textBoxP2.TabIndex = 20;
            this.textBoxP2.Text = "0.6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "p1";
            // 
            // textBoxP1
            // 
            this.textBoxP1.Location = new System.Drawing.Point(196, 223);
            this.textBoxP1.Name = "textBoxP1";
            this.textBoxP1.Size = new System.Drawing.Size(23, 20);
            this.textBoxP1.TabIndex = 18;
            this.textBoxP1.Text = "0.4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "b2";
            // 
            // textBoxB2
            // 
            this.textBoxB2.Location = new System.Drawing.Point(168, 223);
            this.textBoxB2.Name = "textBoxB2";
            this.textBoxB2.Size = new System.Drawing.Size(23, 20);
            this.textBoxB2.TabIndex = 16;
            this.textBoxB2.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "b1";
            // 
            // textBoxB1
            // 
            this.textBoxB1.Location = new System.Drawing.Point(140, 223);
            this.textBoxB1.Name = "textBoxB1";
            this.textBoxB1.Size = new System.Drawing.Size(23, 20);
            this.textBoxB1.TabIndex = 14;
            this.textBoxB1.Text = "31";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "a2";
            // 
            // textBoxA2
            // 
            this.textBoxA2.Location = new System.Drawing.Point(115, 223);
            this.textBoxA2.Name = "textBoxA2";
            this.textBoxA2.Size = new System.Drawing.Size(23, 20);
            this.textBoxA2.TabIndex = 12;
            this.textBoxA2.Text = "30";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "a1";
            // 
            // textBoxA1
            // 
            this.textBoxA1.Location = new System.Drawing.Point(87, 223);
            this.textBoxA1.Name = "textBoxA1";
            this.textBoxA1.Size = new System.Drawing.Size(23, 20);
            this.textBoxA1.TabIndex = 4;
            this.textBoxA1.Text = "0";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.btnCorrelation);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(915, 259);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(388, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Ilosc testowych probek";
            // 
            // textBoxIloscTestowychProbek
            // 
            this.textBoxIloscTestowychProbek.Location = new System.Drawing.Point(387, 223);
            this.textBoxIloscTestowychProbek.Name = "textBoxIloscTestowychProbek";
            this.textBoxIloscTestowychProbek.Size = new System.Drawing.Size(53, 20);
            this.textBoxIloscTestowychProbek.TabIndex = 28;
            this.textBoxIloscTestowychProbek.Text = "100";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(18, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 139);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(234, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(154, 139);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(464, 34);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(154, 139);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 330);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartDistribution)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCorrelation;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDistribution;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxA1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxA2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxB2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxB1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxP2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxP1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxIloscWekt;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxIloscProb;
        private System.Windows.Forms.ComboBox comboBoxGeneratorType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxIloscTestowychProbek;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

