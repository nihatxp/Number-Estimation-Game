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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormOzellikleri();
            backgroundMuzigi();
        }
       
        
        private void FormOzellikleri()
        {
            FormBorderStyle = FormBorderStyle.None; //borderleri kapattim
        }
        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();//wplayer arkaplan muzigi icin olusturuldu
        private void backgroundMuzigi()
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            wplayer.URL = string.Format("{0}Resources\\alex-productions-epic-cinematic-trailer-elite.mp3", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
            wplayer.settings.setMode("loop", true);//muzik bitmesin
            wplayer.controls.play();//muzigi baslat
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();//yukarda belirttigim form2'yi actim
            wplayer.controls.pause();//bu formun muzigini kapattim sesler karismasin diye
            Hide();//bu formu gizledim
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();//menu ekranindan cikilmak istenirse application exit ile programi kapattim
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();//form3'u goster
            wplayer.controls.pause();//muzigi kapat
            Hide();//form3 acilinca suanki formu gizle
        }
    }
}
