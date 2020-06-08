// try https://stackoverflow.com/questions/19722028/convert-wasapiloopbackcapture-wav-audio-stream-to-mp3-file for Mp3

using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Audio
{
    public partial class AudioRecord : IDisposable
    {

        internal DirectoryInfo OutputDirectory { get; set; } = new DirectoryInfo(@"C:\Data\Work\Wip\Audio\");

        private IWaveIn recorder;
        private BufferedWaveProvider bufferedWaveProvider;
        private SavingWaveProvider savingWaveProvider;
        // private WaveOut player;

        bool isRecoding = false;
        private bool disposedValue;

        public void StartRecording()
        {
            isRecoding = true;
            // set up the recorder
            // recorder = new WaveIn();
            recorder = new WasapiLoopbackCapture();
            //recorder = new WaveIn();
            recorder.DataAvailable += RecorderOnDataAvailable;

            // set up our signal chain
            bufferedWaveProvider = new BufferedWaveProvider(recorder.WaveFormat);

            var timeString = $"_{DateTime.Now.ToString("HH-mm-ss")}.wav";
            var wavFileName = Path.Combine(OutputDirectory.FullName, timeString);
            savingWaveProvider = new SavingWaveProvider(bufferedWaveProvider, wavFileName);

            //// set up playback
            //player = new WaveOut();
            //player.Init(savingWaveProvider);
            //player.Volume = 1;
            //// begin playback & record
            //player.Play();
            recorder.StartRecording();
        }

        public void StopRecording()
        {
            isRecoding = false;
            // stop recording
            recorder.StopRecording();
            // stop playback
            //player.Stop();
            // finalise the WAV file
            savingWaveProvider.Dispose();
        }

        private void RecorderOnDataAvailable(object sender, WaveInEventArgs waveInEventArgs)
        {
            bufferedWaveProvider.AddSamples(waveInEventArgs.Buffer, 0, waveInEventArgs.BytesRecorded);
        }

        protected virtual void Dispose(bool disposing)
        {
            
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (isRecoding)
                        StopRecording();
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~AudioRecord()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
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