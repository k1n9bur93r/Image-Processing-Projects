using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace _469HW5
{
    public partial class Form1 : Form
    {
        //string saveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AudioSample");
        //Directory dict = Directory.CreateDirectory(saveFolder);
        string outPutFilePath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)),"sound.wav");
        int inputDevices;
        int sampleRate=16000;
        int bitDepth = 8;
        int channels = 1;
        WaveInCapabilities microphone;
        WaveInEvent saveWave;
        WaveFileWriter saver;
        public Form1()
        {
            InitializeComponent();
            trackBar1.Minimum = 1000;
            trackBar1.Maximum = 20000;
            trackBar1.TickFrequency = 1000;
            trackBar1.Value = 16000;
            inputDevices = WaveIn.DeviceCount;
            if (inputDevices > 0)
            {
                microphone = WaveIn.GetCapabilities(0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inputDevices == 0) return;
            
            saveWave = new WaveInEvent();
            saveWave.DeviceNumber = 0;
            button3.Enabled = false;
            saveWave.WaveFormat = new WaveFormat(sampleRate,bitDepth, channels);
            saver = new WaveFileWriter(outPutFilePath, saveWave.WaveFormat);
            saveWave.StartRecording();
            button1.Enabled = false;
            button2.Enabled = true;
            saveWave.DataAvailable += (s,a)=>{
                saver.Write(a.Buffer, 0, a.BytesRecorded);
                if (saver.Position > saveWave.WaveFormat.AverageBytesPerSecond * 30)
                {
                    saveWave.StopRecording();
                }
            };


        }


        private void TestWave_DataAvailable(object sender, WaveInEventArgs e)
        {
            saver.Write(e.Buffer, 0, e.BytesRecorded);
            if (saver.Position > saveWave.WaveFormat.AverageBytesPerSecond * 30)
            {
                saveWave.StopRecording();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveWave.StopRecording();
            saver?.Dispose();
            saver = null;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
            //saveWave.RecordingStopped += (s,a)=> {
               

            //};
        }

        private void SaveWave_RecordingStopped(object sender, StoppedEventArgs e)
        {
            saver?.Dispose();
            saver = null;
            button1.Enabled = true;
            button2.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Wave File (*.wav)|*.wav";
            saveFile.Title = "Save Your Sound Recording";
            saveFile.ShowDialog();
            if (saveFile.FileName != "")
            {
                outPutFilePath = Path.GetFullPath(saveFile.FileName);
            }
            button1.Enabled = true;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) bitDepth = 8;
            radioButton2.Checked= false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) bitDepth = 16;
            radioButton1.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true) bitDepth = 24;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton4.Checked = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true) bitDepth = 32;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            sampleRate = trackBar1.Value;
        }
    }
}
