// try https://stackoverflow.com/questions/19722028/convert-wasapiloopbackcapture-wav-audio-stream-to-mp3-file for Mp3

using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_Recorder
{
    public partial class Form2 
    {
        private IWaveIn recorder;
        private BufferedWaveProvider bufferedWaveProvider;
        private SavingWaveProvider savingWaveProvider;
        private WaveOut player;
        public Form2()
        {
            // InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartRecording();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StopRecording();
        }
        public void StartRecording()
        {
            // set up the recorder
            // recorder = new WaveIn();
            recorder = new WasapiLoopbackCapture();
            //recorder = new WaveIn();
            recorder.DataAvailable += RecorderOnDataAvailable;

            // set up our signal chain
            bufferedWaveProvider = new BufferedWaveProvider(recorder.WaveFormat);
            savingWaveProvider = new SavingWaveProvider(bufferedWaveProvider, Guid.NewGuid() + ".wav");

            // set up playback
            player = new WaveOut();
            player.Init(savingWaveProvider);
            player.Volume = 1;
            // begin playback & record
            player.Play();
            recorder.StartRecording();
        }
        public void StopRecording()
        {
            // stop recording
            recorder.StopRecording();
            // stop playback
            player.Stop();
            // finalise the WAV file
            savingWaveProvider.Dispose();
        }
        private void RecorderOnDataAvailable(object sender, WaveInEventArgs waveInEventArgs)
        {
            bufferedWaveProvider.AddSamples(waveInEventArgs.Buffer, 0, waveInEventArgs.BytesRecorded);
        }
    }


    class SavingWaveProvider : IWaveProvider, IDisposable
    {
        private readonly IWaveProvider sourceWaveProvider;
        private readonly WaveFileWriter writer;
        private bool isWriterDisposed;

        public SavingWaveProvider(IWaveProvider sourceWaveProvider, string wavFilePath)
        {
            this.sourceWaveProvider = sourceWaveProvider;
            writer = new WaveFileWriter(wavFilePath, sourceWaveProvider.WaveFormat);
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            var read = sourceWaveProvider.Read(buffer, offset, count);
            if (count > 0 && !isWriterDisposed)
            {
                writer.Write(buffer, offset, read);
            }
            if (count == 0)
            {
                Dispose(); // auto-dispose in case users forget
            }
            return read;
        }

        public WaveFormat WaveFormat { get { return sourceWaveProvider.WaveFormat; } }

        public void Dispose()
        {
            if (!isWriterDisposed)
            {
                isWriterDisposed = true;
                writer.Dispose();
            }
        }
    }
}