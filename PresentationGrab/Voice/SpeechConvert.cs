using Google.Cloud.Speech.V1;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationGrab
{
    class SpeechConvert
    {
        readonly static JsonFormatter jf = new JsonFormatter(
                new JsonFormatter.Settings(true)
                );

               
        static readonly DirectoryInfo outFolder = new DirectoryInfo(@"C:\Data\Work\Esame Stato\Wip\");

        internal static IEnumerable<FileInfo> GetFiles(string pattern)
        {
            return outFolder.GetFiles(pattern);
        }

        /// <summary>
        /// Put flacs in the wip folder and then upload them to the cloud storage before converting
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetFlacNames()
        {
            return outFolder.GetFiles("*.flac").Select(x => x.Name);
        }

        public static FileInfo LongRunningRecognize(string uristore, string langCode)
        {
            Uri r = new Uri(uristore);
            var t = r.PathAndQuery;

            var sourceFileName = Path.Combine(outFolder.FullName, t.Substring(1));
            var outStreamName = Path.ChangeExtension(sourceFileName, "json");

            var speech = new SpeechClientBuilder()
            {
                CredentialsPath = @"..\..\..\..\PresentationGrab-GoogleKey.json"
            }.Build();
            // var speech = SpeechClient.Create();
            // var speech = b.
            try
            {
                var longOperation = speech.LongRunningRecognize(new RecognitionConfig()
                {
                    // SampleRateHertz = 16000,
                    EnableAutomaticPunctuation = true,
                    EnableWordTimeOffsets = true,
                    LanguageCode = langCode,
                }, RecognitionAudio.FromStorageUri(uristore));
                longOperation = longOperation.PollUntilCompleted();
                var response = longOperation.Result;

                FileInfo f = new FileInfo(outStreamName);
                using (var fs = f.CreateText())
                {
                    // response.WriteTo(fs);
                    fs.Write(jf.Format(response));
                }
                return f;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            
            return null;
        }

    }
}
