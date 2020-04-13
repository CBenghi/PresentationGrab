using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PresentationGrab
{
    class ImageFeeder
    {
        public static IEnumerable<FileInfo> GetImages(string folder)
        {
            var d = new DirectoryInfo(folder);
            var lst = d.GetFiles("*.png").OrderBy(x => x.CreationTime).ToList();
            return lst;
        }
    }
}
