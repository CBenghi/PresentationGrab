using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationGrab
{
    class MusicBeeLyrics
    {
        internal static string LyricsTimestamp(TimeSpan delta)
        {
            var totMin = Convert.ToInt32(Math.Floor(delta.TotalMinutes));
            return $"[{totMin:D3}:{delta.Seconds:D2}.{delta.Milliseconds:D3}] ";
        }

        internal static void ImagesNameToLyrics(DirectoryInfo d)
        {
            var fls = d.GetFiles("*.*").OrderBy(x => x.CreationTime).ToList();
            var basetime = new DateTime(
                2020, 3, 19,
                19, 01, 25
                );

            foreach (var fl in fls)
            {
                var delta = fl.CreationTime - basetime;
                string timeStamp = MusicBeeLyrics.LyricsTimestamp(delta);
                var noExtension = fl.Name.Replace(".png", "");
                Debug.WriteLine($"{timeStamp} {noExtension}");
            }
        }
    }
}
