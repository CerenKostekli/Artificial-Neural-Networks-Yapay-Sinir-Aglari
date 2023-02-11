namespace Yapay_Sinir_Aglari
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
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

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.noron_sayisi = new System.Windows.Forms.TextBox();
            this.egitim_hizi = new System.Windows.Forms.TextBox();
            this.epok_sayisi = new System.Windows.Forms.TextBox();
            this.giris_dosyasi = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cikis_dosyasi = new System.Windows.Forms.Button();
            this.egitim_orani = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.hesaplama_butonu = new System.Windows.Forms.Button();
            this.Giris_Noron_AgirlikDegerleri = new System.Windows.Forms.ListBox();
            this.Noron_Cikis_AgirlikDegerleri = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_test = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // noron_sayisi
            // 
            this.noron_sayisi.Location = new System.Drawing.Point(134, 342);
            this.noron_sayisi.Name = "noron_sayisi";
            this.noron_sayisi.Size = new System.Drawing.Size(87, 20);
            this.noron_sayisi.TabIndex = 0;
            // 
            // egitim_hizi
            // 
            this.egitim_hizi.Location = new System.Drawing.Point(134, 377);
            this.egitim_hizi.Name = "egitim_hizi";
            this.egitim_hizi.Size = new System.Drawing.Size(87, 20);
            this.egitim_hizi.TabIndex = 1;
            // 
            // epok_sayisi
            // 
            this.epok_sayisi.Location = new System.Drawing.Point(134, 411);
            this.epok_sayisi.Name = "epok_sayisi";
            this.epok_sayisi.Size = new System.Drawing.Size(87, 20);
            this.epok_sayisi.TabIndex = 2;
            // 
            // giris_dosyasi
            // 
            this.giris_dosyasi.BackColor = System.Drawing.SystemColors.Info;
            this.giris_dosyasi.Location = new System.Drawing.Point(252, 345);
            this.giris_dosyasi.Name = "giris_dosyasi";
            this.giris_dosyasi.Size = new System.Drawing.Size(127, 23);
            this.giris_dosyasi.TabIndex = 3;
            this.giris_dosyasi.Text = "Giriş Dosyası Seç";
            this.giris_dosyasi.UseVisualStyleBackColor = false;
            this.giris_dosyasi.Click += new System.EventHandler(this.giris_dosyasi_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cikis_dosyasi
            // 
            this.cikis_dosyasi.BackColor = System.Drawing.SystemColors.Info;
            this.cikis_dosyasi.Location = new System.Drawing.Point(252, 374);
            this.cikis_dosyasi.Name = "cikis_dosyasi";
            this.cikis_dosyasi.Size = new System.Drawing.Size(127, 23);
            this.cikis_dosyasi.TabIndex = 4;
            this.cikis_dosyasi.Text = "Çıkış Dosyası Seç";
            this.cikis_dosyasi.UseVisualStyleBackColor = false;
            this.cikis_dosyasi.Click += new System.EventHandler(this.cikis_dosyasi_Click);
            // 
            // egitim_orani
            // 
            this.egitim_orani.Location = new System.Drawing.Point(134, 446);
            this.egitim_orani.Name = "egitim_orani";
            this.egitim_orani.Size = new System.Drawing.Size(87, 20);
            this.egitim_orani.TabIndex = 5;
            this.egitim_orani.TextChanged += new System.EventHandler(this.egitim_orani_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Noron Sayısı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Eğitim Hızı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Epok Sayısı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Eğirim Oranı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 485);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Test Oranı:";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Navy;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(446, 301);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // hesaplama_butonu
            // 
            this.hesaplama_butonu.BackColor = System.Drawing.SystemColors.Window;
            this.hesaplama_butonu.Location = new System.Drawing.Point(279, 413);
            this.hesaplama_butonu.Name = "hesaplama_butonu";
            this.hesaplama_butonu.Size = new System.Drawing.Size(75, 23);
            this.hesaplama_butonu.TabIndex = 13;
            this.hesaplama_butonu.Text = "Hesapla";
            this.hesaplama_butonu.UseVisualStyleBackColor = false;
            this.hesaplama_butonu.Click += new System.EventHandler(this.hesaplama_butonu_Click);
            // 
            // Giris_Noron_AgirlikDegerleri
            // 
            this.Giris_Noron_AgirlikDegerleri.FormattingEnabled = true;
            this.Giris_Noron_AgirlikDegerleri.Location = new System.Drawing.Point(470, 28);
            this.Giris_Noron_AgirlikDegerleri.Name = "Giris_Noron_AgirlikDegerleri";
            this.Giris_Noron_AgirlikDegerleri.Size = new System.Drawing.Size(156, 537);
            this.Giris_Noron_AgirlikDegerleri.TabIndex = 15;
            // 
            // Noron_Cikis_AgirlikDegerleri
            // 
            this.Noron_Cikis_AgirlikDegerleri.FormattingEnabled = true;
            this.Noron_Cikis_AgirlikDegerleri.Location = new System.Drawing.Point(643, 28);
            this.Noron_Cikis_AgirlikDegerleri.Name = "Noron_Cikis_AgirlikDegerleri";
            this.Noron_Cikis_AgirlikDegerleri.Size = new System.Drawing.Size(154, 537);
            this.Noron_Cikis_AgirlikDegerleri.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 565);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(479, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Giriş -Nöron Ağırlık Değerleri";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(653, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Nöron-Çıkış Ağırlık Değerleri";
            // 
            // label_test
            // 
            this.label_test.AutoSize = true;
            this.label_test.Location = new System.Drawing.Point(131, 485);
            this.label_test.Name = "label_test";
            this.label_test.Size = new System.Drawing.Size(10, 13);
            this.label_test.TabIndex = 20;
            this.label_test.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(809, 602);
            this.Controls.Add(this.label_test);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Noron_Cikis_AgirlikDegerleri);
            this.Controls.Add(this.Giris_Noron_AgirlikDegerleri);
            this.Controls.Add(this.hesaplama_butonu);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.egitim_orani);
            this.Controls.Add(this.cikis_dosyasi);
            this.Controls.Add(this.giris_dosyasi);
            this.Controls.Add(this.epok_sayisi);
            this.Controls.Add(this.egitim_hizi);
            this.Controls.Add(this.noron_sayisi);
            this.Name = "Form1";
            this.Text = "Yapay Sinir Ağları";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox noron_sayisi;
        private System.Windows.Forms.TextBox egitim_hizi;
        private System.Windows.Forms.TextBox epok_sayisi;
        private System.Windows.Forms.Button giris_dosyasi;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button cikis_dosyasi;
        private System.Windows.Forms.TextBox egitim_orani;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button hesaplama_butonu;
        private System.Windows.Forms.ListBox Giris_Noron_AgirlikDegerleri;
        private System.Windows.Forms.ListBox Noron_Cikis_AgirlikDegerleri;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_test;
    }
}

