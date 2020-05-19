using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PresentationGrab.ImageProcessing
{
    class CapturedImage
    {
        FileInfo file;

        DateTime timeStamp;

        internal static DateTime GetTimeStampDate(FileInfo x)
        {
            // 2020-01-4--19-04-02.png
            Regex r = new Regex(@"^(\d+)-(\d+)-(\d+)--(\d+)-(\d+)-(\d+)");
            var mt = r.Match(x.Name);
            if (!mt.Success)
                return DateTime.Now.AddDays(7);
            var y = Convert.ToInt32(mt.Groups[1].Value);
            var m = Convert.ToInt32(mt.Groups[2].Value);
            var d = Convert.ToInt32(mt.Groups[3].Value);

            var th = Convert.ToInt32(mt.Groups[4].Value);
            var tm = Convert.ToInt32(mt.Groups[5].Value);
            var ts = Convert.ToInt32(mt.Groups[6].Value);

            var ret = new DateTime(y, m, d);

            return ret.AddHours(th).AddMinutes(tm).AddSeconds(ts);
        }

    }
}
