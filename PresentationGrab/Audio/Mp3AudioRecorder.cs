using System;
using System.IO;
using NAudio.Lame;
using NAudio.Wave;

namespace PresentationGrab.Audio
{
    class Mp3AudioRecorder : IDisposable
    {

        private static LameMP3FileWriter dispWriter;
        IWaveIn dispWaveIn;

        bool _stopped = true;
        private bool disposedValue;

        internal DirectoryInfo OutputDirectory { get; set; } = new DirectoryInfo(@"C:\Data\Work\Wip\Audio\");

        public bool StopRecording()
        {
            if (_stopped)
                return false;
            dispWaveIn.StopRecording();
            StartTime = null;
            return true;
        }

        public DateTime? StartTime { get; set; }

        public bool StartRecording()
        {
            if (!_stopped)
                return false;
            StartTime = DateTime.Now;
            var timeString = $"_{StartTime:HH-mm-ss}.mp3";
            var wavFileName = Path.Combine(OutputDirectory.FullName, timeString);

            // Start recording from loopback
            dispWaveIn = new WasapiLoopbackCapture();
            dispWaveIn.DataAvailable += waveIn_DataAvailable;
            dispWaveIn.RecordingStopped += waveIn_RecordingStopped;
            
            dispWriter = new LameMP3FileWriter(wavFileName, dispWaveIn.WaveFormat, 192);

            dispWaveIn.StartRecording();

            _stopped = false;
            return true;
        }

        void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            // flush output to finish MP3 file correctly

            // signal that recording has finished
            _stopped = true;

            // Dispose of objects
            dispWriter.Dispose();
            dispWaveIn.Dispose();
            
        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            // write recorded data to MP3 writer
            if (dispWriter != null)
                dispWriter.Write(e.Buffer, 0, e.BytesRecorded);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    dispWriter.Dispose();
                    dispWaveIn.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Mp3AudioRecorder()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
