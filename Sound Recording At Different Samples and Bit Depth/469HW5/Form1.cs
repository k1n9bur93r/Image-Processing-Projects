using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using WaveFormRendererLib;
using System.Drawing.Imaging;
using System.Drawing;
using NAudio.Gui;

namespace _469HW5
{
    public partial class Form1 : Form
    {

        string outPutFilePath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)),"sound.wav");
        string tempOutputFilePath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), "tempHammaredWindowSoundHere.wav");

        //recording config
        int sampleRate=16000;
        int bitDepth = 16; //default is 16 bits per sample 
        int channels = 1;

        //naudio helpers
        WaveInCapabilities microphone;
        int inputDevices;
        WaveInEvent saveWave;
        WaveFileWriter saver;
        WaveFileReader reader;

        //sound playback
        SoundPlayer playSound;

        //Soundwave Drawing 
        MaxPeakProvider maxPeakProvider = new MaxPeakProvider();
        RmsPeakProvider rmsPeakProvider = new RmsPeakProvider(100); 
        SamplingPeakProvider samplingPeakProvider = new SamplingPeakProvider(10); 
        AveragePeakProvider averagePeakProvider = new AveragePeakProvider(4);
        StandardWaveFormRendererSettings myRendererSettings = new StandardWaveFormRendererSettings();
        WaveFormRenderer renderer;

        //memoryAudio

        byte[] audioSample;
        float[] modifiedWindow;
        byte[] tempSong;
        int windowSampleCount = 0;
        int selectedWindow = 0; 

        //displayWindows
        bool DisplayNoise = false;
        bool DisplayHammer = false;
        bool DisplayFourier = false;


        public Form1()
        {
            myRendererSettings.PixelsPerPeak = 3;
            myRendererSettings.SpacerPixels = 1;
            myRendererSettings.TopSpacerPen = new Pen(Color.Pink);
            myRendererSettings.BottomSpacerPen= new Pen(Color.HotPink);
            myRendererSettings.Width = 500;
            myRendererSettings.TopHeight = 400;
            myRendererSettings.BottomHeight = 300;
            myRendererSettings.BackgroundColor = Color.Transparent;
            myRendererSettings.TopPeakPen = new Pen(Color.Red);
            myRendererSettings.BottomPeakPen = new Pen(Color.Maroon);
            myRendererSettings.DecibelScale = true;
            InitializeComponent();
            inputDevices = WaveIn.DeviceCount;
            if (inputDevices > 0)
            {
                microphone = WaveIn.GetCapabilities(0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inputDevices == 0) return;

            button3.Enabled = false;
            PlayButton.Enabled = false;
            stopButton.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = true;

            saveWave = new WaveInEvent();
            saveWave.DeviceNumber = 0;
            saveWave.WaveFormat = new WaveFormat(sampleRate,bitDepth, channels);
            saver = new WaveFileWriter(outPutFilePath, saveWave.WaveFormat);
            saveWave.StartRecording();



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
            PlayButton.Enabled = true;
            FixAudioButton.Enabled = true;
        }

        private void SaveWave_RecordingStopped(object sender, StoppedEventArgs e)
        {
            saver?.Dispose();
            saver = null;
            button1.Enabled = true;
            button2.Enabled = false;
            PlayButton.Enabled = true;

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
            FixAudioButton.Enabled = true;
            PlaceHolderImage.Visible = true;
            button4.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            playSound = new SoundPlayer(outPutFilePath);
            playSound.Play();
            stopButton.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            PlayButton.Enabled = true;
            playSound.Stop();
        }
        private void RenderWaveform()
        {
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }
            GenerateWindow();

            waveRender.SamplesPerPixel = 2;
            waveRender.AutoScaleDimensions = new SizeF();

            reader = new WaveFileReader(tempOutputFilePath);
            waveRender.WaveStream = reader;

        }

        //button click

        private void FixAudioButton_Click(object sender, EventArgs e)
        {
            DisplayFourier = false;
            DisplayHammer = false;
            DisplayNoise = false;
            PlaceHolderImage.Visible = false;


            //outPutFilePath = @"C:\Users\Nicholas\Desktop\test.mp3";
            int stepCount = bitDepth / 8;
            audioSample = File.ReadAllBytes(outPutFilePath);
            int sampleSize = ((audioSample.Length - 45) / stepCount);
             windowSampleCount = sampleSize % 400 == 0 ? sampleSize / 400 : (sampleSize / 400) + 1;
            WindowsCountLabel.Text = windowSampleCount.ToString();

            
            trackBar2.Maximum = windowSampleCount;
            trackBar2.Value = 0;
            trackBar2.TickFrequency = 10;
            FixAudioButton.Enabled = false;
            trackBar2.Enabled = true;
            PreviousWindowButton.Enabled = false;
            NextWindowButton.Enabled = true;
            button4.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            selectedWindow = 1;
            SelectedWindowLable.Text = "1";
            RenderWaveform();
        }



        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            SelectedWindowLable.Text = trackBar2.Value.ToString();
            selectedWindow = trackBar2.Value;
            RenderWaveform();


        }

        //sample block selector

            //Next window
        private void button5_Click(object sender, EventArgs e)
        {
            GoNextOneWindow();

        }

        private void GoNextOneWindow() {

            if (selectedWindow > 0)
            {
                PreviousWindowButton.Enabled = true;
            }
            if (selectedWindow >= trackBar2.Maximum)
            {
                NextWindowButton.Enabled = false;
                return;
            }
            selectedWindow++;
            trackBar2.Value++;
            SelectedWindowLable.Text = selectedWindow.ToString();
            RenderWaveform();
        }

        private void PreviousWindowButton_Click(object sender, EventArgs e)
        {
            GoBackOneWindow();
        }
        private void GoBackOneWindow()
        {
            if (selectedWindow == 0)
            {
                PreviousWindowButton.Enabled = false;
                return;
            }
            if (selectedWindow > 0)
            {
                NextWindowButton.Enabled = true;
            }
            selectedWindow--;
            trackBar2.Value--;
            SelectedWindowLable.Text = selectedWindow.ToString();
            RenderWaveform();
        }
        //Hamming window

        private void GenerateWindow()
        {
           
            int steps = (bitDepth / 8);
            int byteRangeStart = selectedWindow!=0?((selectedWindow - 1) * 150)+45:45;
            int byteRangeEnd = byteRangeStart + 399;
            int counter = 0;
            byteRangeStart = byteRangeStart * steps;
            byteRangeEnd = byteRangeEnd * steps;
            byte[] window = new byte[400 * steps];

            if (byteRangeEnd > audioSample.Length)
                return;
            for (int i = byteRangeStart; i < byteRangeEnd; i++)
            {
                window[counter] = audioSample[i];
                    counter++;
            }
            if (DisplayNoise)
            {
                modifiedWindow=Denoise(window,steps);
            }
            else if (DisplayHammer)
            {
                modifiedWindow=Denoise(window,steps);
                modifiedWindow = Hamming(modifiedWindow, steps);
            }
            else if (DisplayFourier)
            {
                modifiedWindow= Denoise(window,steps);
                modifiedWindow = Hamming(modifiedWindow, steps);
                modifiedWindow= Fourier(modifiedWindow);
            }

            using (WaveFileWriter writer = new WaveFileWriter(tempOutputFilePath, new WaveFormat(sampleRate, bitDepth, channels)))
            {
                if (!DisplayFourier && !DisplayHammer && !DisplayNoise)
                {
                    writer.Write(window, 0, window.Length);
                }
                else
                {
                        writer.WriteSamples(modifiedWindow,0,modifiedWindow.Length);
                }
                writer.Close();
            }
        }

        private int ConvertByteSampletoInt(byte[] sample,int  stepCount, int windowPos)
        {
            byte[] subSize = new byte[4];
            if (stepCount == 1)
            {
                subSize[3] = sample[windowPos];
            }
            else
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j < stepCount)
                    {
                        subSize[j] = 0;
                    }
                    else

                    {
                        if (windowPos + j>=sample.Length)
                        {
                            if (stepCount == 2)
                            {
                                subSize[2] = sample[windowPos];
                                if (windowPos + 1 >= sample.Length) break;
                                subSize[3] = sample[windowPos + 1];
                                break;
                            }
                            else if (stepCount == 3)
                            {
                                subSize[1] = sample[windowPos];
                                subSize[2] = sample[windowPos + 1];
                                subSize[3] = sample[windowPos + 2];
                                break;
                            }
                        }
                        subSize[j] = sample[windowPos + j];
                    }
                }
            }
            if (BitConverter.IsLittleEndian)
                Array.Reverse(subSize);
            return BitConverter.ToInt32(subSize, 0);
        }

        private float[] Hamming(float[] window,int stepCount)
        {
            float[] returnData=new float[window.Length];
            for (int i = 0; i < window.Length; i += stepCount)
            {
                
                float cosSample = (float)(.54-.46*(Math.Cos((Math.PI * 2 * window[i]) / (399))));
                returnData[i] = cosSample;
            }
            return returnData;
        }


        //denoise

        private float[] Denoise(byte[] window, int stepCount)
        {
            float[] returnData = new float[window.Length];

            for (int i = 0; i < window.Length; i++)
            {
                int convertedSample = ConvertByteSampletoInt(window,stepCount,i);
                returnData[i] =(float)( convertedSample-0.95*Math.Sqrt(convertedSample-1));//some kind of calculation here 
            }
            return returnData;
            
        }

        //fouir transfrom

        private float[] Fourier(float[] window)
        {

            float[] returnData = new float[window.Length];
            for (int i = 0; i < window.Length; i++)
            {
               // int currentSample = ConvertByteSampletoInt(window, stepCount, i);
                returnData[i] = (float)(window[i]*(Math.Pow(Math.E,((2*Math.PI*i)/399)))); //what do we do with i and where does m go?
            }
            return returnData;
        }

        //Denoise button
        private void button10_Click(object sender, EventArgs e)
        {
            DisplayNoise = true;
            DisplayFourier = false;
            DisplayHammer = false;
            RenderWaveform();
        }
        //Hammer button
        private void button8_Click(object sender, EventArgs e)
        {
            DisplayNoise = false;
            DisplayFourier = false;
            DisplayHammer = true;
            RenderWaveform();
        }
        //Fourier button
        private void button9_Click(object sender, EventArgs e)
        {
            DisplayNoise = false;
            DisplayFourier = true;
            DisplayHammer = false;
            RenderWaveform();
        }
        // no manipulation
        private void button4_Click_1(object sender, EventArgs e)
        {
            DisplayNoise = false;
            DisplayFourier = false;
            DisplayHammer = false;
            RenderWaveform();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }
            File.Delete(tempOutputFilePath);
        }

        private void waveRender_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue > e.NewValue)
            {
                GoNextOneWindow();
            }
            else
            {
                GoBackOneWindow();
            }
        }
    }
}
