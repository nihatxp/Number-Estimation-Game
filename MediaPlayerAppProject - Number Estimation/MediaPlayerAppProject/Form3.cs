using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;
using System.IO;
using System.Windows.Forms;

namespace MediaPlayerAppProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            backgroundMuzigi();
        }
        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        public void backgroundMuzigi()
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            wplayer.URL = string.Format("{0}Resources\\deflector.mp3", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));

            wplayer.settings.setMode("loop", true);
            wplayer.controls.play();
        }
        Form1 frm = new Form1();
        protected override void OnFormClosing(FormClosingEventArgs e)//form kapatilirsa
        {
            wplayer.controls.pause(); //bu formun muzigini kapat
            frm.Show(); //yukarda tanimladigim form1'i goster
        }
        private void button2_Click(object sender, EventArgs e)//geri don tusuna basilirsa
        {
            frm.Show();//yukarda tanimladigim form1'i goster
            wplayer.controls.pause();//muigi kapat
            Hide();//form3'u gizle
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
