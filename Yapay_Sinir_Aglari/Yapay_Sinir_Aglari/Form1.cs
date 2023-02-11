using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Yapay_Sinir_Aglari
{
    public partial class Form1 : Form
    {
        public string giris_adres, cikis_adres;
        public static Int32 giris_satir_sayisi, giris_sutun_sayisi, noron, egitim_orani_, test_orani_, test_sayisi, epok_degeri, gsatir, gsutun, target, i, j, a, b, c, e, t, y, x,f,g, egitim_sayisi;
        public double[,] giris_degerleri = new double[giris_sutun_sayisi, giris_satir_sayisi];
        public double[] cikis_degerleri = new double[giris_satir_sayisi];
        public double[] Fonksiyon = new double[test_sayisi];
        public Int32[] x1 = new Int32[egitim_sayisi];
        public Int32[] x2 = new Int32[test_sayisi];
        byte lojik1 = 0;

        double egitim_hizi_;
        double[,] agarlik_deger1 = new double[noron, giris_sutun_sayisi]; //giriş ve nöron arasındaki ağırlık değerleri.
        double[] agarlik_deger2 = new double[noron]; // nöron ve çıkış arasındaki ağırılık değerleri.
        double islem1, islem2;//Ağırlık ve giriş çarpımını değerleri hesaplamak için, ağırılık ve çıkış arasındaki çaprımı hesaplamak için.
        double[,] noron_islem = new double[noron, egitim_sayisi]; //Sigmoid fonksiyonuna girecek olan değer.
        double[] cikis_islem = new double[noron]; // çıkışta elde edilen değer ve bu değerin lineer fonksiyondan geçmiş hali.
        double[] hata_terimi1 = new double[egitim_sayisi]; //nöron ve çıkış arasındaki ağırlıkların hata terimi.
        double[,] hata_terimi2 = new double[noron, egitim_sayisi]; // nöron ve giriş arasındaki ağırlıkların hata terimi
        double[,] delta1 = new double[noron, egitim_sayisi]; //nöron ve çıkış arasındaki ağırlıkların hata formülü
        double[,,] delta2 = new double[noron, giris_sutun_sayisi, egitim_sayisi]; // nöron ve giriş arasındaki ağırlıkların ağırlıkların hata formülü

        public Form1()
        {
            InitializeComponent();
        }
        private void Excel_Giris()
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(giris_adres);
            ws = wb.Worksheets[1];
            gsutun = 1;
            gsatir = 2;
            while (giris_satir_sayisi < gsatir)
            {
                if (Convert.ToString(ws.Cells[gsatir, 1].Value) != null)
                {
                    giris_satir_sayisi++;
                }
                else if (Convert.ToString(ws.Cells[gsatir, 1].Value) == null)
                {
                    break;
                }
                gsatir++;
            }
            while (giris_sutun_sayisi < gsutun)
            {
                if (Convert.ToString(ws.Cells[1, gsutun].Value) != null)
                {
                    giris_sutun_sayisi++;
                }
                else if(Convert.ToString(ws.Cells[1, gsutun].Value) == null)
                {
                    break;
                }
                gsutun++;
            }
            f = 0;
            g = 0;
            giris_degerleri = new double[giris_sutun_sayisi, giris_satir_sayisi];
            for (x = 1; x < giris_sutun_sayisi; x++)
            {
                g = 0;
                for (y = 2; y < giris_satir_sayisi; y++)
                { 
                    giris_degerleri[f,g] = Convert.ToDouble(ws.Cells[y, x].Value);
                    g++;
                }
                f++;
            }
        }
        private void giris_dosyasi_Click(object sender, EventArgs e)
        {
            OpenFileDialog giris = new OpenFileDialog();
            giris.Filter = "Excel Dosyası | *.xls; *.xlsx; *.xlsm";
            giris.FilterIndex = 1;
            giris.ShowDialog();
            giris_adres = giris.FileName;
        }
        private void Excel_Cikis()
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(cikis_adres);
            ws = wb.Worksheets[1];
            Int32 xj = 1;
            cikis_degerleri = new double[giris_satir_sayisi];
            for (int x = 0; x <giris_satir_sayisi; x++)
            {
                xj = x + 2;
                cikis_degerleri[x] = Convert.ToDouble(ws.Cells[xj, 1].Value);
            }
        }
        private void cikis_dosyasi_Click(object sender, EventArgs e)
        {
            OpenFileDialog cikis = new OpenFileDialog();
            cikis.Filter = "Excel Dosyası | *.xls; *.xlsx; *.xlsm";
            cikis.FilterIndex = 1;
            cikis.ShowDialog();
            cikis_adres = cikis.FileName;
        }

        private void hesaplama_butonu_Click(object sender, EventArgs e)
        {
            egitim_hesaplama();
            test_hesaplama();
            for (j = 0; j < giris_sutun_sayisi; j++)
            {
                for (i = 0; i < noron; i++)
                {
                    Giris_Noron_AgirlikDegerleri.Items.Add(agarlik_deger1[i, j]);
                    Noron_Cikis_AgirlikDegerleri.Items.Add(agarlik_deger2[i]);
                }
            }
            for (c = 0; c < test_sayisi; c++)
            {
                chart1.Series[1].Points.AddXY(cikis_islem[c], cikis_degerleri[x2[c]]);
                chart1.Series[0].Points.AddXY(c, Fonksiyon[c]);
            }
        }
        private void egitim_orani_TextChanged(object sender, EventArgs e)
        {
            try { label_test.Text = Convert.ToString(100 - Convert.ToInt32(egitim_orani.Text)); }
            catch (System.FormatException) { label_test.Text = "100"; }
        }
        public void deger_okuma()
        {
            noron = Convert.ToInt32(noron_sayisi.Text);
            egitim_orani_ = Convert.ToInt32(egitim_orani.Text);
            test_orani_ = 100 - egitim_orani_;
            egitim_hizi_ = Convert.ToDouble(egitim_hizi.Text);
            epok_degeri = Convert.ToInt32(epok_sayisi.Text);
            agarlik_deger1 = new double[noron, giris_sutun_sayisi]; //giriş ve nöron arasındaki ağırlık değerleri.
            agarlik_deger2 = new double[noron]; // nöron ve çıkış arasındaki ağırılık değerleri.
        }
        public void egitim_hesaplama()
        {

            Excel_Giris();
            Excel_Cikis();
            deger_okuma();
            egitim_sayisi = (giris_satir_sayisi * egitim_orani_) / 100; // eğitim oranı hesabı.
            x1 = new Int32[egitim_sayisi];
            noron_islem = new double[noron, egitim_sayisi]; //Sigmoid fonksiyonuna girecek olan değer.
            hata_terimi1 = new double[egitim_sayisi]; //nöron ve çıkış arasındaki ağırlıkların hata terimi.
            hata_terimi2 = new double[noron, egitim_sayisi]; // nöron ve giriş arasındaki ağırlıkların hata terimi
            cikis_islem = new double[egitim_sayisi]; // çıkışta elde edilen değer ve bu değerin lineer fonksiyondan geçmiş hali.
            delta1 = new double[noron, egitim_sayisi]; //nöron ve çıkış arasındaki ağırlıkların hata formülü
            delta2 = new double[noron, giris_sutun_sayisi, egitim_sayisi]; // nöron ve giriş arasındaki ağırlıkların ağırlıkların hata formülü

            Array.Clear(noron_islem, 0, noron_islem.Length);
            Array.Clear(cikis_islem, 0, cikis_islem.Length);
            for (int i = 0; i < epok_degeri; i++)
            {
                switch (lojik1)
                {
                    case 0:
                        Random rnd_agirlik1 = new Random();
                        Random rnd_agirlik2 = new Random();
                        Random rnd_egitim = new Random(); //eğitim oranına göre rastgele satır değeri alma
                        for (j = 0; j < giris_sutun_sayisi; j++)
                        {
                            for (i = 0; i < noron; i++)
                            {
                                agarlik_deger1[i, j] = rnd_agirlik1.Next(-5, 5); //başlangıçta giriş ve nöron arasındaki rastgele ağırlık değeri hesabı
                                agarlik_deger2[i] = rnd_agirlik2.Next(-5, 5); //başlangıçta nöron ve çıkış arasındaki rastgele ağırlık değeri hesabı
                            }
                        }
                        for (c = 0; c < egitim_sayisi; c++)
                        {
                            Int32 egitime_girecek_deger = rnd_egitim.Next(0, (giris_satir_sayisi - 1));
                            bool lojik3= Array.Exists(x1, x => x == egitime_girecek_deger);
                            if (lojik3 == false)
                            {
                                x1[c] = egitime_girecek_deger;
                            }
                            else if (lojik3 == true)
                            {
                                c--;
                            }
                        }
                        lojik1++;
                        break;
                }
                for (c = 0; c < egitim_sayisi; c++)
                {
                    j = 0;
                    for (y = 0; y < giris_sutun_sayisi; y++)
                    {
                        for (i = 0; i < noron; i++)
                        {
                            islem1 = Convert.ToDouble(agarlik_deger1[i, j] * giris_degerleri[y, x1[c]]);
                            noron_islem[i, c] = noron_islem[i, c] + islem1;
                        }
                        j++;
                    }
                }

                for (c = 0; c < egitim_sayisi; c++)
                {
                    for (i = 0; i < noron; i++)
                    {
                        noron_islem[i, c] = Convert.ToDouble(1 / (1 + Math.Exp(noron_islem[i, c]))); //sigmoid fonkisyon
                        if (noron_islem[i, c] >= 1 && noron_islem[i, c] > 0)
                        {
                            noron_islem[i, c] = 1;
                        }
                        else if (Convert.ToDouble(noron_islem[i, c]) >= 0.5 && noron_islem[i, c] < 0)
                        {
                            noron_islem[i, c] = Convert.ToDouble(0.5);
                        }
                        else if (noron_islem[i, c] <= 0)
                        {
                            noron_islem[i, c] = 0;
                        }
                        islem2 = Convert.ToDouble(noron_islem[i, c] * agarlik_deger2[i]);
                        cikis_islem[c] = cikis_islem[c] + islem2;
                    }
                    hata_terimi1[c] = Convert.ToDouble(cikis_islem[c] * (1 - cikis_islem[c]) * (cikis_degerleri[x1[c]] - cikis_islem[c]));
                }

                for (c = 0; c < egitim_sayisi; c++)
                {
                    j = 0;
                    for (y = 0; y < giris_sutun_sayisi; y++)
                    {
                        for (i = 0; i < noron; i++)
                        {
                            hata_terimi2[i, c] = Convert.ToDouble((agarlik_deger2[i] * hata_terimi1[c]) * noron_islem[i, c] * (1 - noron_islem[i, c]));
                            delta1[i, c] = Convert.ToDouble(egitim_hizi_ * hata_terimi1[c] * noron_islem[i, c]); 
                            agarlik_deger2[i] = delta1[i, c] + agarlik_deger2[i];
                            if (agarlik_deger2[i] >= 5)
                            {
                                agarlik_deger2[i] = 5;
                            }
                            else if (agarlik_deger2[i] <= -5)
                            {
                                agarlik_deger2[i] = -5;
                            }
                            delta2[i, j, c] = Convert.ToDouble(egitim_hizi_ * hata_terimi2[i, c] * giris_degerleri[y, x1[c]]);
                            agarlik_deger1[i, j] = delta2[i, j, c] + agarlik_deger1[i, j];

                            if (agarlik_deger1[i, j] >= 5)
                            {
                                agarlik_deger1[i, j] = 5;
                            }
                            else if (agarlik_deger1[i, j] <= -5)
                            {
                                agarlik_deger1[i, j] = -5;
                            }
                        }
                        j++;
                    }
                }
            }
        }
        public void test_hesaplama() 
        {
            test_sayisi = (giris_satir_sayisi - egitim_sayisi);
            x2 = new Int32[test_sayisi];
            noron_islem = new double[noron, test_sayisi];
            cikis_islem = new double[test_sayisi]; // çıkışta elde edilen değer ve bu değerin lineer fonksiyondan geçmiş hali.
            Fonksiyon = new double[test_sayisi];
            double grafik_x, toplam_x=0, grafik_y, toplam_y=0, m, n, Sxx =0, Syy=0, Sxy=0, toplam_xx, toplam_yy, toplam_xy;
            Array.Clear(noron_islem, 0, noron_islem.Length);
            t = 0;
            while ( t< test_sayisi)
            {
                for (c = 0; c < giris_satir_sayisi; c++)
                {
                    bool lojik2 = Array.Exists(x1,a=>a==c);
                    if (lojik2==false)
                    {
                            x2[t] = c;
                            t++;
                    }
                }
            }

            for (c = 0; c < test_sayisi; c++)
            {
                j = 0;
                for (y = 0; y < giris_sutun_sayisi; y++)
                {
                    for (i = 0; i < noron; i++)
                    {
                        islem1 =Convert.ToDouble( agarlik_deger1[i, j] * giris_degerleri[y, x2[c]]);
                        noron_islem[i, c] = noron_islem[i, c] + islem1;
                    }
                    j++;
                }
            }

            toplam_xx = 0; toplam_yy = 0; toplam_xy = 0;
            for (c = 0; c < test_sayisi; c++)
            {
                for (i = 0; i < noron; i++)
                {
                    noron_islem[i, c] = Convert.ToDouble( 1 / (1 + Math.Exp(noron_islem[i, c]))); //sigmoid fonkisyonu
                    if (noron_islem[i, c] >= 1 && noron_islem[i, c] > 0)
                    {
                        noron_islem[i, c] = 1;
                    }
                    else if (Convert.ToDouble(noron_islem[i, c]) >= 0.5 && noron_islem[i, c] < 0)
                    {
                        noron_islem[i, c] = Convert.ToDouble(0.5);
                    }
                    else if (noron_islem[i, c] <= 0)
                    {
                        noron_islem[i, c] = 0;
                    }
                    islem2 = Convert.ToDouble(noron_islem[i, c] * agarlik_deger2[i]);
                    cikis_islem[c] = cikis_islem[c] + islem2;
                    islem2 =Convert.ToDouble( noron_islem[i, c] * agarlik_deger2[i]);
                    cikis_islem[c] = cikis_islem[c] + islem2;
                }
                toplam_x = cikis_islem[c] + toplam_x;
                toplam_y = cikis_degerleri[x2[c]] + toplam_y;
            }

            grafik_x = Convert.ToDouble( toplam_x / test_sayisi);
            grafik_y = Convert.ToDouble(toplam_y / test_sayisi); 

            for (c = 0; c < test_sayisi; c++)
            {
                toplam_xx = (cikis_islem[c] * cikis_islem[c]) + toplam_xx;
                Sxx =Convert.ToDouble( toplam_xx - (test_sayisi*grafik_x*grafik_x));

                toplam_yy = (cikis_degerleri[x2[c]]* cikis_degerleri[x2[c]])+ toplam_yy;
                Syy = Convert.ToDouble(toplam_yy - (test_sayisi*grafik_y*grafik_y));

                toplam_xy =Convert.ToDouble( (cikis_islem[c] * cikis_degerleri[x2[c]]) +toplam_xy);
                Sxy =Convert.ToDouble( toplam_xy - (test_sayisi*grafik_x*grafik_y));
            }
            //y=mx+n
            m = Convert.ToDouble(Sxy / Sxx);
            n = Convert.ToDouble( grafik_y - (m * grafik_x));

            for (c = 0; c < test_sayisi; c++) {
                Fonksiyon[c] = Convert.ToDouble( (m * c)+ n);
            } 
        }
    }
}
