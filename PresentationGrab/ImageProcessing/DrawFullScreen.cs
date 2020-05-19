using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PresentationGrab.ImageProcessing
{
    class DrawFullScreen
    {
        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        internal static void Draw(Rectangle r, Brush b)
        {
            var h = GetDC(IntPtr.Zero);
            using (var graph = Graphics.FromHdc(h))
            {
                graph.FillRectangle(b, r);
            }
        }
    }
}
