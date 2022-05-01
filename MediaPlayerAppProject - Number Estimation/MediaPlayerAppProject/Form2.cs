using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using Microsoft.VisualBasic;

namespace MediaPlayerAppProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            backgroundMuzigi();
        }
        readonly Random rastgelesayi = new Random(); // rastgelesayi'yi hic degismeyip sadece okuyacagim icin readonly yaptim.
        byte hataSayisi = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            byte dogrutahminSayisi = 0, yanlistahminSayisi = 0;
            label6.Text = dogrutahminSayisi.ToString(); //butona her tiklandiginda tahmin sayilari sifirlansin
            label9.Text = yanlistahminSayisi.ToString();//butona her tiklandiginda tahmin sayilari sifirlansin
            label7.Text = "0";                          //butona her tiklandiginda puan sifirlansin
            listBox1.Items.Clear();
            listBox2.Items.Clear();                     //butona her listbox'lar temizlensin
            try                                         //hata olabilecek kisimlari try icine aldim
            {
                int kacRandom = int.Parse(textBox1.Text);
                if (kacRandom > 10 || kacRandom < 1)     //random sayi belirtilen aralikta olmaz ise..
                {
                    MessageBox.Show("Lutfen 1-10 arasinda sayi giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);// hata mesaji
                    hataSayisi++;                        // hatayi artirdim
                    label8.Text = hataSayisi.ToString(); //hatayi ekrana yazdirdim
                    if (hataSayisi == 3)                 //her hata artirildiginda kontrol etmek lazim
                    {
                        alertPlayer.URL = string.Format("{0}Resources\\alert.wav", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));//hata muzigi konumu
                        alertPlayer.controls.play();                                                                                       //muzigi oynat
                        MessageBox.Show("3 Kez Hatali Girdiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();                         //Programdan tamamen cikmak degil de, Ana menuye atmak icin (Form2).Close kullandim.
                        
                    }
                }
                else if (kacRandom <= 10 || kacRandom >= 1)   //Eger belirtilen aralikta ise..
                {
                    for (int i = 0; i < kacRandom;)           // for dongusunde i'yi istenilen sayiya kadar donduruyoruz, artirma islemini altta yapicam
                    {
                        try//inputboxlara harf girilirse catchden dolayi dongu bitmek yerine dongu icinde hata yakalayip donguyu devam ettirebiliriz.
                        {
                            int pcrastgele = rastgelesayi.Next(1, 11); //her seferinde farkli random uretilebilmesi icin kodu dongu icinde yazdim.
                            int kullaniciRandom = int.Parse(Interaction.InputBox("Tahmininiz : ", "Tahmin Oyunu", "Buraya Yaziniz..", 600, 180));
                            if (kullaniciRandom > 10 || kullaniciRandom < 1) //inputbox icine girilen sayi 1-10 arasinda degilse
                            {
                                alertPlayer.URL = string.Format("{0}Resources\\alert.wav", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));//hata muzigi konumu
                                alertPlayer.controls.play();                                                                                       //muzigi oynat
                                MessageBox.Show("Lutfen 1-10 arasinda sayi giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                hataSayisi++;//hata sayisi artirildi
                                label8.Text = hataSayisi.ToString();// hata sayisini ekrana yazdirdim
                                if (hataSayisi == 3)//fazladan islem yapilmamasi icin her hata artirildiginda hatayi kontrol edip hata 3 oldugunda bitirmek lazim
                                {
                                    alertPlayer.URL = string.Format("{0}Resources\\alert.wav", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));//hata muzigi konumu
                                    alertPlayer.controls.play();                                                                                       //muzigi oynat
                                    MessageBox.Show("3 Kez Hatali Girdiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);//Tum kosullarin disinda hata kontrolu yaptim
                                    Close();        //Programdan tamamen cikmak degil de, Ana menuye atmak icin (Form2).Close kullandim.
                                    break;          //form2 kapandiktan sonra inputbox istemeye devam etmesin
                                }

                            }
                            else//inputbox icine girilen sayi 1-10 arasindaysa
                            {
                                if (kullaniciRandom == pcrastgele)//eger tahmin dogruysa
                                {
                                    winPlayer.URL = string.Format("{0}Resources\\win.wav", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));//win sesi konumunu belirttim
                                    winPlayer.controls.play();                                                                                     //muzigi oynat
                                    dogrutahminSayisi++;                                                                                           //dogru tahmin sayisi artirildi
                                    MessageBox.Show("Tebrikler Buldunuz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    listBox1.Items.Add("PC : " + pcrastgele);   //Pc tahminini listbox'a yazdirdim 
                                    listBox2.Items.Add("Sen" + kullaniciRandom);//Girilen tahmini ikinci listbox'a yazdirdim
                                    label6.Text = dogrutahminSayisi.ToString();//artirilan dogru tahmin sayisini ekrana yazdirdim
                                    label7.Text = (dogrutahminSayisi * 10).ToString();//puani artirilan dogru tahmin sayisini 10 ile carparak hesapladim
                                    i++; //artik i'yi artirabilirim
                                }
                                else if (kullaniciRandom != pcrastgele)
                                {
                                    alertPlayer.URL = string.Format("{0}Resources\\alert.wav", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));//hata sesi konumunu belirttim
                                    alertPlayer.controls.play();                                                                                       //sesi oynat
                                    yanlistahminSayisi++;
                                    listBox1.Items.Add("PC : " + pcrastgele);       //Pc tahminini listbox'a yazdirdim 
                                    listBox2.Items.Add("Sen : " + kullaniciRandom); //Girilen tahmini ikinci listbox'a yazdirdim
                                    label9.Text = yanlistahminSayisi.ToString(); //yanlis tahmin sayisini ekrana yazdirdim.
                                    i++;//for'un i'sini artirdim

                                }
                            }
                        }
                        catch
                        {
                            hataSayisi++;
                            label8.Text = hataSayisi.ToString();// hata sayisini ekrana yazdirdim
                            MessageBox.Show("Harf Girilmez", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (hataSayisi == 3)                 //her hata artirildiginda kontrol etmek lazim
                            {
                                alertPlayer.URL = string.Format("{0}Resources\\alert.wav", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));//hata muzigi konumu
                                alertPlayer.controls.play();                                                                                       //muzigi oynat
                                MessageBox.Show("3 Kez Hatali Girdiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Close();                         //Programdan tamamen cikmak degil de, Ana menuye atmak icin (Form2).Close kullandim.
                                break;                           //form2 kapanip menuye gidildiginde for donmeye devam edip inputbox istemesin
                            }
                        }
                    }
                }
            }
            catch (Exception)//yanlislikla harf veya bosluk girilirse uyari verdim ama hatayi arttirmadim
            {
                hataSayisi++;
                label8.Text = hataSayisi.ToString();// hata sayisini ekrana yazdirdim
                MessageBox.Show("Harf Girilmez", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (hataSayisi == 3)                 //her hata artirildiginda kontrol etmek lazim
                {
                    alertPlayer.URL = string.Format("{0}Resources\\alert.wav", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));//hata muzigi konumu
                    alertPlayer.controls.play();                                                                                       //muzigi oynat
                    MessageBox.Show("3 Kez Hatali Girdiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)//programdan cikilmak istenirse
        {
            Form1 frm = new Form1();//form1'e frm adinda degisken ile eristim
            wplayer.controls.pause();//bu formun muzigini kapattim
            frm.Show();              //form1'i actim
        }
        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();//wplayer arkaplan muzigi icin olusturtuldu
        WindowsMediaPlayer winPlayer = new WindowsMediaPlayer();//dogru tahmin sesi icin olusturuldu
        WindowsMediaPlayer alertPlayer = new WindowsMediaPlayer();//yanlis tahmin ve uyarilan icin olusturuldu
        string RunningPath = AppDomain.CurrentDomain.BaseDirectory;//resources konumuna erisebilmei icin oldugum konumu buldum 
        public void backgroundMuzigi()
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;//muzige eriebilmek icin kendi konumumu ogrendim
            wplayer.URL = string.Format("{0}Resources\\deflector.mp3", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));//muzigin konumunu belirttim
            wplayer.settings.setMode("loop", true);//arkaplan muzigi bitmesin 
            wplayer.controls.play();               //muzigi baslattim
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Select();//form2 yuklendiginde 
        }
    }
}
